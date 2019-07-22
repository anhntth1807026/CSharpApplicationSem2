using System;
using ConsoleApp3.entity;
using CSharpAssignmentSem2.main;

namespace CSharpAssignmentSem2.demo
{
    public class GiaoDichSHB : CSharpAssignmentSem2.demo.GiaoDich
    {
        private static SHBAccountModel shbAccountModel;
        private CSharpAssignmentSem2.demo.GiaoDich _giaoDichImplementation;

        public GiaoDichSHB()
        {
            shbAccountModel = new SHBAccountModel();
        }

        public bool guiTien()
        {
            throw new NotImplementedException();
        }

        public bool rutTien()
        {
            throw new NotImplementedException();
        }

        public bool chuyenKhoan()
        {
            throw new NotImplementedException();
        }

        public void ChuyenKhoan()
        {
            _giaoDichImplementation.ChuyenKhoan();
        }

        public void Login()
        {
            Program.currentLoggedInAccount = null;
            Console.Clear();
            Console.WriteLine("Tiến hành đăng nhập Hệ thống Ngân hàng SHB.");
            Console.WriteLine("Vui lòng điền tên truy cập: ");
            var username = Console.ReadLine();
            Console.WriteLine("Vui lòng nhập mật khẩu: ");
            var password = Console.ReadLine();
            SHBAccount shbAccount = shbAccountModel.FindByUsernameAndPassword(username, password);
            if (shbAccount == null)
            {
                Console.WriteLine("Sai tài khoản, vui lòng thử lại.");
                Console.WriteLine("Ấn enter để tiếp tục.");
                Console.Read();
                return;
            }

            Program.currentLoggedInAccount = shbAccount;
        }

        public void RutTien()
        {
            if (Program.currentLoggedInAccount != null)
            {
                Console.Clear();
                Console.WriteLine("Tiến hành rút tiền tại Hệ thống Ngân hàng SHB.");
                Console.WriteLine("Vui lòng nhập số tiền cần rút: ");
                var amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Số lượng tiền không hợp lệ, vui lòng thử lại.");
                    return;
                }

                var transaction = new SHBTransaction
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    SenderAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                    ReceiverAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                    Type = 1,
                    Message = "Tiến hành rút tiền ở ATM với số tiền: " + amount,
                    Amount = amount,
                    CreatedAtMLS = DateTime.Now.Ticks,
                    UpdatedAtMLS = DateTime.Now.Ticks,
                    Status = 1
                };
                bool result = shbAccountModel.UpdateBalance(Program.currentLoggedInAccount, transaction);
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập lại để sử dụng chức năng này.");
            }
        }

        public void GuiTien()
        {

            if (Program.currentLoggedInAccount != null)
            {
                Console.Clear();
                Console.WriteLine("Tiến hành gửi tiền ở Hệ thống Ngân hàng Blockchain.");
                Console.WriteLine("Vui lòng nhập số tiền cần gửi: ");
                var amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Số lượng tiền không hợp lệ, vui lòng thử lại.");
                    return;
                }

                var transaction = new SHBTransaction
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    SenderAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                    ReceiverAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                    Type = 2,
                    Message = "Tiến hành gửi tiền ở ATM với số tiền: " + amount,
                    Amount = amount,
                    CreatedAtMLS = DateTime.Now.Ticks,
                    UpdatedAtMLS = DateTime.Now.Ticks,
                    Status = 2
                };
                bool result = shbAccountModel.UpdateBalance(Program.currentLoggedInAccount, transaction);
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập lại để sử dụng chức năng này.");
            }

            void ChuyenKhoan()
            {

                if (Program.currentLoggedInAccount != null)
                {
                    Console.Clear();
                    Console.WriteLine("Tiến hành chuyển tiền ở Hệ thống Ngân hàng SHB.");
                    Console.WriteLine("Vui lòng nhâp số tiền cần chuyển: ");
                    var amount = double.Parse(Console.ReadLine());
                    if (amount <= 0)
                    {
                        Console.WriteLine("Số lượng tiền chuyển không phù hợp, vui lòng nhập lại.");
                        return;
                    }

                    var transaction = new SHBTransaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        SenderAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                        ReceiverAccountNumber = Program.currentLoggedInAccount.AccountNumber,
                        Type = 3,
                        Message = "Tiến hàng chuyển khoản tại ATM với số tiền: " + amount,
                        Amount = amount,
                        CreatedAtMLS = DateTime.Now.Ticks,
                        UpdatedAtMLS = DateTime.Now.Ticks,
                        Status = 3
                    };
                    bool result = shbAccountModel.UpdateBalance(Program.currentLoggedInAccount, transaction);
                }
                else
                {
                    Console.WriteLine("Vui lòng đăng nhập lại để sử dụng chức năng này.");
                }
            }
        }
    }
}