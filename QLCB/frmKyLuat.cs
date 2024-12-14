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
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace QLCB
{
    public partial class frmKyLuat : DevExpress.XtraEditors.XtraForm
    {
        public frmKyLuat()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD;
        KYLUAT _ktkl;
        CANBO _canbo;
        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            _ktkl = new KYLUAT();
            _canbo = new CANBO();
            _them = false;
            _showHide(true);
            loadCanBo();
            loadData();
            splitContainer1.Panel1Collapsed = true;
            boxTimKiem.Client = gcDanhSach;
        }
        private void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtSoQD.Enabled = !kt;
            txtNoiDung.Enabled = !kt;
            txtLyDo.Enabled = !kt;
            dtNgay.Enabled = !kt;
            dtTuNgay.Enabled = !kt;
            dtDenNgay.Enabled = !kt;
            slkCanBo.Enabled = !kt;
        }
        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
        }
        void loadCanBo()
        {
            slkCanBo.Properties.DataSource = _canbo.getList();
            slkCanBo.Properties.ValueMember = "MACB";
            slkCanBo.Properties.DisplayMember = "HOTEN";
        }
        private void loadData()
        {
            gcDanhSach.DataSource = _ktkl.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xoá hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ktkl.Delete(_soQD, 1);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                //Số QĐ có dạng: 01/QĐ-T07
                var maxSoQD = _ktkl.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 2)) + 1;

                tb_KYLUAT kt = new tb_KYLUAT();
                kt.SOQD = so.ToString("00") + @"/QĐ-T07";
                kt.LYDO = txtLyDo.Text;
                kt.NGAY = dtNgay.Value;
                kt.TUNGAY = dtTuNgay.Value;
                kt.DENNGAY = dtDenNgay.Value;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.MACB = int.Parse(slkCanBo.EditValue.ToString());
                kt.LOAI = 1;
                kt.CREATED_BY = 1;
                kt.CREATED_DATE = DateTime.Now;
                _ktkl.Add(kt);

            }
            else
            {
                var kt = _ktkl.getItem(_soQD);
                kt.NGAY = dtNgay.Value;
                kt.TUNGAY = dtTuNgay.Value;
                kt.DENNGAY = dtDenNgay.Value;
                kt.LYDO = txtLyDo.Text;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.MACB = int.Parse(slkCanBo.EditValue.ToString());
                kt.UPDATED_BY = 1;
                kt.UPDATED_DATE = DateTime.Now;
                _ktkl.Update(kt);
            }
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var kt = _ktkl.getItem(_soQD);
                txtNoiDung.Text = kt.NOIDUNG;
                txtLyDo.Text = kt.LYDO;
                dtDenNgay.Value = kt.DENNGAY.Value;
                dtTuNgay.Value= kt.TUNGAY.Value;
                dtNgay.Value = kt.NGAY.Value;
                slkCanBo.EditValue = kt.MACB;
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
            {
                Image img = Properties.Resources.delete1;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
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
    }
}