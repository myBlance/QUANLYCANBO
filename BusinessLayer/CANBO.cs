using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.DTO;
using System.Globalization;

namespace BusinessLayer
{
    public class CANBO
    {
        QLCBEntities db = new QLCBEntities();
        public tb_CANBO getItem(int id)
        {
            return db.tb_CANBO.FirstOrDefault(x => x.MACB == id);
        }
        public List<tb_CANBO> getList()
        {
            return db.tb_CANBO.ToList();
        }
        public List<CANBO_DTO> getListFull()
        {
            var lstCB = db.tb_CANBO.ToList();
            List<CANBO_DTO> lstCBDTO = new List<CANBO_DTO>();
            CANBO_DTO cbDTO;
            foreach (var item in lstCB)
            {
                cbDTO = new CANBO_DTO();
                cbDTO.MACB = item.MACB;
                cbDTO.SOHIEU = item.SOHIEU;
                cbDTO.HOTEN = item.HOTEN;
                cbDTO.GIOITINH = item.GIOITINH;
                cbDTO.NGAYSINH = item.NGAYSINH;
                cbDTO.DIENTHOAI = item.DIENTHOAI;
                cbDTO.CCCD = item.CCCD;
                cbDTO.DIACHI = item.DIACHI;
                cbDTO.HINHANH = item.HINHANH;
                cbDTO.THOIVIEC = item.DATHOIVIEC;

                cbDTO.MAPHONG = item.MAPHONG;
                var dv = db.tb_DONVI.FirstOrDefault(b=>b.MAPHONG == item.MAPHONG);
                cbDTO.TENPHONG = dv.TENPHONG;

                cbDTO.MACV = item.MACV;
                var cv = db.tb_CHUCVU.FirstOrDefault(b => b.MACV == item.MACV);
                cbDTO.TENCHUCVU = cv.TENCHUCVU;

                cbDTO.MATD = item.MATD;
                var td = db.tb_TRINHDO.FirstOrDefault(b => b.MATD == item.MATD);
                cbDTO.TENTRINHDO = td.TENTRINHDO;

                cbDTO.MADT = item.MADT;
                var dt = db.tb_DANTOC.FirstOrDefault(b => b.ID == item.MADT);
                cbDTO.TENDT = dt.TENDT;

                cbDTO.MATG= item.MATG;
                var tg = db.tb_TONGIAO.FirstOrDefault(b => b.ID == item.MATG);
                cbDTO.TENTG= tg.TENTG;

                cbDTO.MACD = item.MACD;
                var cd = db.tb_CHUCDANH.FirstOrDefault(b => b.MACD == item.MACD);
                cbDTO.TENCHUCDANH = cd.TENCHUCDANH;

                cbDTO.MABH = item.MABH;
                var bh = db.tb_BAOHIEM.FirstOrDefault(b => b.MABH == item.MABH);
                if (bh != null)
                {
                    cbDTO.SOBH = bh.SOBH;
                }
                else
                {
                    cbDTO.SOBH = "Chưa cấp";
                }

                cbDTO.MACH = item.MACH;
                var ch = db.tb_CAPHAM.FirstOrDefault(b => b.MACH == item.MACH);
                cbDTO.TENCAPHAM = ch.TENCAPHAM;

                lstCBDTO.Add(cbDTO);

            }
            return lstCBDTO;
        }
        public tb_CANBO Add(tb_CANBO dt)
        {
            try
            {
                db.tb_CANBO.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_CANBO Update(tb_CANBO dt)
        {
            try
            {
                var _dt = db.tb_CANBO.FirstOrDefault(x => x.MACB == dt.MACB);
                _dt.SOHIEU = dt.SOHIEU;
                _dt.HOTEN = dt.HOTEN;
                _dt.GIOITINH = dt.GIOITINH;
                _dt.NGAYSINH = dt.NGAYSINH;
                _dt.DIENTHOAI = dt.DIENTHOAI;
                _dt.CCCD = dt.CCCD;
                _dt.DIACHI = dt.DIACHI;
                _dt.HINHANH = dt.HINHANH;
                _dt.MAPHONG = dt.MAPHONG;
                _dt.MACV = dt.MACV;
                _dt.MATD = dt.MATD;
                _dt.MADT = dt.MADT;
                _dt.MATG = dt.MATG;
                _dt.MACD = dt.MACD;
                _dt.MACH = dt.MACH;
                _dt.MABH = dt.MABH;
                _dt.DATHOIVIEC = dt.DATHOIVIEC;
                db.SaveChanges();
                return dt;
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
                var _dt = db.tb_CANBO.FirstOrDefault(x => x.MACB == id);
                db.tb_CANBO.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public List<tb_CANBO> getSinhNhat()
        {
            return db.tb_CANBO.Where(x=>x.NGAYSINH.Value.Month==DateTime.Now.Month).ToList();
        }
    }
}
