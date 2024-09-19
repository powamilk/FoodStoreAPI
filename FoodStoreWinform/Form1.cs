using FoodStoreWinform.Models;
using Newtonsoft.Json;
using System.Text;

namespace FoodStoreWinform
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        private List<OrderItem> _orderItems = new List<OrderItem>(); // Lưu danh sách các OrderItem đã thêm
        private float _totalAmount = 0;
        private int selectedRowIndex = -1;
        public Form1()
        {


            InitializeComponent();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };

            LoadFormOrder();
            LoadFormProduct();
            LoadFormCategory();
            LoadCategoryDataForm();
            
            LoadOderFromData();
            LoadCategoryData();
            LoadProductData();
            LoadCategoryDataForm();
            txt_totalamoun.ReadOnly = true;
            dgv_category.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public async Task LoadFormOrder()
        {
            dgv_order.Columns.Clear();

        }

        public async Task LoadFormProduct()
        {
            dgv_product.Columns.Clear();
        }

        public async Task LoadFormCategory()
        {
            dgv_category.Columns.Clear();
        }

        private async Task LoadOderFromData()
        {
            var orders = await GetAllOrderAsync();
            if (orders != null)
            {

                dgv_order.DataSource = orders;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị");
            }
        }

        private async Task<List<Order>> GetAllOrderAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/orders");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Order>>(json);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private async Task<bool> CreateOrderAsync(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/orders", content);

            return response.IsSuccessStatusCode;
        }
        private async void tab_order_Click(object sender, EventArgs e)
        {
            var newOrder = new Order();
            var result = await CreateOrderAsync(newOrder);


        }

        private async void btn_themorder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm.");
                    return;
                }
                var newOrder = new Order
                {
                    OrderDate = DateTime.Parse(txt_orderdate.Text),
                    TotalAmount = (decimal)_totalAmount,
                    OrderItems = _orderItems
                };
                var apiResult = await CreateOrderAsync(newOrder);

                if (apiResult)
                {
                    MessageBox.Show("Tạo đơn hàng thành công!");
                    await LoadOderFromData();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btn_suaorder_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < _orderItems.Count)
            {
                var orderItem = _orderItems[selectedRowIndex];
                using (Form2 form2 = new Form2(orderItem))
                {
                    var result = form2.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        _orderItems[selectedRowIndex] = form2.TempOrderItem;

                        _totalAmount = 0;
                        foreach (var item in _orderItems)
                        {
                            _totalAmount += item.ProductPrice * item.Quantity;
                        }
                        txt_totalamoun.Text = _totalAmount.ToString("N2");

                        // Cập nhật lại DataGridView
                        dgv_order.DataSource = null;
                        dgv_order.DataSource = _orderItems;

                        MessageBox.Show("Cập nhật sản phẩm thành công.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
            }
        }

        private void btn_xoaorder_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < _orderItems.Count)
            {
                _orderItems.RemoveAt(selectedRowIndex);

                _totalAmount = 0;
                foreach (var item in _orderItems)
                {
                    _totalAmount += item.ProductPrice * item.Quantity;
                }

                txt_totalamoun.Text = _totalAmount.ToString("N2");

                // Cập nhật lại DataGridView
                dgv_order.DataSource = null;
                dgv_order.DataSource = _orderItems;

                MessageBox.Show("Xóa sản phẩm thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
            }
        }

        private void btn_orderitem_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                var result = form2.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var orderItem = form2.TempOrderItem;
                    if (orderItem != null)
                    {
                        _orderItems.Add(orderItem);
                        float totalItemPrice = orderItem.ProductPrice * orderItem.Quantity;
                        _totalAmount += totalItemPrice;
                        txt_totalamoun.Text = _totalAmount.ToString("N2");

                        MessageBox.Show("Sản phẩm đã được thêm vào danh sách.");
                    }
                }
            }
        }

        private async Task LoadCategoryData()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/categories");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<Category>>(json);

                    cb_categoryid.DataSource = categories;
                    cb_categoryid.DisplayMember = "Name";
                    cb_categoryid.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu danh mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async Task LoadProductData()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<Product>>(json);

                    dgv_product.DataSource = products;
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dgv_order.Rows[selectedRowIndex];

                txt_orderdate.Text = Convert.ToDateTime(selectedRow.Cells["OrderDate"].Value).ToString("yyyy-MM-dd");
                txt_totalamoun.Text = selectedRow.Cells["TotalAmount"].Value.ToString();
            }
        }

        private async void btn_themproduct_Click(object sender, EventArgs e)
        {
            try
            {
                var newProduct = new Product
                {
                    Name = txt_product.Text,
                    CategoryId = (int)cb_categoryid.SelectedValue,
                    Price = decimal.Parse(txt_price.Text),
                    Description = txt_description.Text,
                    Stock = int.Parse(txt_stock.Text)
                };

                var json = JsonConvert.SerializeObject(newProduct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/products", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    await LoadProductData();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async void btn_suaproduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_product.Rows[selectedRowIndex];
                    var productId = (int)selectedRow.Cells["Id"].Value;
                    var updatedProduct = new Product
                    {
                        Id = productId,
                        Name = txt_product.Text,
                        CategoryId = (int)cb_categoryid.SelectedValue,
                        Price = decimal.Parse(txt_price.Text),
                        Description = txt_description.Text,
                        Stock = int.Parse(txt_stock.Text)
                    };

                    var json = JsonConvert.SerializeObject(updatedProduct);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync($"/api/products/{productId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!");
                        await LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi sửa sản phẩm.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
            }
        }

        private async void btn_xoaproduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_product.Rows[selectedRowIndex];
                    var productId = (int)selectedRow.Cells["Id"].Value;

                    var response = await _httpClient.DeleteAsync($"/api/products/{productId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        await LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
            }
        }

        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dgv_product.Rows[selectedRowIndex];
                txt_product.Text = selectedRow.Cells["Name"].Value.ToString();
                cb_categoryid.SelectedValue = selectedRow.Cells["CategoryId"].Value;
                txt_price.Text = selectedRow.Cells["Price"].Value.ToString();
                txt_description.Text = selectedRow.Cells["Description"].Value.ToString();
                txt_stock.Text = selectedRow.Cells["Stock"].Value.ToString();
            }
        }

        private async Task LoadCategoryDataForm()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/categories");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<Category>>(json);

                    dgv_category.DataSource = categories;
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu danh mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }


        private async void btn_themcategory_Click(object sender, EventArgs e)
        {
            try
            {
                var newCategory = new Category
                {
                    Name = txt_namecategory.Text,
                    Description = txt_descriptioncategory.Text
                };

                var json = JsonConvert.SerializeObject(newCategory);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/categories", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm danh mục thành công!");
                    await LoadCategoryDataForm();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm danh mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async void btn_suacategory_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_category.Rows[selectedRowIndex];
                    var categoryId = (int)selectedRow.Cells["Id"].Value;

                    var updatedCategory = new Category
                    {
                        Id = categoryId,
                        Name = txt_namecategory.Text,
                        Description = txt_descriptioncategory.Text
                    };

                    var json = JsonConvert.SerializeObject(updatedCategory);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync($"/api/categories/{categoryId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sửa danh mục thành công!");
                        await LoadCategoryDataForm();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi sửa danh mục.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa.");
            }
        }

        private async void btn_xoacategory_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_category.Rows[selectedRowIndex];
                    var categoryId = (int)selectedRow.Cells["Id"].Value;

                    var response = await _httpClient.DeleteAsync($"/api/categories/{categoryId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa danh mục thành công!");
                        await LoadCategoryDataForm();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa danh mục.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa.");
            }
        }

        private void dgv_category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dgv_category.Rows[selectedRowIndex];
                txt_namecategory.Text = selectedRow.Cells["Name"].Value.ToString();
                txt_descriptioncategory.Text = selectedRow.Cells["Description"].Value.ToString();
            }
        }
    }
}
