using System;
using System.Text;
using System.Threading.Tasks;
using FoodStoreMVC.View;

namespace FoodStoreMVC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hệ Thống Quản Lý Cửa Hàng Thực Phẩm");
                Console.WriteLine("1. Quản lý Danh mục");
                Console.WriteLine("2. Quản lý Sản phẩm");
                Console.WriteLine("3. Quản lý Đơn hàng");
                Console.WriteLine("0. Thoát");
                Console.Write("Vui lòng chọn chức năng: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var categoryView = new CategoryView();
                        await categoryView.ShowMenu();
                        break;
                    case "2":
                        var productView = new ProductView();
                        await productView.ShowMenu();
                        break;
                    case "3":
                        var orderView = new OrderView();
                        await orderView.ShowMenu();
                        break;
                    case "0":
                        Console.WriteLine("Đang thoát...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
