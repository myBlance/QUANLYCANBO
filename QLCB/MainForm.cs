using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;

namespace QLCB
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        void openForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }    
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        CANBO _canbo;
        THANGHAM _thangham;
        bool ktThoat = true;

        private void btnDanToc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDanToc));
        }

        private void btnTonGiao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTonGiao));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _canbo = new CANBO();
            _thangham = new THANGHAM();
            ribbonControl1.SelectedPage = ribbonPage2;
            loadSinhNhat();
            loadLenLuong();
        }
        void loadSinhNhat()
        {
            lstSinhNhat.DataSource = _canbo.getSinhNhat();
            lstSinhNhat.DisplayMember = "HOTEN";
            lstSinhNhat.ValueMember = "MACB";
        }
        void loadLenLuong()
        {
            lstLenHam.DataSource = _thangham.getLenLuong();
            lstLenHam.DisplayMember = "HOTEN";
            lstLenHam.ValueMember = "MACB";
        }

        private void btnTrinhDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTrinhDo));
        }

        private void btnCapBacHam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmCapBacHam));
        }

        private void btnDonVi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDonVi));
        }

        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmChucVu));
        }

        private void btnCanBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmCanBo));
        }

        private void btnThangHam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmThangHam));
        }

        private void btnChucDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmChucDanh));
        }

        private void btnKhenThuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKhenThuong));
        }

        private void btnKyLuatne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKyLuat));
        }

        private void btnDieuChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDieuChuyen));
        }

        private void btnThoiViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmThoiViec));
        }

        private void btnBaoHiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmBaoHiem));
        }
        private void lstSinhNhat_CustomizeItem(object sender, DevExpress.XtraEditors.CustomizeTemplatedItemEventArgs e)
        {
            if (e.TemplatedItem.Elements[1].Text.Substring(0,2) == DateTime.Now.Day.ToString())
            {
                e.TemplatedItem.AppearanceItem.Normal.ForeColor = Color.Red;
            }    
        }

        private void btnQuanLyTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmQuanLyTaiKhoan));
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ktThoat = false;
            this.Close();
            frmDangNhap f = new frmDangNhap();
            f.Show(); 
             
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(ktThoat)
            {
                Application.Exit();
            }    
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ktThoat)
                
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }    
        }
    }
}
