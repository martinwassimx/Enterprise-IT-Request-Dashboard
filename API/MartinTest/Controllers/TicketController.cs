using MartinTest.db;
using MartinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MartinTest.Controllers
{
    public class TicketController : ApiController
    {
        // 1. GET LOOKUPS (dbo.document)
        [HttpGet]
        [Route("api/Ticket/GetLookups/")]
        public HttpResponseMessage GetLookups()
        {
            using (var ctx = new HREntities())
            {
                var query = "SELECT Title, Name FROM dbo.document";
                var list = ctx.Database.SqlQuery<LookupItemModel>(query).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
        }

        // 2. GET USERS WITH DEPARTMENT MANAGER JOIN
        [HttpGet]
        [Route("api/Ticket/GetUsers/")]
        public HttpResponseMessage GetUsers()
        {
            using (var ctx = new HREntities())
            {
                string query = @"
                    SELECT 
                        CAST(e.EID AS NVARCHAR(10)) AS EmpID,
                        LTRIM(RTRIM(e.FirstName + ' ' + ISNULL(e.SecoendName, ''))) AS Name,
                        ISNULL(e.Mail, '') AS Email,
                        ISNULL(e.DepartmentID, 0) AS DepID,
                        ISNULL(d.Name, 'None') AS ManagerName
                    FROM dbo.Employe e
                    LEFT JOIN dbo.Department d ON e.DepartmentID = d.DepID";

                var users = ctx.Database.SqlQuery<UserDetailDTO>(query).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
        }

        // 3. GET NEXT TICKET NUMBER (PREVENTS DUPLICATES)
        [HttpGet]
        [Route("api/Ticket/GetNextReqNo/")]
        public HttpResponseMessage GetNextReqNo()
        {
            using (var ctx = new HREntities())
            {
                string query = @"
                    SELECT ISNULL(MAX(CAST(SUBSTRING(Req_No, 5, LEN(Req_No) - 4) AS INT)), 0) + 1 
                    FROM dbo.RequestHeader 
                    WHERE Req_No LIKE 'REQ-%'";

                try
                {
                    int nextNumber = ctx.Database.SqlQuery<int>(query).FirstOrDefault();
                    string nextReq = "REQ-" + nextNumber.ToString("D4");
                    return Request.CreateResponse(HttpStatusCode.OK, nextReq);
                }
                catch
                {
                    string fallback = "REQ-" + (DateTime.UtcNow.Ticks % 10000).ToString("D4");
                    return Request.CreateResponse(HttpStatusCode.OK, fallback);
                }
            }
        }

        // 4. SAVE TICKET (INCLUDES CREATED_BY AND CREATED_DATE AUDIT)
        [HttpPost]
        [Route("api/Ticket/SaveTicket/")]
        public HttpResponseMessage SaveTicket(RequestHeaderModel req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Req_No))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ticket data.");
            }

            // Fallback guard to ensure Created_By is never NULL in database
            string creator = !string.IsNullOrWhiteSpace(req.Created_By)
                             ? req.Created_By.Trim()
                             : (!string.IsNullOrWhiteSpace(req.User_Name) ? req.User_Name.Trim() : "System");

            using (var ctx = new HREntities())
            {
                using (var trans = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        string headerSql = @"
                            INSERT INTO dbo.RequestHeader 
                                (Req_No, Req_Type, Site, Requester_Option, User_Name, Manager, Created_By, Created_Date) 
                            VALUES 
                                ({0}, {1}, {2}, {3}, {4}, {5}, {6}, GETDATE())";

                        ctx.Database.ExecuteSqlCommand(
                            headerSql,
                            req.Req_No,
                            req.Req_Type,
                            req.Site,
                            req.Requester_Option,
                            req.User_Name,
                            req.Manager,
                            creator
                        );

                        if (req.DetailsList != null && req.DetailsList.Count > 0)
                        {
                            string detailSql = @"
                                INSERT INTO dbo.RequestDetails 
                                    (Req_No, Req, Details, [Private], Other, Remarks, Status) 
                                VALUES 
                                    ({0}, {1}, {2}, {3}, {4}, {5}, {6})";

                            foreach (var item in req.DetailsList)
                            {
                                ctx.Database.ExecuteSqlCommand(
                                    detailSql,
                                    req.Req_No,
                                    item.Req,
                                    item.Details,
                                    item.Private ?? false,
                                    item.Other,
                                    item.Remarks,
                                    item.Status ?? "Pending"
                                );
                            }
                        }

                        trans.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, "Saved successfully");
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
            }
        }

        // 5. GET ALL TICKETS WITH METADATA & DETAILS
        [HttpGet]
        [Route("api/Ticket/GetAllTickets/")]
        public HttpResponseMessage GetAllTickets()
        {
            using (var ctx = new HREntities())
            {
                string headerSql = @"
                    SELECT Req_No, Req_Type, Site, Requester_Option, User_Name, Manager, Created_By, Created_Date 
                    FROM dbo.RequestHeader 
                    ORDER BY Req_No DESC";
                var headers = ctx.Database.SqlQuery<RequestHeaderModel>(headerSql).ToList();

                string detailsSql = @"
                    SELECT Req_No, Req, Details, [Private], Other, Remarks, Status 
                    FROM dbo.RequestDetails";
                var details = ctx.Database.SqlQuery<RequestDetailModel>(detailsSql).ToList();

                var ticketList = headers.Select(h => new TicketSummaryDTO
                {
                    Req_No = h.Req_No,
                    Req_Type = h.Req_Type,
                    Site = h.Site,
                    Requester_Option = h.Requester_Option,
                    User_Name = h.User_Name,
                    Manager = h.Manager,
                    Created_By = h.Created_By,
                    Created_Date = h.Created_Date,
                    TotalItems = details.Count(d => d.Req_No == h.Req_No),
                    DetailsList = details.Where(d => d.Req_No == h.Req_No).ToList()
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, ticketList);
            }
        }

        // 6. UPDATE ITEM STATUS
        [HttpPost]
        [Route("api/Ticket/UpdateStatus/")]
        public HttpResponseMessage UpdateStatus([FromUri] string reqNo, [FromUri] string req, [FromUri] string newStatus)
        {
            using (var ctx = new HREntities())
            {
                string sql = "UPDATE dbo.RequestDetails SET Status = {0} WHERE Req_No = {1} AND Req = {2}";
                int rows = ctx.Database.ExecuteSqlCommand(sql, newStatus, reqNo, req);

                if (rows > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, "Status updated successfully.");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Record not found.");
            }
        }

        // 7. DELETE TICKET & ASSOCIATED DETAILS
        [HttpPost]
        [Route("api/Ticket/DeleteTicket/")]
        public HttpResponseMessage DeleteTicket([FromUri] string reqNo)
        {
            using (var ctx = new HREntities())
            {
                using (var trans = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        // Clean children first to prevent foreign key errors
                        string deleteDetailsSql = "DELETE FROM dbo.RequestDetails WHERE Req_No = {0}";
                        ctx.Database.ExecuteSqlCommand(deleteDetailsSql, reqNo);

                        string deleteHeaderSql = "DELETE FROM dbo.RequestHeader WHERE Req_No = {0}";
                        int rows = ctx.Database.ExecuteSqlCommand(deleteHeaderSql, reqNo);

                        if (rows > 0)
                        {
                            trans.Commit();
                            return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
                        }
                        else
                        {
                            trans.Rollback();
                            return Request.CreateResponse(HttpStatusCode.NotFound, "Ticket not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
            }
        }
    }
}