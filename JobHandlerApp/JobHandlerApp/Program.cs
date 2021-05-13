﻿using System;
using JobPlanner;

namespace JobHandlerApp
{
    public class Program
    {
        private static JobScheduler _scheduler;

        public static void Main(string[] args)
        {
           _scheduler = new(ReadInterval());

            bool alive = true;

            while (alive)
            {
                try
                {
                    switch (GetNumberItemOfMenu())
                    {
                        case 1:
                            AddLogToConsole();
                            break;
                        case 2:
                            AddLogToFile();
                            break;
                        case 3:
                            AddDownloadWebsite();
                            break;
                        case 4:
                            AddPrintOrders();
                            break;
                        case 5:
                            AddLogToConsoleByDate();
                            break;
                        case 6:
                            AddLogToFileByDate();
                            break;
                        case 7:
                            AddDownloadWebsiteByDate();
                            break;
                        case 8:
                            AddPrintOrdersByDate();
                            break;
                        case 9:
                            Start();
                            break;
                        case 10:
                            alive = false;
                            continue;
                        default:
                            throw new ArgumentException("There is no such menu item!");
                    }
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private static int GetNumberItemOfMenu()
        {
            PrintMenu();

            int itemSelect;

            while (!int.TryParse(Console.ReadLine(), out itemSelect))
            {
                Console.Write("You entered the wrong item. Please try again: ");
            }

            return itemSelect;
        }

        private static void ShowException(Exception ex)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = color;
            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.Clear();
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Add logging to the console");
            Console.WriteLine("2. Add logging to the file");
            Console.WriteLine("3. Add download website to file");
            Console.WriteLine("4. Add print orders to the console");
            Console.WriteLine("5. Add logging to console by date");
            Console.WriteLine("6. Add logging to file by date");
            Console.WriteLine("7. Add download website to file by date");
            Console.WriteLine("8. Add print orders to console by date");
            Console.WriteLine("9. Start scheduler");
            Console.WriteLine("10. Exit program");

            Console.WriteLine("Enter the item number:");
            Console.ForegroundColor = color;
        }

        private static void AddLogToConsole()
        {
            _scheduler.AddHandler(new JobExecutionTimeInConsole());
        }

        private static void AddLogToFile()
        {
            _scheduler.AddHandler(new JobExecutionTimeInFile());
        }

        private static void AddDownloadWebsite()
        {
            Console.WriteLine("Input website address: ");

            var path = Console.ReadLine();

            _scheduler.AddHandler(new JobDownloadWebsite(path));
        }

        private static void AddPrintOrders()
        {
            _scheduler.AddHandler(new JobExecutionOrdersInConsole());
        }

        private static void AddLogToConsoleByDate()
        {
            _scheduler.AddHandler(new JobExecutionTimeInConsole(ReadStartDate()));
        }

        private static void AddLogToFileByDate()
        {
            _scheduler.AddHandler(new JobExecutionTimeInFile(ReadStartDate()));
        }

        private static void AddDownloadWebsiteByDate()
        {
            Console.WriteLine("Input website address: ");

            var path = Console.ReadLine();

            _scheduler.AddHandler(new JobDownloadWebsite(path, ReadStartDate()));
        }

        private static void AddPrintOrdersByDate()
        {
            _scheduler.AddHandler(new JobExecutionOrdersInConsole(ReadStartDate()));
        }

        private static void Start()
        {
            Console.Clear();
            Console.WriteLine("Please press Enter for start program");
            Console.WriteLine("Please press ESC for stop program");

            AwaitPress(ConsoleKey.Enter);

            _scheduler.Start();

            AwaitStop();
        }

        private static void AwaitStop()
        {
            AwaitPress(ConsoleKey.Escape);

            _scheduler.Stop();
        }

        private static void AwaitPress(ConsoleKey key)
        {
            while (Console.ReadKey().Key != key)
            {
            }

            Console.Clear();
        }

        private static int ReadInterval()
        {
            Console.WriteLine("Please enter the program run interval in milliseconds:");

            int interval;

            while (!int.TryParse(Console.ReadLine(), out interval))
            {
                Console.Write("You entered the wrong interval. Please try again: ");
            }

            return interval;
        }

        private static DateTime ReadStartDate()
        {
            Console.WriteLine("Please enter start date:");

            DateTime startDate;

            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.Write("You entered the wrong start date. Please try again: ");
            }

            return startDate;
        }
    }
}

