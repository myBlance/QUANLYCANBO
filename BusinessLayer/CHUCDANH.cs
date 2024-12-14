using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CHUCDANH
    {
        QLCBEntities db = new QLCBEntities();
        public tb_CHUCDANH getItem(int id)
        {
            return db.tb_CHUCDANH.FirstOrDefault(x => x.MACD == id);
        }
        public List<tb_CHUCDANH> getList()
        {
            return db.tb_CHUCDANH.ToList();
        }
        public tb_CHUCDANH Add(tb_CHUCDANH td)
        {
            try
            {
                db.tb_CHUCDANH.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_CHUCDANH Update(tb_CHUCDANH td)
        {
            try
            {
                var _td = db.tb_CHUCDANH.FirstOrDefault(x => x.MACD == td.MACD);
                _td.TENCHUCDANH = td.TENCHUCDANH;
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
                var _td = db.tb_CHUCDANH.FirstOrDefault(x => x.MACD == id);
                db.tb_CHUCDANH.Remove(_td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
