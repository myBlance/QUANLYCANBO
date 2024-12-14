using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace QLCB
{
    public partial class frmThoiViec : DevExpress.XtraEditors.XtraForm
    {
        public frmThoiViec()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD;
        THOIVIEC _tv;
        CANBO _canbo;
        private void frmThoiViec_Load(object sender, EventArgs e)
        {
            _tv = new THOIVIEC();
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
            txtGhiChu.Enabled = !kt;
            txtLyDo.Enabled = !kt;
            dtNgayNopDon.Enabled = !kt;
            dtNgayNghi.Enabled = !kt;
            slkCanBo.Enabled = !kt;
        }
        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dtNgayNopDon.Value = DateTime.Now;
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(45);
        }
        void loadCanBo()
        {
            slkCanBo.Properties.DataSource = _canbo.getList();
            slkCanBo.Properties.ValueMember = "MACB";
            slkCanBo.Properties.DisplayMember = "HOTEN";
        }
        private void loadData()
        {
            gcDanhSach.DataSource = _tv.getListFull();
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
                _tv.Delete(_soQD, 1);
                tb_THOIVIEC tv = _tv.getItem(_soQD);
                var cb = _canbo.getItem(tv.MACB.Value);
                cb.DATHOIVIEC = null;
                _canbo.Update(cb);
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
            tb_THOIVIEC dc;
            if (_them)
            {
                //Số QĐ có dạng: 01/QĐ-T07
                var maxSoQD = _tv.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 2)) + 1;

                dc = new tb_THOIVIEC();
                dc.SOQD = so.ToString("00") + @"/QĐ-T07";
                dc.LYDO = txtLyDo.Text;
                dc.NGAYNOPDON = dtNgayNopDon.Value;
                dc.NGAYNGHI = dtNgayNghi.Value;
                dc.GHICHU = txtGhiChu.Text;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.CREATED_BY = 1;
                dc.CREATED_DATE = DateTime.Now;
                _tv.Add(dc);

            }
            else
            {
                dc = _tv.getItem(_soQD);
                dc.LYDO = txtLyDo.Text;
                dc.NGAYNOPDON = dtNgayNopDon.Value;
                dc.NGAYNGHI = dtNgayNghi.Value;
                dc.GHICHU = txtGhiChu.Text;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.UPDATED_BY = 1;
                dc.UPDATED_DATE = DateTime.Now;
                _tv.Update(dc);
            }
            var cb = _canbo.getItem(dc.MACB.Value);
            cb.DATHOIVIEC = true;
            _canbo.Update(cb);
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var dc = _tv.getItem(_soQD);
                txtSoQD.Text = _soQD;
                txtGhiChu.Text = dc.GHICHU;
                txtLyDo.Text = dc.LYDO;
                dtNgayNopDon.Value = dc.NGAYNOPDON.Value;
                dtNgayNghi.Value = dc.NGAYNGHI.Value;
                slkCanBo.EditValue = dc.MACB;
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

        private void dtNgayNopDon_ValueChanged(object sender, EventArgs e)
        {
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(45);
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