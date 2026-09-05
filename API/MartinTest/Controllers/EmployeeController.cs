using MartinTest.db;
using MartinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static MartinTest.Models.EmpModel;

namespace MartinTest.Controllers
{
    public class EmployeeController : ApiController
    {
        // 1. GET BY NATIONAL ID
        [HttpGet]
        [Authorize]
        [Route("api/Employee/GetByNationalID/")]
        public HttpResponseMessage GetByNationalID(int NationalID)
        {
            using (var ctx = new HREntities())
            {
                var query = "SELECT EID, FirstName, SecoendName, BirthDate, NationalID, PhoneNumber, Address, Title, Serial, Mail FROM Employe WHERE NationalID = " + NationalID;
                var emp = ctx.Database.SqlQuery<EmpData>(query).FirstOrDefault();

                if (emp == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "الموظف غير موجود");
                }

                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
        }

        // 2. GET LATEST SERIAL & NEXT PREVIEW
        [HttpGet]
        [Authorize]
        [Route("api/Employee/GetLatestSerial/")]
        public HttpResponseMessage GetLatestSerial()
        {
            using (var ctx = new HREntities())
            {
                var query = "SELECT TOP 1 EID, FirstName, SecoendName, BirthDate, NationalID, PhoneNumber, Address, Title, Serial, Mail FROM Employe ORDER BY EID DESC";
                var lastEmp = ctx.Database.SqlQuery<EmpData>(query).FirstOrDefault();

                int lastEID = lastEmp != null ? lastEmp.EID : 0;
                string lastSerial = (lastEmp != null && !string.IsNullOrEmpty(lastEmp.Serial)) ? lastEmp.Serial : "None";
                string nextSerial = "N" + (lastEID + 1).ToString("D3");

                var result = new
                {
                    LastSerial = lastSerial,
                    NextSerial = nextSerial
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        // 3. SAVE NEW EMPLOYEE (Serial is computed by SQL Server)
        [HttpPost]
        [Authorize]
        [Route("api/Employee/SaveEmp/")]
        public HttpResponseMessage SaveEmp(List<EmpData> emp1)
        {
            foreach (var emp in emp1)
            {
                // ✅ Guard: NationalID is required and must not be 0 or null
                if (emp.NationalID == null || emp.NationalID == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "الرقم الوطني مطلوب");
                }

                using (var ctx = new HREntities())
                {
                    var arg = "INSERT INTO Employe (FirstName, SecoendName, BirthDate, NationalID, PhoneNumber, Address, Title, Mail)";
                    arg += " VALUES(N'" + emp.FirstName + "',N'" + emp.SecoendName +
                           "',N'" + emp.BirthDate?.ToString("yyyy-MM-dd") + "'," +
                           emp.NationalID +   // ✅ safe now since we checked above
                           ",N'" + emp.PhoneNumber + "',N'" + emp.Address +
                           "',N'" + emp.Title + "',N'" + emp.Mail + "')";

                    ctx.Database.ExecuteSqlCommand(arg);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, "تم الحفظ");
        }

        // 4. UPDATE EMPLOYEE
        [HttpPost]
        [Authorize]
        [Route("api/Employee/UpdateEmp/")]
        public HttpResponseMessage UpdateEmp(List<EmpData> emp1)
        {
            var arg = "";
            int totalUpdated = 0;

            foreach (var emp in emp1)
            {
                using (var ctx = new HREntities())
                {
                    arg = " UPDATE Employe SET ";
                    arg = arg + " FirstName = N'" + emp.FirstName + "', ";
                    arg = arg + " SecoendName = N'" + emp.SecoendName + "', ";
                    arg = arg + " BirthDate = N'" + emp.BirthDate?.ToString("yyyy-MM-dd") + "', ";
                    arg = arg + " NationalID = " + emp.NationalID + ", ";
                    arg = arg + " PhoneNumber = N'" + emp.PhoneNumber + "', ";
                    arg = arg + " Address = N'" + emp.Address + "', ";
                    arg = arg + " Title = N'" + emp.Title + "', ";
                    arg = arg + " Mail = N'" + emp.Mail + "' ";
                    arg = arg + " WHERE EID = " + emp.EID;

                    int noOfRowUpdated = ctx.Database.ExecuteSqlCommand(arg);
                    totalUpdated += noOfRowUpdated;
                }
            }

            if (totalUpdated > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "تم التعديل");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "لم يتم العثور على موظف بهذا الـ ID");
            }
        }

        // 5. DELETE EMPLOYEE
        [HttpPost]
        [Authorize]
        [Route("api/Employee/DeleteEmp/")]
        public HttpResponseMessage DeleteEmp([FromUri] int EID)
        {
            using (var ctx = new HREntities())
            {
                var arg = "DELETE FROM Employe WHERE EID = " + EID;
                int noOfRowDeleted = ctx.Database.ExecuteSqlCommand(arg);

                if (noOfRowDeleted > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "تم الحذف");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "لم يتم العثور على موظف بهذا الـ ID");
                }
            }
        }
    }
}