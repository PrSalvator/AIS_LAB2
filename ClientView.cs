using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ClassLibrary;
using System.Configuration;

namespace AIS_LAB2
{
    class ClientView
    {
        async void Print()
        {
            
        }
        static void Main(string[] args)
        {
            string message;
            string choose;
            string index;

            int remotePortRead = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortRead"));
            int remotePortWrite = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortWrite"));
            int remotePortDelete = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortDelete"));

            ClientController clientController = ClientController.Initialyze();

            Car car = Car.Initialyze();

            //Task.Run();
            while (true)
            {
                
                Console.WriteLine(
                    "Нажмите 1 для добавления автомобиля \n" +
                    "Нажмите 2 для вывода всех автомобилей \n" +
                    "Нажмите 3 для вывода автомобиля по номеру записи \n" +
                    "Нажмите 4 для удаления всех записей \n" +
                    "Нажмите 5 для удаления автомобилей по номеру записи\n" +
                    "Нажмите esc для выхода из программы \n"
                    );
                var button = Console.ReadKey(true).Key;
                if (button == ConsoleKey.Escape) break;

                switch (button)
                {
                    case ConsoleKey.Escape:
                        return ;

                    case ConsoleKey.D1:

                        Console.WriteLine("Введите марку автомобиля");
                        car.Car_brand = Console.ReadLine();

                        Console.WriteLine("Введите модель автомобиля");
                        car.Car_model = Console.ReadLine();

                        Console.WriteLine("Выберите тип кузова");
                        foreach (var body in car.Bodies)
                        {
                            Console.WriteLine($"{ body.Key } - { body.Value }");
                        }

                        choose = Console.ReadLine();

                        if (!Validator.In_Interval(0, car.Bodies.Count - 1, choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.Body_type = car.Bodies[int.Parse(choose)];

                        Console.WriteLine("Выберите тип автомобиля");
                        foreach (var type in car.Types)
                        {
                            Console.WriteLine($"{ type.Key } - { type.Value }");
                        }

                        choose = Console.ReadLine();

                        if (!Validator.In_Interval(0, car.Bodies.Count - 1, choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.Car_type = car.Types[int.Parse(choose)];

                        Console.WriteLine("Введите количество дверей");
                        choose = Console.ReadLine();
                        if (!Validator.Is_Letter(choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.Number_of_doors = int.Parse(choose);

                        Console.WriteLine("Введите количество лошадиных сил");
                        choose = Console.ReadLine();
                        if (!Validator.Is_Letter(choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.Amount_of_horsepower = int.Parse(choose);

                        Console.WriteLine("Машина работает на электричестве? [Y/N]");
                        ConsoleKey key = new ConsoleKey();
                        while (true)
                        {
                            key = Console.ReadKey(true).Key;
                            if (key == ConsoleKey.Y)
                            {
                                car.Is_electric_car = true;
                                break;
                            }
                            else if (key == ConsoleKey.N)
                            {
                                car.Is_electric_car = false;
                                break;
                            }
                        }

                        message = $"{car.Car_brand}; {car.Car_model}; {car.Car_type}; {car.Body_type}; {car.Amount_of_horsepower}; {car.Number_of_doors}; {car.Is_electric_car};";
                        var answer = clientController.SendMessageAsync(remotePortWrite, message);
                        Console.WriteLine(answer);

                        Console.WriteLine();
                        break;

                    case ConsoleKey.D2:
                        string[] data = clientController.SendMessageAsync(remotePortRead).Split('\n');
                        int counter = 0;
                        foreach (string str in data)
                        {
                            string _str = str.Replace(";", "");
                            if (_str != "")
                            {
                                Console.WriteLine($"{counter} {_str}");
                                counter++;
                            }
                        }
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Введите номер записи");
                        index = Console.ReadLine();
                        if (!Validator.Is_Letter(index))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine(clientController.SendMessageAsync(remotePortRead, index).Replace(";", ""));
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine(clientController.SendMessageAsync(remotePortDelete));
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine("Введите номер записи");
                        index = Console.ReadLine();
                        if (!Validator.Is_Letter(index))
                        {
                            Console.WriteLine("Некорректный ввод");
                            break;
                        }
                        Console.WriteLine(clientController.SendMessageAsync(remotePortDelete, index));
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
