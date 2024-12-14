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

namespace QLCB
{
    public partial class frmBaoHiem : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoHiem()
        {
            InitializeComponent();
        }
        bool _them;
        int _soBH;
        BAOHIEM _bh;
        CANBO _canbo;
        private void frmBaoHiem_Load(object sender, EventArgs e)
        {
            _bh = new BAOHIEM();
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
            txtSoBH.Enabled = !kt;
            txtNoiCap.Enabled = !kt;
            txtNoiKham.Enabled = !kt;
            dtNgayCap.Enabled = !kt;
            dtNgayHetHan.Enabled = !kt;
            slkCanBo.Enabled = !kt;
        }
        private void _reset()
        {
            txtSoBH.Text = string.Empty;
            txtNoiCap.Text = string.Empty;
            txtNoiKham.Text = string.Empty;
            dtNgayCap.Value = DateTime.Now;
            dtNgayHetHan.Value = dtNgayCap.Value.AddDays(1825);
        }
        void loadCanBo()
        {
            slkCanBo.Properties.DataSource = _canbo.getList();
            slkCanBo.Properties.ValueMember = "MACB";
            slkCanBo.Properties.DisplayMember = "HOTEN";
        }
        private void loadData()
        {
            gcDanhSach.DataSource = _bh.getListFull();
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
                _bh.Delete(_soBH, 1);
                tb_BAOHIEM tv = _bh.getItem(_soBH);
                var cb = _canbo.getItem(tv.MACB.Value);
                cb.MABH = null;
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
            tb_BAOHIEM dc;
            if (_them)
            {
                dc = new tb_BAOHIEM();
                dc.SOBH = txtSoBH.Text;
                dc.NOICAP = txtNoiCap.Text;
                dc.NOIKHAMBENH = txtNoiKham.Text;
                dc.NGAYCAP = dtNgayCap.Value;
                dc.NGAYHETHAN = dtNgayHetHan.Value;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.CREATED_BY = 1;
                dc.CREATED_DATE = DateTime.Now;
                _bh.Add(dc);

            }
            else
            {
                dc = _bh.getItem(_soBH);
                dc.SOBH = txtSoBH.Text;
                dc.NOICAP = txtNoiCap.Text;
                dc.NOIKHAMBENH = txtNoiKham.Text;
                dc.NGAYCAP = dtNgayCap.Value;
                dc.NGAYHETHAN = dtNgayHetHan.Value;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.UPDATED_BY = 1;
                dc.UPDATED_DATE = DateTime.Now;
                _bh.Update(dc);
            }
            var cb = _canbo.getItem(dc.MACB.Value);
            cb.MABH = dc.MABH;
            _canbo.Update(cb);
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soBH = int.Parse(gvDanhSach.GetFocusedRowCellValue("MABH").ToString());
                var dc = _bh.getItem(_soBH);
                txtSoBH.Text = dc.SOBH;
                txtNoiCap.Text = dc.NOICAP;
                txtNoiKham.Text = dc.NOIKHAMBENH;
                dtNgayCap.Value = dc.NGAYCAP.Value;
                dtNgayHetHan.Value = dc.NGAYHETHAN.Value;
                slkCanBo.EditValue = dc.MACB;
            }
        }

        private void dtNgayCap_ValueChanged(object sender, EventArgs e)
        {
            dtNgayHetHan.Value = dtNgayCap.Value.AddDays(1825);
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