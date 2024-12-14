using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer;

namespace BusinessLayer
{
    public class THOIVIEC
    {
        QLCBEntities db = new QLCBEntities();
        public tb_THOIVIEC getItem(string soqd)
        {
            return db.tb_THOIVIEC.FirstOrDefault(x=>x.SOQD==soqd);
        }
        public List<tb_THOIVIEC> getList()
        {
            return db.tb_THOIVIEC.ToList();
        }
        public List<THOIVIEC_DTO> getListFull()
        {
            var lstDC = db.tb_THOIVIEC.ToList();
            List<THOIVIEC_DTO> lstDTO = new List<THOIVIEC_DTO>();
            THOIVIEC_DTO cbDTO;
            foreach (var item in lstDC)
            {
                cbDTO = new THOIVIEC_DTO();
                cbDTO.SOQD = item.SOQD;
                cbDTO.NGAYNOPDON = item.NGAYNOPDON;
                cbDTO.NGAYNGHI = item.NGAYNGHI;
                cbDTO.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n => n.MACB == item.MACB);
                cbDTO.HOTEN = cb.HOTEN;
                cbDTO.LYDO = item.LYDO;
                cbDTO.GHICHU = item.GHICHU;
                cbDTO.CREATED_BY = item.CREATED_BY;
                cbDTO.CREATED_DATE = item.CREATED_DATE;
                cbDTO.UPDATED_BY = item.UPDATED_BY;
                cbDTO.UPDATED_DATE = item.UPDATED_DATE;
                cbDTO.DELETED_BY = item.DELETED_BY;
                cbDTO.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(cbDTO);
            }
            return lstDTO;
        }
        public tb_THOIVIEC Add(tb_THOIVIEC tv)
        {
            try
            {
                db.tb_THOIVIEC.Add(tv);
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_THOIVIEC Update(tb_THOIVIEC tv)
        {
            try
            {
                var _tv = db.tb_THOIVIEC.FirstOrDefault(x=>x.SOQD == tv.SOQD);
                _tv.NGAYNGHI = tv.NGAYNGHI;
                _tv.NGAYNOPDON = tv.NGAYNOPDON;
                _tv.MACB = tv.MACB;
                _tv.LYDO = tv.LYDO;
                _tv.GHICHU = tv.GHICHU;
                _tv.UPDATED_BY = tv.UPDATED_BY;
                _tv.UPDATED_DATE = tv.UPDATED_DATE;
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string soqd, int iduser)
        {
            try
            {
                var _tv = db.tb_THOIVIEC.FirstOrDefault(x => x.SOQD == soqd);
                _tv.DELETED_BY = iduser;
                _tv.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public string MaxSoQuyetDinh()
        {
            var _hd = db.tb_THOIVIEC.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00";
        }
    }
}
