using System;
using System.Collections.Generic;

namespace MartinTest.Models
{
    public class RequestHeaderModel
    {
        public string Req_No { get; set; }
        public string Req_Type { get; set; }
        public string Site { get; set; }
        public string Requester_Option { get; set; }
        public string User_Name { get; set; }
        public string Manager { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public List<RequestDetailModel> DetailsList { get; set; }
    }

    public class RequestDetailModel
    {
        public string Req_No { get; set; }
        public string Req { get; set; }
        public string Details { get; set; }
        public bool? Private { get; set; }
        public string Other { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }

    public class LookupItemModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }

    public class UserDetailDTO
    {
        public string EmpID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepID { get; set; }
        public string ManagerName { get; set; }
    }
    public class TicketSummaryDTO
    {
        public string Req_No { get; set; }
        public string Req_Type { get; set; }
        public string Site { get; set; }
        public string Requester_Option { get; set; }
        public string User_Name { get; set; }
        public string Manager { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int TotalItems { get; set; }
        public List<RequestDetailModel> DetailsList { get; set; }
    }
}
