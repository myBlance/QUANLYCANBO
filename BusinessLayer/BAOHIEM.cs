using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.DTO;

namespace BusinessLayer
{
    public class BAOHIEM
    {
        QLCBEntities db = new QLCBEntities();
        public tb_BAOHIEM getItem(int mabh)
        {
            return db.tb_BAOHIEM.FirstOrDefault(x => x.MABH == mabh);
        }
        public List<tb_BAOHIEM> getList()
        {
            return db.tb_BAOHIEM.ToList();
        }
        public List<BAOHIEM_DTO> getListFull()
        {
            var lstDC = db.tb_BAOHIEM.ToList();
            List<BAOHIEM_DTO> lstDTO = new List<BAOHIEM_DTO>();
            BAOHIEM_DTO cbDTO;
            foreach (var item in lstDC)
            {
                cbDTO = new BAOHIEM_DTO();
                cbDTO.MABH = item.MABH;
                cbDTO.SOBH = item.SOBH;
                cbDTO.NGAYCAP = item.NGAYCAP;
                cbDTO.NGAYHETHAN = item.NGAYHETHAN;
                cbDTO.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n => n.MACB == item.MACB);
                cbDTO.HOTEN = cb.HOTEN;
                cbDTO.NOICAP = item.NOICAP;
                cbDTO.NOIKHAMBENH = item.NOIKHAMBENH;
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
        public tb_BAOHIEM Add(tb_BAOHIEM tv)
        {
            try
            {
                db.tb_BAOHIEM.Add(tv);
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_BAOHIEM Update(tb_BAOHIEM tv)
        {
            try
            {
                var _tv = db.tb_BAOHIEM.FirstOrDefault(x => x.MABH == tv.MABH);
                _tv.SOBH = tv.SOBH;
                _tv.NGAYCAP = tv.NGAYCAP;
                _tv.NGAYHETHAN = tv.NGAYHETHAN;
                _tv.MACB = tv.MACB;
                _tv.NOICAP = tv.NOICAP;
                _tv.NOIKHAMBENH = tv.NOIKHAMBENH;
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
        public void Delete(int mabh, int iduser)
        {
            try
            {
                var _tv = db.tb_BAOHIEM.FirstOrDefault(x => x.MABH == mabh);
                _tv.DELETED_BY = iduser;
                _tv.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
