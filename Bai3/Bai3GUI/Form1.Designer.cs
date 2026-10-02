namespace Bai3GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCsvMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            // menuStrip1
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileMenu });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);

            // fileMenu
            this.fileMenu.Text = "File";
            this.exportCsvMenuItem.Text = "Export CSV";
            this.exportCsvMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.exportCsvMenuItem, this.exitMenuItem });

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.lblStatus.Text = "Tổng số sản phẩm: 0";

            // tblMain (Cố định tỷ lệ 35% - 65%)
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tblMain.Controls.Add(this.pnlRight, 1, 0);
            this.tblMain.Location = new System.Drawing.Point(0, 24);
            this.tblMain.Size = new System.Drawing.Size(1000, 554);

            // pnlLeft (Cột trái nhập liệu)
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblId, this.txtProductId,
                this.lblName, this.txtProductName,
                this.lblCat, this.cboCategory,
                this.lblPrice, this.txtUnitPrice,
                this.lblQty, this.txtQuantity,
                this.picAvatar, this.btnChooseImage,
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnExport
            });

            this.lblId.Text = "Mã SP:";
            this.lblId.Location = new System.Drawing.Point(15, 20);
            this.lblId.AutoSize = true;
            this.txtProductId.Location = new System.Drawing.Point(95, 17);
            this.txtProductId.Size = new System.Drawing.Size(225, 23);

            this.lblName.Text = "Tên SP:";
            this.lblName.Location = new System.Drawing.Point(15, 55);
            this.lblName.AutoSize = true;
            this.txtProductName.Location = new System.Drawing.Point(95, 52);
            this.txtProductName.Size = new System.Drawing.Size(225, 23);

            this.lblCat.Text = "Danh mục:";
            this.lblCat.Location = new System.Drawing.Point(15, 90);
            this.lblCat.AutoSize = true;
            this.cboCategory.Location = new System.Drawing.Point(95, 87);
            this.cboCategory.Size = new System.Drawing.Size(225, 23);
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPrice.Text = "Đơn giá:";
            this.lblPrice.Location = new System.Drawing.Point(15, 125);
            this.lblPrice.AutoSize = true;
            this.txtUnitPrice.Location = new System.Drawing.Point(95, 122);
            this.txtUnitPrice.Size = new System.Drawing.Size(225, 23);

            this.lblQty.Text = "Số lượng:";
            this.lblQty.Location = new System.Drawing.Point(15, 160);
            this.lblQty.AutoSize = true;
            this.txtQuantity.Location = new System.Drawing.Point(95, 157);
            this.txtQuantity.Size = new System.Drawing.Size(225, 23);

            this.picAvatar.Location = new System.Drawing.Point(95, 195);
            this.picAvatar.Size = new System.Drawing.Size(125, 125);
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.Location = new System.Drawing.Point(230, 285);
            this.btnChooseImage.Size = new System.Drawing.Size(90, 35);

            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(15, 345);
            this.btnAdd.Size = new System.Drawing.Size(70, 32);

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new System.Drawing.Point(90, 345);
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(170, 345);
            this.btnDelete.Size = new System.Drawing.Size(65, 32);

            this.btnExport.Text = "Xuất CSV";
            this.btnExport.Location = new System.Drawing.Point(240, 345);
            this.btnExport.Size = new System.Drawing.Size(80, 32);

            // pnlRight (Cột phải dữ liệu)
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Controls.Add(this.lblSearch);
            this.pnlRight.Controls.Add(this.txtSearch);
            this.pnlRight.Controls.Add(this.dgvProducts);

            this.lblSearch.Text = "Tìm kiếm theo tên:";
            this.lblSearch.Location = new System.Drawing.Point(15, 20);
            this.lblSearch.AutoSize = true;

            this.txtSearch.Location = new System.Drawing.Point(135, 17);
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Size = new System.Drawing.Size(490, 23);

            // dgvProducts (Tự căn theo bảng và co giãn khi phóng to)
            this.dgvProducts.Location = new System.Drawing.Point(15, 52);
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.Size = new System.Drawing.Size(610, 480);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colId.DataPropertyName = "ProductId";
            this.colId.HeaderText = "Mã SP";
            this.colId.FillWeight = 60F;

            this.colName.DataPropertyName = "ProductName";
            this.colName.HeaderText = "Tên SP";
            this.colName.FillWeight = 130F;

            this.colCat.DataPropertyName = "CategoryName";
            this.colCat.HeaderText = "Danh Mục";
            this.colCat.FillWeight = 90F;

            this.colPrice.DataPropertyName = "UnitPrice";
            this.colPrice.HeaderText = "Đơn Giá";
            this.colPrice.DefaultCellStyle.Format = "N0";
            this.colPrice.FillWeight = 90F;

            this.colQty.DataPropertyName = "Quantity";
            this.colQty.HeaderText = "Số Lượng";
            this.colQty.FillWeight = 60F;

            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colName, this.colCat, this.colPrice, this.colQty
            });

            // Form1
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Text = "TechMart Product Manager";
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exportCsvMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}