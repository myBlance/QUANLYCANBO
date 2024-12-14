namespace QLCB
{
    partial class frmBaoHiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoHiem));
            this.slkCanBo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnDong = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SOHIEU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoiCap = new DevExpress.XtraEditors.TextEdit();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DELETED_BY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOBH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MACB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYCAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYHETHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOICAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOIKHAMBENH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.boxTimKiem = new DevExpress.XtraEditors.SearchControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoBH = new DevExpress.XtraEditors.TextEdit();
            this.dtNgayCap = new System.Windows.Forms.DateTimePicker();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoiKham = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.slkCanBo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoBH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiKham.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // slkCanBo
            // 
            this.slkCanBo.Location = new System.Drawing.Point(525, 119);
            this.slkCanBo.Margin = new System.Windows.Forms.Padding(4);
            this.slkCanBo.MenuManager = this.barManager1;
            this.slkCanBo.Name = "slkCanBo";
            this.slkCanBo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.slkCanBo.Properties.Appearance.Options.UseFont = true;
            this.slkCanBo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkCanBo.Properties.PopupView = this.searchLookUpEdit1View;
            this.slkCanBo.Size = new System.Drawing.Size(280, 28);
            this.slkCanBo.TabIndex = 35;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnHuy,
            this.btnDong,
            this.btnIn});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDong, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Huỷ";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In";
            this.btnIn.Id = 6;
            this.btnIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIn.ImageOptions.SvgImage")));
            this.btnIn.Name = "btnIn";
            this.btnIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIn_ItemClick);
            // 
            // btnDong
            // 
            this.btnDong.Caption = "Đóng";
            this.btnDong.Id = 5;
            this.btnDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDong.ImageOptions.SvgImage")));
            this.btnDong.Name = "btnDong";
            this.btnDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDong_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(962, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 565);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(962, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 535);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(962, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 535);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SOHIEU,
            this.colHOTEN});
            this.searchLookUpEdit1View.DetailHeight = 431;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 933;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // SOHIEU
            // 
            this.SOHIEU.Caption = "SỐ HIỆU";
            this.SOHIEU.FieldName = "SOHIEU";
            this.SOHIEU.MaxWidth = 58;
            this.SOHIEU.MinWidth = 58;
            this.SOHIEU.Name = "SOHIEU";
            this.SOHIEU.Visible = true;
            this.SOHIEU.VisibleIndex = 0;
            this.SOHIEU.Width = 58;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Caption = "HỌ TÊN";
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MaxWidth = 233;
            this.colHOTEN.MinWidth = 233;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 233;
            // 
            // dtNgayHetHan
            // 
            this.dtNgayHetHan.CustomFormat = "";
            this.dtNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayHetHan.Location = new System.Drawing.Point(690, 71);
            this.dtNgayHetHan.Margin = new System.Windows.Forms.Padding(4);
            this.dtNgayHetHan.Name = "dtNgayHetHan";
            this.dtNgayHetHan.Size = new System.Drawing.Size(115, 28);
            this.dtNgayHetHan.TabIndex = 34;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(576, 75);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(98, 21);
            this.labelControl6.TabIndex = 33;
            this.labelControl6.Text = "Ngày hết hạn";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(28, 123);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(55, 21);
            this.labelControl7.TabIndex = 26;
            this.labelControl7.Text = "Nơi cấp";
            // 
            // txtNoiCap
            // 
            this.txtNoiCap.Location = new System.Drawing.Point(102, 119);
            this.txtNoiCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoiCap.MenuManager = this.barManager1;
            this.txtNoiCap.Name = "txtNoiCap";
            this.txtNoiCap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNoiCap.Properties.Appearance.Options.UseFont = true;
            this.txtNoiCap.Size = new System.Drawing.Size(332, 28);
            this.txtNoiCap.TabIndex = 25;
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DELETED_BY,
            this.SOBH,
            this.MACB,
            this.HOTEN,
            this.NGAYCAP,
            this.NGAYHETHAN,
            this.NOICAP,
            this.NOIKHAMBENH});
            this.gvDanhSach.DetailHeight = 431;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsEditForm.PopupEditFormWidth = 933;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDanhSach_CustomDrawRowIndicator);
            this.gvDanhSach.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvDanhSach_CustomDrawCell);
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            this.gvDanhSach.RowCountChanged += new System.EventHandler(this.gvDanhSach_RowCountChanged);
            // 
            // DELETED_BY
            // 
            this.DELETED_BY.Caption = "DEL";
            this.DELETED_BY.FieldName = "DELETED_BY";
            this.DELETED_BY.MaxWidth = 30;
            this.DELETED_BY.MinWidth = 30;
            this.DELETED_BY.Name = "DELETED_BY";
            this.DELETED_BY.Visible = true;
            this.DELETED_BY.VisibleIndex = 0;
            this.DELETED_BY.Width = 30;
            // 
            // SOBH
            // 
            this.SOBH.Caption = "SỐ THẺ";
            this.SOBH.FieldName = "SOBH";
            this.SOBH.MaxWidth = 117;
            this.SOBH.MinWidth = 117;
            this.SOBH.Name = "SOBH";
            this.SOBH.Visible = true;
            this.SOBH.VisibleIndex = 1;
            this.SOBH.Width = 117;
            // 
            // MACB
            // 
            this.MACB.Caption = "MACB";
            this.MACB.FieldName = "MACB";
            this.MACB.MinWidth = 23;
            this.MACB.Name = "MACB";
            this.MACB.Width = 87;
            // 
            // HOTEN
            // 
            this.HOTEN.Caption = "HỌ TÊN";
            this.HOTEN.FieldName = "HOTEN";
            this.HOTEN.MaxWidth = 140;
            this.HOTEN.MinWidth = 140;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Visible = true;
            this.HOTEN.VisibleIndex = 2;
            this.HOTEN.Width = 140;
            // 
            // NGAYCAP
            // 
            this.NGAYCAP.Caption = "NGÀY CẤP";
            this.NGAYCAP.FieldName = "NGAYCAP";
            this.NGAYCAP.MaxWidth = 93;
            this.NGAYCAP.MinWidth = 93;
            this.NGAYCAP.Name = "NGAYCAP";
            this.NGAYCAP.Visible = true;
            this.NGAYCAP.VisibleIndex = 3;
            this.NGAYCAP.Width = 93;
            // 
            // NGAYHETHAN
            // 
            this.NGAYHETHAN.Caption = "NGÀY HẾT HẠN";
            this.NGAYHETHAN.FieldName = "NGAYHETHAN";
            this.NGAYHETHAN.MaxWidth = 93;
            this.NGAYHETHAN.MinWidth = 93;
            this.NGAYHETHAN.Name = "NGAYHETHAN";
            this.NGAYHETHAN.Visible = true;
            this.NGAYHETHAN.VisibleIndex = 5;
            this.NGAYHETHAN.Width = 93;
            // 
            // NOICAP
            // 
            this.NOICAP.Caption = "NƠI CẤP";
            this.NOICAP.FieldName = "NOICAP";
            this.NOICAP.MaxWidth = 175;
            this.NOICAP.MinWidth = 175;
            this.NOICAP.Name = "NOICAP";
            this.NOICAP.Visible = true;
            this.NOICAP.VisibleIndex = 4;
            this.NOICAP.Width = 175;
            // 
            // NOIKHAMBENH
            // 
            this.NOIKHAMBENH.Caption = "NƠI KHÁM CHỮA BỆNH";
            this.NOIKHAMBENH.FieldName = "NOIKHAMBENH";
            this.NOIKHAMBENH.MaxWidth = 175;
            this.NOIKHAMBENH.MinWidth = 175;
            this.NOIKHAMBENH.Name = "NOIKHAMBENH";
            this.NOIKHAMBENH.Visible = true;
            this.NOIKHAMBENH.VisibleIndex = 6;
            this.NOIKHAMBENH.Width = 175;
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcDanhSach.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.gcDanhSach.MenuManager = this.barManager1;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(962, 314);
            this.gcDanhSach.TabIndex = 0;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelControl14);
            this.splitContainer1.Panel1.Controls.Add(this.boxTimKiem);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoBH);
            this.splitContainer1.Panel1.Controls.Add(this.slkCanBo);
            this.splitContainer1.Panel1.Controls.Add(this.dtNgayHetHan);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainer1.Panel1.Controls.Add(this.dtNgayCap);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.txtNoiKham);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainer1.Panel1.Controls.Add(this.txtNoiCap);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Tahoma", 10F);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcDanhSach);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.splitContainer1.Size = new System.Drawing.Size(962, 535);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(171, 26);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(77, 21);
            this.labelControl14.TabIndex = 39;
            this.labelControl14.Text = "Tìm kiếm";
            // 
            // boxTimKiem
            // 
            this.boxTimKiem.Location = new System.Drawing.Point(266, 22);
            this.boxTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.boxTimKiem.MenuManager = this.barManager1;
            this.boxTimKiem.Name = "boxTimKiem";
            this.boxTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.boxTimKiem.Properties.Appearance.Options.UseFont = true;
            this.boxTimKiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.boxTimKiem.Size = new System.Drawing.Size(429, 28);
            this.boxTimKiem.TabIndex = 38;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(28, 75);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(120, 21);
            this.labelControl4.TabIndex = 37;
            this.labelControl4.Text = "Số thẻ bảo hiểm";
            // 
            // txtSoBH
            // 
            this.txtSoBH.Location = new System.Drawing.Point(152, 71);
            this.txtSoBH.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoBH.MenuManager = this.barManager1;
            this.txtSoBH.Name = "txtSoBH";
            this.txtSoBH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSoBH.Properties.Appearance.Options.UseFont = true;
            this.txtSoBH.Size = new System.Drawing.Size(191, 28);
            this.txtSoBH.TabIndex = 36;
            // 
            // dtNgayCap
            // 
            this.dtNgayCap.CustomFormat = "";
            this.dtNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayCap.Location = new System.Drawing.Point(441, 71);
            this.dtNgayCap.Margin = new System.Windows.Forms.Padding(4);
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(110, 28);
            this.dtNgayCap.TabIndex = 30;
            this.dtNgayCap.ValueChanged += new System.EventHandler(this.dtNgayCap_ValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(366, 75);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 21);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Ngày cấp";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(28, 165);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(151, 21);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Nơi khám chữa bệnh";
            // 
            // txtNoiKham
            // 
            this.txtNoiKham.Location = new System.Drawing.Point(213, 161);
            this.txtNoiKham.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoiKham.MenuManager = this.barManager1;
            this.txtNoiKham.Name = "txtNoiKham";
            this.txtNoiKham.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNoiKham.Properties.Appearance.Options.UseFont = true;
            this.txtNoiKham.Size = new System.Drawing.Size(592, 28);
            this.txtNoiKham.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(452, 123);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Cán bộ";
            // 
            // frmBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 585);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoHiem";
            this.Text = "Bảo hiểm";
            this.Load += new System.EventHandler(this.frmBaoHiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slkCanBo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoBH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiKham.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit slkCanBo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnDong;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dtNgayHetHan;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.DateTimePicker dtNgayCap;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNoiKham;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNoiCap;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn DELETED_BY;
        private DevExpress.XtraGrid.Columns.GridColumn SOBH;
        private DevExpress.XtraGrid.Columns.GridColumn MACB;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYCAP;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYHETHAN;
        private DevExpress.XtraGrid.Columns.GridColumn NOICAP;
        private DevExpress.XtraGrid.Columns.GridColumn NOIKHAMBENH;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn SOHIEU;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSoBH;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SearchControl boxTimKiem;
    }
}