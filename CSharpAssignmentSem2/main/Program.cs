using System;
using ConsoleApp3;
using ConsoleApp3.entity;
using CSharpAssignmentSem2.demo;

namespace CSharpAssignmentSem2.main
{
     class Program
    {
        public static SHBAccount currentLoggedInAccount;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                CSharpAssignmentSem2.demo.GiaoDich giaoDich = null;
                Console.WriteLine("Vui lòng lựa chọn Ngân hàng cần giao dịch: ");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Giao dịch trên Hệ thống Ngân hàng SHB.");
                Console.WriteLine("2. Giao dịch Hệ thống Ngân hàng Blockchain.");
                Console.WriteLine("============================================");
                Console.WriteLine("Nhập lựa chọn Ngân hàng của bạn: ");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        giaoDich = new GiaoDichSHB();
                        break;
                    case 2:
                        giaoDich = new GiaoDichBlockchain();
                        break;
                    default:
                        Console.WriteLine("Sai phương thức lựa chọn Ngân hàng.");
                        break;
                }
                
                giaoDich.Login();
                if (currentLoggedInAccount != null)
                {
                    Console.WriteLine("Đăng nhập thành công với tài khoản.");
                    Console.WriteLine($"Tài khoản: {currentLoggedInAccount.Username}");
                    Console.WriteLine($"Số dư: {currentLoggedInAccount.Balance}");
                    Console.WriteLine("Ấn phím enter để tiếp tục giao dịch.");
                    Console.Read();
                    GenerateTransactionMenu(giaoDich);
                }
            }
        }

        private static void GenerateTransactionMenu(CSharpAssignmentSem2.demo.GiaoDich giaoDich)
        {
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Vui lòng lựa chọn phương thức giao dịch: ");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Rút tiền.");
                Console.WriteLine("2. Gửi tiền.");
                Console.WriteLine("3. Chuyển khoản.");
                Console.WriteLine("4. Thoát.");
                
                Console.WriteLine("============================================");
                Console.WriteLine("Nhập lựa chọn của bạn: ");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        giaoDich.RutTien();
                        break;
                    case 2:
                        giaoDich.GuiTien();
                        break;
                    case 3:
                        giaoDich.ChuyenKhoan();
                        break;
                    case 4:
                        Console.WriteLine("Thoát giao dịch.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn sai.");
                        break;
                }

                if (choice == 4)
                {
                    break;
                }
            }
        }
    }

    internal partial interface GiaoDich
    {
        void RutTien();
        void GuiTien();
        void ChuyenKhoan();
        void Login();
    }
}