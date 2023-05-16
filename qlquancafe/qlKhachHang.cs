using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace qlquancafe
{
    class qlKhachHang
    {
        public static void QuanLyKhachHangMenu()
        {
            Console.Clear();
            Console.WriteLine("Chức năng quản lý khách hàng");

            string[] menuItems = { "Xem thông tin khách hàng", "Thêm khách hàng mới", "Sửa thông tin khách hàng", "Xóa khách hàng", "Tìm kiếm khách hàng", "Trở về trang chủ" };
            int selectedItemIndex = 0;
            bool isShowingCustomers = false;
            while (true)
            {
                Console.Clear();

                if (isShowingCustomers)
                {
                    XemThongTinKhachHang();
                }
                else
                {
                    DrawMenu(menuItems, selectedItemIndex);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (isShowingCustomers)
                {
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isShowingCustomers = false;
                    }
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.UpArrow && selectedItemIndex > 0)
                    {
                        selectedItemIndex--;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow && selectedItemIndex < menuItems.Length - 1)
                    {
                        selectedItemIndex++;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        switch (selectedItemIndex)
                        {
                            case 0:
                                XemThongTinKhachHang();
                                break;
                            case 1:
                                ThemKhachHang();
                                break;
                            case 2:
                                SuaThongTinKhachHang();
                                break;
                            case 3:
                                XoaKhachHang();
                                break;
                            case 4:
                                isShowingCustomers = true;
                                TimKiemKhachHang();
                                break;
                            case 5:

                                return; // Trở về trang chủ
                        }

                        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void DrawMenu(string[] menuItems, int selectedItemIndex)
        {
            int menuWidth = 20;
            int menuHeight = menuItems.Length;
            int startRow = Console.WindowHeight / 2 - menuHeight / 2;
            int startCol = Console.WindowWidth / 2 - menuWidth / 2;

            Console.Clear();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(startCol, startRow + i);

                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("-> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("   ");
                }

                Console.Write(menuItems[i]);

                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" <-");
                }
            }
        }

        private static void XemThongTinKhachHang()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_khachhang.txt";

            Console.WriteLine("Thông tin khách hàng:\n");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}", "Tên", "Số điện thoại", "Địa chỉ", "Lịch sử mua");
                    Console.WriteLine("---------------------------------------------------------");

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 4)
                        {
                            string name = values[0].Trim();
                            string phoneNumber = values[1].Trim();
                            string address = values[2].Trim();
                            string history = values[3].Trim();

                            Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}", name, phoneNumber, address, history);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Không có thông tin khách hàng.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp file_khachhang.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
            Console.ReadKey();
        }

        private static void ThemKhachHang()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_khachhang.txt";

            Console.WriteLine("Thêm khách hàng mới:\n");

            Console.Write("Nhập tên khách hàng: ");
            string name = Console.ReadLine();

            Console.Write("Nhập số điện thoại: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            string address = Console.ReadLine();

            Console.Write("Nhập lịch sử mua: ");
            string history = Console.ReadLine();

            string newLine = $"{name}, {phoneNumber}, {address}, {history}";

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(newLine);
                }

                Console.WriteLine("Thêm khách hàng thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            // Thêm khách hàng vào danh sách


            // Hiển thị danh sách khách hàng
            Console.WriteLine("\nDanh sách khách hàng sau khi thêm:\n");
            XemThongTinKhachHang();


            Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
            Console.ReadKey();
        }

        private static void SuaThongTinKhachHang()
        {
            // TODO: Thêm mã nguồn để sửa thông tin khách hàng trong tệp khachhang.txt
            Console.WriteLine("Chức năng sửa thông tin khách hàng");
        }

        private static void XoaKhachHang()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_khachhang.txt";

            Console.WriteLine("Xóa thông tin khách hàng:\n");

            Console.Write("Nhập tên khách hàng cần xóa: ");
            string name = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool khachHangDaXoa = false;

                List<string> updatedLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    if (values.Length == 4)
                    {
                        string khachHangName = values[0].Trim();

                        if (khachHangName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            // Bỏ qua dòng chứa thông tin của khách hàng cần xóa
                            khachHangDaXoa = true;
                            continue;
                        }
                    }

                    updatedLines.Add(line);
                }

                if (khachHangDaXoa)
                {
                    File.WriteAllLines(filePath, updatedLines);
                    Console.WriteLine("\nThông tin khách hàng đã được xóa thành công!");
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy khách hàng có tên \"{0}\" trong danh sách.", name);
                }

                Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp khachhang.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private static void TimKiemKhachHang()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_khachhang.txt";

            Console.WriteLine("Dữ liệu khách hàng:\n");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}", "Tên", "Số điện thoại", "Địa chỉ", "Lịch sử mua");
                    Console.WriteLine("---------------------------------------------------------");

                    List<string> foundCustomers = new List<string>();

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 4)
                        {
                            string name = values[0].Trim();
                            string phoneNumber = values[1].Trim();
                            string address = values[2].Trim();
                            string history = values[3].Trim();

                            foundCustomers.Add(line);
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Tìm kiếm khách hàng:\n");

                    Console.Write("Nhập kí tự tìm kiếm: ");
                    string keyword = Console.ReadLine();

                    Console.WriteLine("\nKết quả tìm kiếm:\n");

                    Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}", "Tên", "Số điện thoại", "Địa chỉ", "Lịch sử mua");
                    Console.WriteLine("---------------------------------------------------------");

                    bool foundAny = false;

                    foreach (string line in foundCustomers)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 4)
                        {
                            string name = values[0].Trim();
                            string phoneNumber = values[1].Trim();
                            string address = values[2].Trim();
                            string history = values[3].Trim();

                            if (name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                Console.WriteLine("{0,-20}{1,-15}{2,-20}{3,-15}", name, phoneNumber, address, history);
                                foundAny = true;
                            }
                        }
                    }

                    if (!foundAny)
                    {
                        Console.WriteLine("Không tìm thấy khách hàng phù hợp.");
                    }
                }
                else
                {
                    Console.WriteLine("Không có thông tin khách hàng.");
                    return;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp file_khachhang.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

            Console.WriteLine("\n");

        }

    }
    
}

 