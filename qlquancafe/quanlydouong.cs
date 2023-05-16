using System;
using System.IO;

namespace qlquancafe
{
    class quanlydouong
    {
        public static void QuanLyDoUongMenu()
        {
            Console.Clear();
            Console.WriteLine("Chức năng quản lý đồ uống");

            string filePath = @"C:\Users\1010302\OneDrive\Documents\qldouong.txt";

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp quanlydouong.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
            Console.ReadKey();
        }
    }
}
