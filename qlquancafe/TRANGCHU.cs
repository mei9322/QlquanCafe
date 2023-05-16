using System;

namespace qlquancafe
{
    class TRANGCHU
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.ASCIIEncoding.UTF8;
            Console.CursorVisible = false; // Ẩn con trỏ chuột

            string[] menuItems = { "Quản lý khách hàng","Quản lý đồ uống", "Quản lý đơn hàng", "Quản lý khách hàng", "Quản lý bàn" };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems, selectedItemIndex);

                // Đọc phím đang được nhấn
                ConsoleKeyInfo keyInfo = Console.ReadKey();

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
                    // Xử lý chọn mục được chọn
                    HandleSelection(selectedItemIndex);
                }
            }
        }

        static void DrawMenu(string[] menuItems, int selectedItemIndex)
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



        static void HandleSelection(int selectedItemIndex)
        {
            Console.Clear();

            switch (selectedItemIndex)
            {
                case 0:
                    // Quản lý đồ uống
                    Console.WriteLine("Chức năng quản khách hàng");
                    qlKhachHang.QuanLyKhachHangMenu();
                    // TODO: Thêm code để xử lý chức năng quản lý đồ uống
                    break;
                case 1:
                    // Quản lý đồ uống
                    Console.WriteLine("Chức năng quản lý đồ uống");
                    quanlydouong.QuanLyDoUongMenu();
                    // TODO: Thêm code để xử lý chức năng quản lý đồ uống
                    break;
                case 2:
                    // Quản lý đơn hàng
                    Console.WriteLine("Chức năng quản lý đơn hàng");
                    // TODO: Thêm code để xử lý chức năng quản lý đơn hàng
                    break;
                case 3:
                    // Quản lý khách hàng
                    Console.WriteLine("Chức năng quản lý khách hàng");
                    // TODO: Thêm code để xử lý chức năng quản lý khách hàng
                    break;
                case 4:
                    // Quản lý bàn
                    Console.WriteLine("Chức năng quản lý bàn");
                    // TODO: Thêm code để xử lý chức năng quản lý bàn
                    break;
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về");
        }
    }
}

