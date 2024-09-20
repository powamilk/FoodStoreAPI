using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodStoreWinform.Models;

namespace FoodStoreWinform
{
    public partial class Form2 : Form
    {
        private HttpClient _httpClient;
        public OrderItem TempOrderItem { get; private set; }
        public Form2(OrderItem orderItem = null)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };

            TempOrderItem = orderItem;
            if (orderItem != null)
            {
                cb_productid.SelectedValue = orderItem.ProductId;
                txt_quantity.Text = orderItem.Quantity.ToString();
            }
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await LoadProductData();
            if (TempOrderItem != null)
            {
                cb_productid.SelectedValue = TempOrderItem.ProductId;
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

                    cb_productid.DataSource = products;
                    cb_productid.DisplayMember = "Name";
                    cb_productid.ValueMember = "Id";
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

        public int GetSelectedProductId()
        {
            return (int)cb_productid.SelectedValue;
        }

        private async void btn_xacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = (int)cb_productid.SelectedValue;
                int quantity = int.Parse(txt_quantity.Text);
                var product = await GetProductByIdAsync(productId);

                if (product != null)
                {
                    TempOrderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = quantity,
                        ProductPrice = (float)product.Price
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async Task<Product> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"api/products/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(json);
            }
            return null;
        }
    }
}
