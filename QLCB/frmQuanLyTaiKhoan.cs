using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using System.Security.Cryptography;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace QLCB
{
    public partial class frmQuanLyTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        int _id;
        bool _them;
        TAIKHOAN _tk;
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            _them = false;
            _tk = new TAIKHOAN();
            _showHide(true);
            loadData();
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
            txtTaiKhoan.Enabled = !kt;
            txtMatKhau.Hide();
            txtMatKhauCu.Hide();

            lblMatKhauCu.Hide();
            lblMatKhau.Hide();
            lblMatKhauMoi.Hide();
        }
        void loadData()
        {
            gcDanhSach.DataSource = _tk.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            lblMatKhau.Visible = true;
            txtMatKhau.Visible = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            txtMatKhau.Text = string.Empty;
            txtMatKhauCu.Text = string.Empty;
            lblMatKhauMoi.Visible = true;
            txtMatKhau.Visible = true;
            lblMatKhauCu.Visible = true;
            txtMatKhauCu.Visible = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xoá hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string taikhoan = txtTaiKhoan.Text; // Lấy tên người dùng từ TextBox

                // Gọi hàm DeleteAccount từ lớp Business Layer
                TAIKHOAN tk = new TAIKHOAN();
                bool _tk = tk.XoaTaiKhoan(taikhoan);

                if (_tk)
                {
                    MessageBox.Show("Xoá tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể xoá tài khoản. Tài khoản không tồn tại hoặc có lỗi xảy ra!");
                }
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
        void SaveData()
        {
            if (_them)
            {
                string taikhoan = txtTaiKhoan.Text;
                string matkhau = txtMatKhau.Text;

                // Gọi hàm AddAccount từ lớp Business Layer
                TAIKHOAN tk = new TAIKHOAN();
                bool _tao = tk.ThemTaiKhoan(taikhoan, matkhau);

                if (_tao)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể thêm tài khoản. Tài khoản đã tồn tại hoặc có lỗi xảy ra!");
                }
                loadData();
            }
            else
            {
                string taikhoan = txtTaiKhoan.Text;
                string matkhaumoi = txtMatKhauCu.Text;
                string matkhaucu = txtMatKhau.Text;

                // Gọi hàm Changematkhau từ lớp Business Layer
                TAIKHOAN tk = new TAIKHOAN();
                bool _thay = tk.DoiMatKhau(taikhoan, matkhaucu, matkhaumoi);

                if (_thay)
                {
                    MessageBox.Show("Sửa tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể sửa tài khoản. Tài khoản không tồn tại hoặc có lỗi xảy ra!");
                }
                loadData();
            }
        }
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("id").ToString());
                txtTaiKhoan.Text = gvDanhSach.GetFocusedRowCellValue("taikhoan").ToString();
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
    }
}