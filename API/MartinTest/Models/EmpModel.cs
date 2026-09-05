using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinTest.Models
{
    public class EmpModel
    {
        public class EmpData
        {
            public int EID { get; set; }
            public string FirstName { get; set; }
            public string SecoendName { get; set; }
            public DateTime? BirthDate { get; set; }
            public int? NationalID { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Title { get; set; }
            public string Serial { get; set; }
            public string Mail { get; set; }
        }
    }
}