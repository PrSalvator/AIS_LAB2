using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Threading;
using System.Text.Json.Serialization;

namespace AIS_LAB2
{
    class ClientView
    {
        private static Dictionary<int, T> CreateDictionary<T>(List<T> list)
        {
            Dictionary<int, T> dictionary = new Dictionary<int, T>();
            for (int i = 0; i < list.Count(); i++)
            {
                dictionary.Add(i, list[i]);
            }
            return dictionary;
        }
        private static void PrintCar(Models.Car car)
        {
            Console.WriteLine(
                $"{car.Id} " + 
                $"{car.CarBrand} " + 
                $"{car.CarModel} " + 
                $"{car.CarType.Name} " + 
                $"{car.BodyType.Name} " +
                $"{car.NumberOfDoors} " + 
                $"{car.AmountOfHorsepower} " +
                $"{car.IsElectricCar}");
        }
        static void Main(string[] args)
        {
            string message;
            string choose;
            string index;

            int remotePortRead = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortRead"));
            int remotePortWrite = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortWrite"));
            int remotePortDelete = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortDelete"));

            Dictionary<int, Models.BodyType> bodyTypes = new Dictionary<int, Models.BodyType>();
            Dictionary<int, Models.CarType> carTypes = new Dictionary<int, Models.CarType>();

            List<Models.Car> cars = new List<Models.Car>();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            Controllers.ClientController clientController = Controllers.ClientController.Initialyze();

            Models.Car car = Models.Car.Initialyze();

            Thread.Sleep(1000);
            
            try
            {
                bodyTypes = CreateDictionary(clientController.GetBodyTypes());
                carTypes = CreateDictionary(clientController.GetCarTypes());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            try 
            {
                 cars = JsonSerializer.Deserialize<List<Models.Car>>(clientController.SendMessage(remotePortRead), options);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

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
                        return;

                    case ConsoleKey.D1:

                        Console.WriteLine("Введите марку автомобиля");
                        car.CarBrand = Console.ReadLine();

                        Console.WriteLine("Введите модель автомобиля");
                        car.CarModel = Console.ReadLine();

                        Console.WriteLine("Выберите тип кузова");
                        foreach (var body in bodyTypes)
                        {
                            Console.WriteLine($"{ body.Key } - { body.Value.Name }");
                        }

                        choose = Console.ReadLine();

                        if (!Validator.In_Interval(0, bodyTypes.Count() - 1, choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.BodyTypeId = bodyTypes[int.Parse(choose)].Id;

                        Console.WriteLine("Выберите тип автомобиля");
                        foreach (var type in carTypes)
                        {
                            Console.WriteLine($"{ type.Key } - { type.Value.Name }");
                        }

                        choose = Console.ReadLine();

                        if (!Validator.In_Interval(0, carTypes.Count() - 1, choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.CarTypeId = carTypes[int.Parse(choose)].Id;

                        Console.WriteLine("Введите количество дверей");
                        choose = Console.ReadLine();
                        if (!Validator.Is_Letter(choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.NumberOfDoors = int.Parse(choose);

                        Console.WriteLine("Введите количество лошадиных сил");
                        choose = Console.ReadLine();
                        if (!Validator.Is_Letter(choose))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }

                        car.AmountOfHorsepower = int.Parse(choose);

                        Console.WriteLine("Машина работает на электричестве? [Y/N]");
                        ConsoleKey key = new ConsoleKey();
                        while (true)
                        {
                            key = Console.ReadKey(true).Key;
                            if (key == ConsoleKey.Y)
                            {
                                car.IsElectricCar = true;
                                break;
                            }
                            else if (key == ConsoleKey.N)
                            {
                                car.IsElectricCar = false;
                                break;
                            }
                        }
                        var answer = clientController.SendMessage(remotePortWrite, JsonSerializer.Serialize(car));
                        cars.Clear();
                        cars = JsonSerializer.Deserialize<List<Models.Car>>(clientController.SendMessage(remotePortRead), options);
                        Console.WriteLine(answer);
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D2:
                        foreach (var _car in cars)
                        {
                            PrintCar(_car);
                        }
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Введите ID машины");
                        index = Console.ReadLine();
                        if (!Validator.Is_Letter(index))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.WriteLine();
                            break;
                        }
                        try
                        {
                            PrintCar(cars[cars.FindIndex(c => c.Id == int.Parse(index))]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ConsoleKey.D4:
                        clientController.SendMessage(remotePortDelete);
                        cars.Clear();
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
                        try
                        {
                            cars.RemoveAt(cars.FindIndex(c => c.Id == int.Parse(index)));
                            Console.WriteLine(clientController.SendMessage(remotePortDelete, index));
                            cars.Clear();
                            cars = JsonSerializer.Deserialize<List<Models.Car>>(clientController.SendMessage(remotePortRead), options);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
