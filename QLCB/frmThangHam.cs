using DataLayer;
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
using BusinessLayer;
using QLCB.Reports;
using BusinessLayer.DTO;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace QLCB
{
    public partial class frmThangHam : DevExpress.XtraEditors.XtraForm
    {
        public frmThangHam()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD;
        THANGHAM _th;
        CANBO _canbo;
        CAPBACHAM _capbacham;
        private void frmThangHam_Load(object sender, EventArgs e)
        {
            _th = new THANGHAM();
            _canbo = new CANBO();
            _capbacham = new CAPBACHAM();
            _them = false;
            _showHide(true);
            loadCanBo();
            loadCapHamLen();
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
            txtLyDo.Enabled = !kt;
            dtNgay.Enabled = !kt;
            dtNgayLenTiep.Enabled = !kt;
            slkCanBo.Enabled = !kt;
            cboCapHamLen.Enabled = !kt;
        }
        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            dtNgay.Value = DateTime.Now;
            dtNgayLenTiep.Value = DateTime.Now;

        }
        void loadCanBo()
        {
            slkCanBo.Properties.DataSource = _canbo.getList();
            slkCanBo.Properties.ValueMember = "MACB";
            slkCanBo.Properties.DisplayMember = "HOTEN";
        }
        void loadCapHamLen() 
        { 
            cboCapHamLen.DataSource = _capbacham.getList();
            cboCapHamLen.DisplayMember = "TENCAPHAM";
            cboCapHamLen.ValueMember = "MACH";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _th.getListFull();
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
                _th.Delete(_soQD, 1);
                tb_LENHAM th = _th.getItem(_soQD);
                var cb = _canbo.getItem(th.MACB.Value);
                cb.MACH = th.MACH;
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
            tb_LENHAM dc;
            if (_them)
            {
                //Số QĐ có dạng: 01/QĐ-T07
                var maxSoQD = _th.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 2)) + 1;

                dc = new tb_LENHAM();
                dc.SOQD = so.ToString("00") + @"/QĐ-T07";
                dc.LYDO = txtLyDo.Text;
                dc.NGAY = dtNgay.Value;
                dc.NGAYTIEPTHEO = dtNgayLenTiep.Value;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.MACH = _canbo.getItem(int.Parse(slkCanBo.EditValue.ToString())).MACH;
                dc.MACH2 = int.Parse(cboCapHamLen.SelectedValue.ToString());
                dc.CREATED_BY = 1;
                dc.CREATED_DATE = DateTime.Now;
                _th.Add(dc);

            }
            else
            {
                dc = _th.getItem(_soQD);
                dc.LYDO = txtLyDo.Text;
                dc.NGAY = dtNgay.Value;
                dc.NGAYTIEPTHEO = dtNgayLenTiep.Value;
                dc.MACB = int.Parse(slkCanBo.EditValue.ToString());
                dc.MACH2 = int.Parse(cboCapHamLen.SelectedValue.ToString());
                dc.UPDATED_BY = 1;
                dc.UPDATED_DATE = DateTime.Now;
                _th.Update(dc);
            }
            var cb = _canbo.getItem(dc.MACB.Value);
            cb.MACH = dc.MACH2;
            _canbo.Update(cb);
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var dc = _th.getItem(_soQD);
                txtSoQD.Text = _soQD;
                txtLyDo.Text = dc.LYDO;
                dtNgay.Value = dc.NGAY.Value;
                dtNgayLenTiep.Value = dc.NGAYTIEPTHEO.Value;
                slkCanBo.EditValue = dc.MACB;
                cboCapHamLen.SelectedValue = dc.MACH2;
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