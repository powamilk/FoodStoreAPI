using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodStoreMVC.Controllers;
using FoodStoreMVC.Models;

namespace FoodStoreMVC.View
{
    public class ProductView
    {
        private readonly ProductController _productController;

        public ProductView()
        {
            _productController = new ProductController();
        }

        public async Task ShowMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("==== Quản Lý Sản Phẩm ====");
                Console.WriteLine("1. Xem danh sách sản phẩm");
                Console.WriteLine("2. Thêm sản phẩm mới");
                Console.WriteLine("3. Cập nhật sản phẩm");
                Console.WriteLine("4. Xóa sản phẩm");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await ShowProductsAsync();
                        break;
                    case 2:
                        await CreateProductAsync();
                        break;
                    case 3:
                        await UpdateProductAsync();
                        break;
                    case 4:
                        await DeleteProductAsync();
                        break;
                }
            } while (choice != 0);
        }

        public async Task ShowProductsAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Danh Sách Sản Phẩm ====");

            var products = await _productController.GetAllProductsAsync();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Tên: {product.Name}, Giá: {product.Price}, Số lượng tồn kho: {product.Stock}");
                }
            }
            else
            {
                Console.WriteLine("Không có sản phẩm nào.");
            }
            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task CreateProductAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Thêm Sản Phẩm Mới ====");
            Console.Write("Tên sản phẩm: ");
            var name = Console.ReadLine();
            Console.Write("ID danh mục: ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.Write("Giá sản phẩm: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Số lượng tồn kho: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Mô tả: ");
            var description = Console.ReadLine();

            var product = new Product { Name = name, CategoryId = categoryId, Price = price, Stock = stock, Description = description };

            bool result = await _productController.CreateProductAsync(product);
            Console.WriteLine(result ? "Thêm thành công!" : "Thêm thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task UpdateProductAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Cập Nhật Sản Phẩm ====");
            await ShowProductsAsync();
            Console.Write("Nhập ID sản phẩm cần cập nhật: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Tên mới: ");
            var name = Console.ReadLine();
            Console.Write("Giá mới: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Số lượng tồn kho mới: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Mô tả mới: ");
            var description = Console.ReadLine();

            var product = new Product { Id = id, Name = name, Price = price, Stock = stock, Description = description };

            bool result = await _productController.UpdateProductAsync(product);
            Console.WriteLine(result ? "Cập nhật thành công!" : "Cập nhật thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task DeleteProductAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Xóa Sản Phẩm ====");
            await ShowProductsAsync();
            Console.Write("Nhập ID sản phẩm cần xóa: ");
            int id = int.Parse(Console.ReadLine());

            bool result = await _productController.DeleteProductAsync(id);
            Console.WriteLine(result ? "Xóa thành công!" : "Xóa thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }
    }
}
