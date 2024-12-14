using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CAPBACHAM
    {
        QLCBEntities db = new QLCBEntities();
        public tb_CAPHAM getItem(int id)
        {
            return db.tb_CAPHAM.FirstOrDefault(x => x.MACH == id);
        }
        public List<tb_CAPHAM> getList()
        {
            return db.tb_CAPHAM.ToList();
        }
        public tb_CAPHAM Add(tb_CAPHAM td)
        {
            try
            {
                db.tb_CAPHAM.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_CAPHAM Update(tb_CAPHAM td)
        {
            try
            {
                var _td = db.tb_CAPHAM.FirstOrDefault(x => x.MACH == td.MACH);
                _td.TENCAPHAM = td.TENCAPHAM;
                _td.HESOLUONG = td.HESOLUONG;
                _td.NAMLEN = td.NAMLEN;
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var _td = db.tb_CAPHAM.FirstOrDefault(x => x.MACH == id);
                db.tb_CAPHAM.Remove(_td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
