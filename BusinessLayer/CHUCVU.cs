using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CHUCVU
    {
        QLCBEntities db = new QLCBEntities();
        public tb_CHUCVU getItem(int id)
        {
            return db.tb_CHUCVU.FirstOrDefault(x => x.MACV == id);
        }
        public List<tb_CHUCVU> getList()
        {
            return db.tb_CHUCVU.ToList();
        }
        public tb_CHUCVU Add(tb_CHUCVU td)
        {
            try
            {
                db.tb_CHUCVU.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_CHUCVU Update(tb_CHUCVU td)
        {
            try
            {
                var _td = db.tb_CHUCVU.FirstOrDefault(x => x.MACV == td.MACV);
                _td.TENCHUCVU = td.TENCHUCVU;
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
                var _td = db.tb_CHUCVU.FirstOrDefault(x => x.MACV == id);
                db.tb_CHUCVU.Remove(_td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
