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
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static System.Windows.Forms.ImageList;
using DevExpress.Utils;

namespace QLCB
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        TAIKHOAN _tk;
        public static string ID_USER = "";
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            _tk = new TAIKHOAN();
            txtTaiKhoan.Text = Properties.Settings.Default.taikhoan;
            txtMatKhau.Text = Properties.Settings.Default.matkhau;
            if (Properties.Settings.Default.taikhoan != "")
            {
                chkNhoMK.Checked = true;
            }    
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ID_USER = _tk.KiemTraTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
            if (ID_USER != "")
            {
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !","Cảnh báo", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkNhoMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "")
            {
                if (chkNhoMK.Checked == true) 
                {
                    string users = txtTaiKhoan.Text;
                    string pwd = txtMatKhau.Text;
                    Properties.Settings.Default.taikhoan = users;
                    Properties.Settings.Default.matkhau = pwd;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }    
            }    
        }
    }
}