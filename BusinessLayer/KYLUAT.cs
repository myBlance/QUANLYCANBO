using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KYLUAT
    {
        QLCBEntities db = new QLCBEntities();
        public tb_KYLUAT getItem(string soQD)
        {
            return db.tb_KYLUAT.FirstOrDefault(x => x.SOQD == soQD);
        }
        public List<tb_KYLUAT> getList()
        {
            return db.tb_KYLUAT.ToList();
        }
        public List<KYLUAT_DTO> getListFull()
        {
            List<tb_KYLUAT> lstKT = db.tb_KYLUAT.ToList();
            List<KYLUAT_DTO> lstDTO = new List<KYLUAT_DTO>();
            KYLUAT_DTO kt;
            foreach (var item in lstKT)
            {
                kt = new KYLUAT_DTO();
                kt.SOQD = item.SOQD;
                kt.TUNGAY = item.TUNGAY;
                kt.DENNGAY = item.DENNGAY;
                kt.NGAY = item.NGAY;
                kt.LYDO = item.LYDO;
                kt.NOIDUNG = item.NOIDUNG;
                kt.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n => n.MACB == item.MACB);
                kt.HOTEN = cb.HOTEN;
                kt.CREATED_BY = item.CREATED_BY;
                kt.CREATED_DATE = item.CREATED_DATE;
                kt.UPDATED_BY = item.UPDATED_BY;
                kt.UPDATED_DATE = item.UPDATED_DATE;
                kt.DELETED_BY = item.DELETED_BY;
                kt.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(kt);
            }
            return lstDTO;
        }
        public tb_KYLUAT Add(tb_KYLUAT kt)
        {
            try
            {
                db.tb_KYLUAT.Add(kt);
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_KYLUAT Update(tb_KYLUAT kt)
        {
            try
            {
                tb_KYLUAT _kt = db.tb_KYLUAT.FirstOrDefault(x => x.SOQD == kt.SOQD);
                _kt.NGAY = kt.NGAY;
                _kt.TUNGAY = kt.TUNGAY;
                _kt.DENNGAY = kt.DENNGAY;
                _kt.LYDO = kt.LYDO;
                _kt.NOIDUNG = kt.NOIDUNG;
                _kt.MACB = kt.MACB;
                _kt.UPDATED_BY = kt.UPDATED_BY;
                _kt.UPDATED_DATE = kt.UPDATED_DATE;
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public void Delete(string soQD, int iduser)
        {
            try
            {
                tb_KYLUAT _kt = db.tb_KYLUAT.FirstOrDefault(x => x.SOQD == soQD);
                _kt.DELETED_BY = iduser;
                _kt.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public string MaxSoQuyetDinh()
        {
            var _hd = db.tb_KYLUAT.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00";
        }
    }
}
