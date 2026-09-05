namespace MartinTest.db
{
    using System;
    using System.Collections.Generic;

    public partial class Employe_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employe_Table()
        {
            this.Salary_Table = new HashSet<Salary_Table>();
        }

        public string EID { get; set; }
        public string First_Name { get; set; }
        public string Secoend_Name { get; set; }
        public System.DateTime Birth_Date { get; set; }
        public int National_ID { get; set; }
        public int Phone_Number { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public bool Sataus { get; set; }
        public byte[] Mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary_Table> Salary_Table { get; set; }
    }
}