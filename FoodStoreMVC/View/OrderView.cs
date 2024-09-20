using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodStoreMVC.Models;
using FoodStoreMVC.Controllers;

namespace FoodStoreMVC.View
{
    public class OrderView
    {
        private readonly OrderController _orderController;

        public OrderView()
        {
            _orderController = new OrderController();
        }

        public async Task ShowMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("==== Quản Lý Đơn Hàng ====");
                Console.WriteLine("1. Xem danh sách đơn hàng");
                Console.WriteLine("2. Thêm đơn hàng mới");
                Console.WriteLine("3. Cập nhật đơn hàng");
                Console.WriteLine("4. Xóa đơn hàng");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await ShowOrdersAsync();
                        break;
                    case 2:
                        await CreateOrderAsync();
                        break;
                    case 3:
                        await UpdateOrderAsync();
                        break;
                    case 4:
                        await DeleteOrderAsync();
                        break;
                }
            } while (choice != 0);
        }

        public async Task ShowOrdersAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Danh Sách Đơn Hàng ====");

            var orders = await _orderController.GetAllOrdersAsync();
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"ID: {order.Id}, Ngày đặt: {order.OrderDate}, Tổng tiền: {order.TotalAmount}");
                }
            }
            else
            {
                Console.WriteLine("Không có đơn hàng nào.");
            }
            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task CreateOrderAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Thêm Đơn Hàng Mới ====");
            Console.Write("ID Khách hàng: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Ngày đặt hàng (yyyy-MM-dd): ");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());

            var newOrder = new Order { CustomerId = customerId, OrderDate = orderDate, TotalAmount = 0 };

            bool result = await _orderController.CreateOrderAsync(newOrder);
            Console.WriteLine(result ? "Thêm thành công!" : "Thêm thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task UpdateOrderAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Cập Nhật Đơn Hàng ====");
            await ShowOrdersAsync();
            Console.Write("Nhập ID đơn hàng cần cập nhật: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("ID Khách hàng mới: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Ngày đặt hàng mới (yyyy-MM-dd): ");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());

            var updatedOrder = new Order { Id = id, CustomerId = customerId, OrderDate = orderDate };

            bool result = await _orderController.UpdateOrderAsync(updatedOrder);
            Console.WriteLine(result ? "Cập nhật thành công!" : "Cập nhật thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        public async Task DeleteOrderAsync()
        {
            Console.Clear();
            Console.WriteLine("==== Xóa Đơn Hàng ====");
            await ShowOrdersAsync();
            Console.Write("Nhập ID đơn hàng cần xóa: ");
            int id = int.Parse(Console.ReadLine());

            bool result = await _orderController.DeleteOrderAsync(id);
            Console.WriteLine(result ? "Xóa thành công!" : "Xóa thất bại!");

            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }
    }
}
