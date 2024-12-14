using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer.DTO
{
    public class THANGHAM_DTO
    {
        public string SOQD { get; set; }
        public Nullable<int> MACB { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> MACH { get; set; }
        public string TENCAPHAM {  get; set; }
        public int NAMLEN { get; set; }
        public Nullable<int> MACH2 { get; set; }
        public string TENCAPHAM2 { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public Nullable<System.DateTime> NGAYTIEPTHEO { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string LYDO { get; set; }
    }
}
