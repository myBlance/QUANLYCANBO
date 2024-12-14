using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer;

namespace BusinessLayer
{
    public class DIEUCHUYEN
    {
        QLCBEntities db = new QLCBEntities();
        public tb_DIEUCHUYEN getItem(string soqd)
        {
            return db.tb_DIEUCHUYEN.FirstOrDefault(x=>x.SOQD==soqd);
        }
        public List<tb_DIEUCHUYEN> getList()
        {
            return db.tb_DIEUCHUYEN.ToList();
        }
        public List<DIEUCHUYEN_DTO> getListFull()
        {
            var lstDC = db.tb_DIEUCHUYEN.ToList();
            List<DIEUCHUYEN_DTO> lstDTO = new List<DIEUCHUYEN_DTO>();
            DIEUCHUYEN_DTO cbDTO;
            foreach (var item in lstDC)
            {
                cbDTO = new DIEUCHUYEN_DTO();
                cbDTO.SOQD = item.SOQD;
                cbDTO.NGAY = item.NGAY;
                cbDTO.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n=>n.MACB==item.MACB);
                cbDTO.HOTEN = cb.HOTEN;

                cbDTO.MAPHONG = item.MAPHONG;
                var dv = db.tb_DONVI.FirstOrDefault(p=>p.MAPHONG==item.MAPHONG);
                cbDTO.TENPHONG = dv.TENPHONG;

                cbDTO.MAPHONG2 = item.MAPHONG2;
                var dv2 = db.tb_DONVI.FirstOrDefault(p2 => p2.MAPHONG == item.MAPHONG2);
                cbDTO.TENPHONG2 = dv2.TENPHONG;
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
        public tb_DIEUCHUYEN Add(tb_DIEUCHUYEN dc)
        {
            try
            {
                db.tb_DIEUCHUYEN.Add(dc);
                db.SaveChanges();
                return dc;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_DIEUCHUYEN Update(tb_DIEUCHUYEN dc)
        {
            try
            {
                var _dc = db.tb_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == dc.SOQD);
                _dc.MAPHONG2 = dc.MAPHONG2;
                _dc.NGAY = dc.NGAY;
                _dc.LYDO = dc.LYDO;
                _dc.GHICHU = dc.GHICHU;
                _dc.UPDATED_BY = dc.UPDATED_BY;
                _dc.UPDATED_DATE = dc.UPDATED_DATE;
                db.SaveChanges();
                return dc;
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
                var _dc = db.tb_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == soqd);
                _dc.DELETED_BY = iduser;
                _dc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public string MaxSoQuyetDinh()
        {
            var _hd = db.tb_DIEUCHUYEN.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00";
        }
    }
}
