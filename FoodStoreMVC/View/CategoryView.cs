using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodStoreMVC.Models;
using FoodStoreMVC.Controllers;

namespace FoodStoreMVC.View
{
    public class CategoryView
    {
        private readonly CategoryController _categoryController;

        public CategoryView()
        {
            _categoryController = new CategoryController();
        }

        public async Task ShowMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("==== Quản Lý Danh Mục ====");
                Console.WriteLine("1. Xem danh sách danh mục");
                Console.WriteLine("2. Thêm danh mục mới");
                Console.WriteLine("3. Cập nhật danh mục");
                Console.WriteLine("4. Xóa danh mục");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await ShowCategoriesAsync();
                        break;
                    case 2:
                        await CreateCategoryAsync();
                        break;
                    case 3:
                        await UpdateCategoryAsync();
                        break;
                    case 4:
                        await DeleteCategoryAsync();
                        break;
                }
            } while (choice != 0);
        }

        public async Task ShowCategoriesAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Danh Sách Danh Mục ====");

            var categories = await _categoryController.GetAllCategoriesAsync();
            if (categories != null)
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id}, Tên: {category.Name}, Mô tả: {category.Description}");
                }
            }
            else
            {
                Console.WriteLine("Không có danh mục nào.");
            }
            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task CreateCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Thêm Danh Mục Mới ====");
            Console.Write("Tên danh mục: ");
            var name = Console.ReadLine();

            Console.Write("Mô tả: ");
            var description = Console.ReadLine();

            var category = new Category { Name = name, Description = description };

            bool result = await _categoryController.CreateCategoryAsync(category);
            Console.WriteLine(result ? "Thêm thành công!" : "Thêm thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task UpdateCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Cập Nhật Danh Mục ====");
            await ShowCategoriesAsync();
            Console.Write("Nhập ID danh mục cần cập nhật: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Tên mới: ");
            var name = Console.ReadLine();
            Console.Write("Mô tả mới: ");
            var description = Console.ReadLine();

            var category = new Category { Id = id, Name = name, Description = description };

            bool result = await _categoryController.UpdateCategoryAsync(category);
            Console.WriteLine(result ? "Cập nhật thành công!" : "Cập nhật thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task DeleteCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Xóa Danh Mục ====");
            await ShowCategoriesAsync();
            Console.Write("Nhập ID danh mục cần xóa: ");
            int id = int.Parse(Console.ReadLine());

            bool result = await _categoryController.DeleteCategoryAsync(id);
            Console.WriteLine(result ? "Xóa thành công!" : "Xóa thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }
    }
}
