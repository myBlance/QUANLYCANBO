using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class THANGHAM
    {
        QLCBEntities db = new QLCBEntities();
        public tb_LENHAM getItem(string soqd)
        {
            return db.tb_LENHAM.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<THANGHAM_DTO> getItemFull(string soqd)
        {
            List<tb_LENHAM> lstLH = db.tb_LENHAM.Where(x=>x.SOQD==soqd).ToList();
            List<THANGHAM_DTO> lstDTO = new List<THANGHAM_DTO>();
            THANGHAM_DTO th;
            foreach (var item in lstLH)
            {
                th = new THANGHAM_DTO();
                var dv = db.tb_CAPHAM.FirstOrDefault(p => p.MACH == item.MACH);
                th.NAMLEN = dv.NAMLEN.Value;
                lstDTO.Add(th);
            }    
            return lstDTO;
        }
        public List<tb_LENHAM> getList()
        {
            return db.tb_LENHAM.ToList();
        }
        public List<THANGHAM_DTO> getListFull()
        {
            var lstTH = db.tb_LENHAM.ToList();
            List<THANGHAM_DTO> lstDTO = new List<THANGHAM_DTO>();
            THANGHAM_DTO cbDTO;
            foreach (var item in lstTH)
            {
                cbDTO = new THANGHAM_DTO();
                cbDTO.SOQD = item.SOQD;
                cbDTO.NGAY = item.NGAY;
                cbDTO.NGAYTIEPTHEO = item.NGAYTIEPTHEO;
                cbDTO.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n => n.MACB == item.MACB);
                cbDTO.HOTEN = cb.HOTEN;

                cbDTO.MACH = item.MACH;
                var dv = db.tb_CAPHAM.FirstOrDefault(p => p.MACH == item.MACH);
                cbDTO.TENCAPHAM = dv.TENCAPHAM;

                cbDTO.MACH2 = item.MACH2;
                var dv2 = db.tb_CAPHAM.FirstOrDefault(p2 => p2.MACH == item.MACH2);
                cbDTO.TENCAPHAM2 = dv2.TENCAPHAM;
                cbDTO.LYDO = item.LYDO;
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
        public tb_LENHAM Add(tb_LENHAM dc)
        {
            try
            {
                db.tb_LENHAM.Add(dc);
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_LENHAM Update(tb_LENHAM dc)
        {
            try
            {
                var _dc = db.tb_LENHAM.FirstOrDefault(x => x.SOQD == dc.SOQD);
                _dc.MACH2 = dc.MACH2;
                _dc.NGAY = dc.NGAY;
                _dc.NGAYTIEPTHEO = dc.NGAYTIEPTHEO;
                _dc.LYDO = dc.LYDO;
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
                var _dc = db.tb_LENHAM.FirstOrDefault(x => x.SOQD == soqd);
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
            var _hd = db.tb_LENHAM.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00";
        }
        public List<THANGHAM_DTO> getLenLuong()
        {
            var lstTH = db.tb_LENHAM.Where(x=>x.NGAYTIEPTHEO.Value.Year - DateTime.Now.Year == 0).ToList();
            List<THANGHAM_DTO> lstDTO = new List<THANGHAM_DTO>();
            THANGHAM_DTO cbDTO;
            foreach (var item in lstTH)
            {
                cbDTO = new THANGHAM_DTO();
                cbDTO.SOQD = item.SOQD;
                cbDTO.NGAY = item.NGAY;
                cbDTO.NGAYTIEPTHEO = item.NGAYTIEPTHEO;
                cbDTO.MACB = item.MACB;
                var cb = db.tb_CANBO.FirstOrDefault(n => n.MACB == item.MACB);
                cbDTO.HOTEN = cb.HOTEN;

                cbDTO.MACH = item.MACH;
                var dv = db.tb_CAPHAM.FirstOrDefault(p => p.MACH == item.MACH);
                cbDTO.TENCAPHAM = dv.TENCAPHAM;

                cbDTO.MACH2 = item.MACH2;
                var dv2 = db.tb_CAPHAM.FirstOrDefault(p2 => p2.MACH == item.MACH2);
                cbDTO.TENCAPHAM2 = dv2.TENCAPHAM;
                cbDTO.LYDO = item.LYDO;
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
    }
}
