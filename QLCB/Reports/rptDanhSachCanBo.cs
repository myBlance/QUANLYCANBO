using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLCB.Reports
{
    public partial class rptDanhSachCanBo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachCanBo()
        {
            InitializeComponent();
        }
        List<CANBO_DTO> _lstCB;
        public rptDanhSachCanBo(List<CANBO_DTO> lstCB)
        {
            InitializeComponent();
            this._lstCB = lstCB;
            this.DataSource = _lstCB;
            loadData();
        }
        void loadData()
        {
            lblMaCB.DataBindings.Add("Text", _lstCB, "MACB");
            lblSoHieu.DataBindings.Add("Text", _lstCB, "SOHIEU");
            lblHoTen.DataBindings.Add("Text", _lstCB, "HOTEN");
            lblGioiTinh.DataBindings.Add("Text", _lstCB, "GIOITINH");
            lblNgaySinh.DataBindings.Add("Text", _lstCB, "NGAYSINH");
            lblDonVi.DataBindings.Add("Text", _lstCB, "TENPHONG");
            lblChucVu.DataBindings.Add("Text", _lstCB, "TENCHUCVU");
            lblTrinhDo.DataBindings.Add("Text", _lstCB, "TENTRINHDO");
            lblChucDanh.DataBindings.Add("Text", _lstCB, "TENCHUCDANH");
            lblCapHam.DataBindings.Add("Text", _lstCB, "TENCAPHAM");

        }
    }
}
