using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer.DTO
{
    public class BAOHIEM_DTO
    {
        public int MABH { get; set; }
        public string SOBH { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public Nullable<System.DateTime> NGAYHETHAN { get; set; }
        public string NOICAP { get; set; }
        public string NOIKHAMBENH { get; set; }
        public Nullable<int> MACB { get; set; }
        public string HOTEN {  get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
    }
}
