using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Mein_menu
    {
        private Model1Container ctx;
        private int currentUserId = 0;



        public Mein_menu()
        {
            ctx = new Model1Container();
        }
        public void LoginMenu()
        {
            int choise;
            do
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Registration");
                Console.WriteLine("3.Exit");
                Console.WriteLine();
                choise = int.Parse(Console.ReadLine());
                Console.WriteLine();

                string name;
                string password;
                UsersInfo user = new UsersInfo();

                switch (choise)
                {
                    case 1:

                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        user.Name = name;
                        user.Password = ComputeSha256Hash(password);
                        int k = 0;
                        foreach (var u in ctx.UsersInfo)
                        {
                            if (u.Name == user.Name && u.Password == user.Password)
                            {
                                currentUserId = user.Id;
                                k = 1;
                            }
                        }
                        if (k == 0)
                            Console.WriteLine("Account not found");
                        else
                            MainMenu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:

                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        user.Name = name;
                        user.Password = ComputeSha256Hash(password);
                        try
                        {
                            ctx.UsersInfo.Add(user);
                            ctx.SaveChanges();
                            currentUserId = user.Id;
                            MainMenu();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Исключение: {e.Message}");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("Enter action 1-3");
                        break;
                }
            } while (choise != 3);
        }

        public void MainMenu()
        {
            int choise;
            do
            {
                Console.WriteLine("1 - Order");
                Console.WriteLine("2 - View rentals");
                Console.WriteLine("3 - Complete the rental");
                Console.WriteLine("4 - Exit");
                Console.WriteLine();
                choise = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choise)
                {
                    case 1:
                        string area;
                        DateTime firstDate, secondDate;
                        int day, month, year;
                        Console.WriteLine("Enter area");
                        area = Console.ReadLine();

                        Console.WriteLine("Enter first date");
                        Console.Write("Enter day:");
                        day = int.Parse(Console.ReadLine());
                        Console.Write("Enter month:");
                        month = int.Parse(Console.ReadLine());
                        Console.Write("Enter year:");
                        year = int.Parse(Console.ReadLine());
                        firstDate = new DateTime(year, month, day);

                        Console.WriteLine("Enter second date");
                        Console.Write("Enter day:");
                        day = int.Parse(Console.ReadLine());
                        Console.Write("Enter month:");
                        month = int.Parse(Console.ReadLine());
                        Console.Write("Enter year:");
                        year = int.Parse(Console.ReadLine());
                        secondDate = new DateTime(year, month, day);
                        int k = 0;
                        foreach (var room in ctx.RoomsInfo)
                        {
                            if (room.Area == area && room.StartRent == firstDate && room.EndRent == secondDate && room.UsersInfoId == null)
                            {
                                Console.WriteLine($"[Id: {room.Id}] City: {room.City}, Address: {room.AccommodationAddress}");
                                k = 1;
                            }
                        }
                        if (k == 0)
                            Console.WriteLine("Nothing found");
                        else
                        {
                            Console.WriteLine("Enter Id");
                            int id_first = int.Parse(Console.ReadLine());
                            foreach (var room in ctx.RoomsInfo)
                            {
                                if (room.Id == id_first)
                                {
                                    room.UsersInfoId = currentUserId;
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        foreach (var room in ctx.RoomsInfo)
                        {
                            if (room.UsersInfoId == currentUserId)
                            {
                                Console.WriteLine($"[Id: {room.Id}] City: {room.City}, Address: {room.AccommodationAddress}");
                            }
                        }
                        break;
                    case 3:
                        foreach (var room in ctx.RoomsInfo)
                        {
                            if (room.UsersInfoId == currentUserId && room.EndRent > DateTime.Now)
                            {
                                Console.WriteLine($"[Id: {room.Id}] City: {room.City}, Address: {room.AccommodationAddress}");
                            }
                        }
                        Console.WriteLine("Enter Id");
                        int id = int.Parse(Console.ReadLine());

                        foreach (var room in ctx.RoomsInfo)
                        {
                            if (room.Id == id)
                            {
                                room.UsersInfoId = null;
                                ctx.SaveChanges();
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("Enter action 1-4");
                        break;
                }
            } while (choise != 4);
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
