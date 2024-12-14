using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using QLCB.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.Model;

namespace QLCB
{
    public partial class frmCanBo : DevExpress.XtraEditors.XtraForm
    {
        public frmCanBo()
        {
            InitializeComponent();
        }
        private CANBO _canbo;
        private DANTOC _dantoc;
        private TONGIAO _TONGIAO;
        private CHUCVU _CHUCVU;
        private DONVI _DONVI;
        private TRINHDO _TRINHDO;
        private CHUCDANH _chucdanh;
        private CAPBACHAM _capham;
        private BAOHIEM _baohiem;
        private bool _them;
        private int _id;
        List<CANBO_DTO> _lstCBDTO;
        private void frmCanBo_Load(object sender, EventArgs e)
        {
            _them = false;
            _canbo = new CANBO();
            _dantoc = new DANTOC();
            _TONGIAO = new TONGIAO();
            _CHUCVU = new CHUCVU();
            _DONVI = new DONVI();
            _TRINHDO = new TRINHDO();
            _chucdanh = new CHUCDANH();
            _capham = new CAPBACHAM();
            _baohiem = new BAOHIEM();
            _showHide(true);
            loadData();
            loadCombo();
            boxTimKiem.Client = gcDanhSach;
        }
        void loadCombo()
        {
            cboDonVi.DataSource = _DONVI.getList();
            cboDonVi.DisplayMember = "TENPHONG";
            cboDonVi.ValueMember = "MAPHONG";

            cboChucVu.DataSource = _CHUCVU.getList();
            cboChucVu.DisplayMember = "TENCHUCVU";
            cboChucVu.ValueMember = "MACV";

            cboTrinhDo.DataSource = _TRINHDO.getList();
            cboTrinhDo.DisplayMember = "TENTRINHDO";
            cboTrinhDo.ValueMember = "MATD";

            cboDanToc.DataSource = _dantoc.getList();
            cboDanToc.DisplayMember = "TENDT";
            cboDanToc.ValueMember = "ID";

            cboTonGiao.DataSource = _TONGIAO.getList();
            cboTonGiao.DisplayMember = "TENTG";
            cboTonGiao.ValueMember = "ID";

            cboChucDanh.DataSource = _chucdanh.getList();
            cboChucDanh.DisplayMember = "TENCHUCDANH";
            cboChucDanh.ValueMember = "MACD";

            cboCapHam.DataSource = _capham.getList();
            cboCapHam.DisplayMember = "TENCAPHAM";
            cboCapHam.ValueMember = "MACH";
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtSoHieu.Enabled = !kt;
            txtHoTen.Enabled = !kt;
            chkGioiTinh.Enabled = !kt;
            dtNgaySinh.Enabled = !kt;
            txtDienThoai.Enabled = !kt;
            txtCCCD.Enabled = !kt;
            txtDiaChi.Enabled = !kt;
            //picHinhAnh.Enabled = !kt;
            cboDonVi.Enabled = !kt;
            cboChucVu.Enabled = !kt;
            cboTrinhDo.Enabled = !kt;
            cboDanToc.Enabled = !kt;
            cboTonGiao.Enabled = !kt;
            btnHinhAnh.Enabled = !kt;
            cboCapHam.Enabled = !kt;
            cboChucDanh.Enabled = !kt;
        }
        void _reset()
        {
            txtSoHieu.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            chkGioiTinh.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _canbo.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstCBDTO = _canbo.getListFull();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xoá hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _canbo.Delete(_id);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDanhSachCanBo rpt = new rptDanhSachCanBo(_lstCBDTO);
            rpt.ShowRibbonPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                tb_CANBO dt = new tb_CANBO();
                dt.SOHIEU = txtSoHieu.Text;
                dt.HOTEN = txtHoTen.Text;
                dt.GIOITINH = chkGioiTinh.Checked;
                dt.NGAYSINH = dtNgaySinh.Value;
                dt.DIENTHOAI = txtDienThoai.Text;
                dt.CCCD = txtCCCD.Text;
                dt.DIACHI = txtDiaChi.Text;
                dt.HINHANH = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                dt.MAPHONG = int.Parse(cboDonVi.SelectedValue.ToString());
                dt.MACV = int.Parse(cboDonVi.SelectedValue.ToString());
                dt.MATD = int.Parse(cboTrinhDo.SelectedValue.ToString());
                dt.MADT = int.Parse(cboDanToc.SelectedValue.ToString());
                dt.MATG = int.Parse(cboTonGiao.SelectedValue.ToString());
                dt.MACD = int.Parse(cboChucDanh.SelectedValue.ToString());
                dt.MACH = int.Parse((cboCapHam.SelectedValue).ToString());
                _canbo.Add(dt);
            }
            else
            {
                var dt = _canbo.getItem(_id);
                dt.SOHIEU = txtSoHieu.Text;
                dt.HOTEN = txtHoTen.Text;
                dt.GIOITINH = chkGioiTinh.Checked;
                dt.NGAYSINH = dtNgaySinh.Value;
                dt.DIENTHOAI = txtDienThoai.Text;
                dt.CCCD = txtCCCD.Text;
                dt.DIACHI = txtDiaChi.Text;
                dt.HINHANH = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                dt.MAPHONG = int.Parse(cboDonVi.SelectedValue.ToString());
                dt.MACV = int.Parse(cboDonVi.SelectedValue.ToString());
                dt.MATD = int.Parse(cboTrinhDo.SelectedValue.ToString());
                dt.MADT = int.Parse(cboDanToc.SelectedValue.ToString());
                dt.MATG = int.Parse(cboTonGiao.SelectedValue.ToString());
                dt.MACD = int.Parse(cboChucDanh.SelectedValue.ToString());
                dt.MACH = int.Parse((cboCapHam.SelectedValue).ToString());
                _canbo.Update(dt);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MACB").ToString());
                var dt = _canbo.getItem(_id);
                txtSoHieu.Text = dt.SOHIEU;
                txtHoTen.Text = dt.HOTEN;
                chkGioiTinh.Checked = dt.GIOITINH.Value;
                dtNgaySinh.Value = dt.NGAYSINH.Value;
                txtDienThoai.Text = dt.DIENTHOAI;
                txtCCCD.Text = dt.CCCD;
                txtDiaChi.Text = dt.DIACHI;
                picHinhAnh.Image = Base64ToImage(dt.HINHANH);
                cboDonVi.SelectedValue = dt.MAPHONG;
                cboChucVu.SelectedValue = dt.MACV;
                cboTrinhDo.SelectedValue = dt.MATD;
                cboDanToc.SelectedValue = dt.MADT;
                cboTonGiao.SelectedValue = dt.MATG;
                cboCapHam.SelectedValue = dt.MACH;
                cboChucDanh.SelectedValue = dt.MACD;
                
            }
        }
        //Hàm chuyển ảnh vào database
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(openFile.FileName);
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }    

        }

        bool indicatorIcon = true;
        private void gvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 5;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        private void gvDanhSach_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 15;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}