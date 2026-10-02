using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai3GUI
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _allProducts = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        private string _selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChooseImage.Click += BtnChooseImage_Click;
            btnExport.Click += (s, e) => ExportToCsv();
            exportCsvMenuItem.Click += (s, e) => ExportToCsv();
            exitMenuItem.Click += (s, e) => Application.Exit();
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvProducts.CellClick += DgvProducts_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();

            _bindingSource.DataSource = _allProducts;
            dgvProducts.DataSource = _bindingSource;

            // Dữ liệu mẫu ban đầu
            _allProducts.Add(new Product { ProductId = "SP01", ProductName = "iPhone 15", CategoryId = "CAT1", CategoryName = "Điện thoại", UnitPrice = 22000000m, Quantity = 10 });
            _allProducts.Add(new Product { ProductId = "SP02", ProductName = "Tai nghe Sony", CategoryId = "CAT3", CategoryName = "Phụ kiện", UnitPrice = 4500000m, Quantity = 25 });

            UpdateStatus();
        }

        private void LoadCategories()
        {
            var categories = new List<Category>
            {
                new Category("CAT1", "Điện thoại"),
                new Category("CAT2", "Laptop"),
                new Category("CAT3", "Phụ kiện")
            };
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtUnitPrice, "Đơn giá phải là số và lớn hơn 0!");
                isValid = false;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty < 0)
            {
                errorProvider1.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string id = string.IsNullOrWhiteSpace(txtProductId.Text) ? "SP" + (_allProducts.Count + 1).ToString("D2") : txtProductId.Text.Trim();

            var newProduct = new Product
            {
                ProductId = id,
                ProductName = txtProductName.Text.Trim(),
                CategoryId = cboCategory.SelectedValue?.ToString(),
                CategoryName = cboCategory.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim()),
                Quantity = int.Parse(txtQuantity.Text.Trim()),
                ImagePath = _selectedImagePath
            };

            _allProducts.Add(newProduct);
            ClearInput();
            UpdateStatus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            var current = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (current != null)
            {
                current.ProductId = txtProductId.Text.Trim();
                current.ProductName = txtProductName.Text.Trim();
                current.CategoryId = cboCategory.SelectedValue?.ToString();
                current.CategoryName = cboCategory.Text;
                current.UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim());
                current.Quantity = int.Parse(txtQuantity.Text.Trim());
                current.ImagePath = _selectedImagePath;

                _bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                var current = dgvProducts.CurrentRow.DataBoundItem as Product;
                if (current != null)
                {
                    _allProducts.Remove(current);
                    ClearInput();
                    UpdateStatus();
                }
            }
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    picAvatar.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var p = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (p != null)
            {
                txtProductId.Text = p.ProductId;
                txtProductName.Text = p.ProductName;
                txtUnitPrice.Text = p.UnitPrice.ToString("0");
                txtQuantity.Text = p.Quantity.ToString();
                cboCategory.SelectedValue = p.CategoryId;
                _selectedImagePath = p.ImagePath;

                if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
                    picAvatar.Image = Image.FromFile(p.ImagePath);
                else
                    picAvatar.Image = null;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource = _allProducts;
            }
            else
            {
                var filtered = _allProducts.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();
                _bindingSource.DataSource = new BindingList<Product>(filtered);
            }
            UpdateStatus();
        }

        private void ExportToCsv()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "Products.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("MaSP,TenSP,DanhMuc,DonGia,SoLuong");

                    foreach (var p in _allProducts)
                    {
                        sb.AppendLine($"{p.ProductId},{p.ProductName},{p.CategoryName},{p.UnitPrice},{p.Quantity}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearInput()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            picAvatar.Image = null;
            _selectedImagePath = "";
            errorProvider1.Clear();
        }

        private void UpdateStatus()
        {
            lblStatus.Text = $"Tổng số sản phẩm: {_bindingSource.Count}";
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }
    }
}