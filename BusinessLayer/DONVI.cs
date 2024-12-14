using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class DONVI
    {
        QLCBEntities db = new QLCBEntities();
        public tb_DONVI getItem(int id)
        {
            return db.tb_DONVI.FirstOrDefault(x => x.MAPHONG == id);
        }
        public List<tb_DONVI> getList()
        {
            return db.tb_DONVI.ToList();
        }
        public tb_DONVI Add(tb_DONVI td)
        {
            try
            {
                db.tb_DONVI.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_DONVI Update(tb_DONVI td)
        {
            try
            {
                var _td = db.tb_DONVI.FirstOrDefault(x => x.MAPHONG == td.MAPHONG);
                _td.TENPHONG = td.TENPHONG;
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
                var _td = db.tb_DONVI.FirstOrDefault(x => x.MAPHONG == id);
                db.tb_DONVI.Remove(_td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
