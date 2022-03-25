using System;
using System.IO;

namespace HomeWork6
{
    class Program
    {
        /// <summary>
        /// Метод выбора действия
        /// </summary>
        static void Chois() 
        {
            Console.WriteLine("1 — вывести данные на экран");
            Console.WriteLine("2 — заполнить данные");
            bool flag = false;
            while (flag == false)
            {
                var InOut = Console.ReadLine();
                flag = int.TryParse(InOut, out int Switch_InOut);
                switch (Switch_InOut)
                {
                    case 1: OutputReader(); break;
                    case 2: InputWriter(); break;
                    default: flag = false; break;
                }
            }
        }
        /// <summary>
        /// Опросник работника
        /// </summary>
        /// <returns> string </returns>
        static string UserData()
        {
            string UserData = String.Empty;
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Введите Id");
                    UserData += ($"#{Console.ReadLine()}#");
                }
                else if (i == 1)
                {
                    UserData += ($"{DateTime.Now}#");
                }
                else if (i == 2)
                {
                    Console.WriteLine("Введите Ф. И. О.");
                    UserData += ($"{Console.ReadLine()}#");
                }
                else if (i == 3)
                {
                    Console.WriteLine("Введите возраст");
                    UserData += ($"{Console.ReadLine()}#");
                }
                else if (i == 4)
                {
                    Console.WriteLine("Введите рост");
                    
                    UserData += ($"{Console.ReadLine()}#");
                }
                else if (i == 5)
                {
                    Console.WriteLine("Введите дату рождения");
                    UserData += ($"{Console.ReadLine()}#");
                }
                else
                {
                    Console.WriteLine("Введите место Рождения");
                    UserData += ($"город {Console.ReadLine()}");
                };
            }
            return UserData;
        }
        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="path">укажите путь к файлу(по умолчанию путь дерриктория проекта)</param>
        static void InputWriter(string path = @"homework6.txt") 
        {
            
            //проверяем есть ли файл
            if (!File.Exists(path))
            {
                using var sw = new StreamWriter(path);
                sw.Write($"{1}{UserData()}");
            }
            else
            {
                string count = Convert.ToString(File.ReadAllLines(path).Length + 1);
                File.AppendAllText(path,$"\r\n{count}{UserData()}" + Environment.NewLine);
            }
        }
        /// <summary>
        /// Метод считывания файла
        /// </summary>
        /// <param name="path">путь к файлу ,по умолчанию :@"homework6.txt"</param>
        static void OutputReader(string path = @"homework6.txt") 
        {
            if (File.Exists(path)) 
            {
                using var sr = new StreamReader(path);
                string[] AllWorker = sr.ReadToEnd().Split("#");
                foreach (var item in AllWorker)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Нет фала для чтения!");
                Chois();
            }
        }

        static void Main(string[] args)
        {
            Chois();
        }
    }
}
