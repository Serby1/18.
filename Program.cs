using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader("fileIn.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter("fileOut.txt"))
                {
                    Software[] array = new Software[4];
                    for (int i = 0; i < array.Length; ++i)
                    {
                        string str = fileIn.ReadLine();
                        if (str == "Свободное")
                        {
                            string name = fileIn.ReadLine();
                            string manufct = fileIn.ReadLine();
                            array[i] = new Free(name, manufct);
                        }
                        else if (str == "Условно-бесплатное")
                        {
                            string name = fileIn.ReadLine();
                            string manufct = fileIn.ReadLine();
                            string dateUsing = fileIn.ReadLine();
                            string dateSetting = fileIn.ReadLine();
                            array[i] = new Shareware(name, manufct, dateSetting, dateUsing);
                        }
                        else if (str == "Коммерческое")
                        {
                            string name = fileIn.ReadLine();
                            string manufct = fileIn.ReadLine();
                            string dateUsing = fileIn.ReadLine();
                            string dateSetting = fileIn.ReadLine();
                            string price = fileIn.ReadLine();
                            array[i] = new Commercial(name, manufct, dateSetting, dateUsing, int.Parse(price));

                        }
                        else { Console.WriteLine("Неверно введены данные"); }
                        str = fileIn.ReadLine();
                    
}
                    foreach (Software x in array)
                    {
                        x.showInf();
                    }
                    Console.Write("Введите интересующую Вас дату(дд.мм.гг): ");
                    DateTime dateNow = DateTime.Parse(Console.ReadLine());
                    while (dateNow == null)
                    {
                        Console.Write("Введите интересующую Вас дату(дд.мм.гг): ");
                        dateNow = DateTime.Parse(Console.ReadLine());
                    }
                    int count = 0;
                    fileOut.WriteLine("Результаты: ");
                    foreach (Software x in array)
                    {
                        if (x.relevance(dateNow))
                        {
                            ++count;
                            x.showInf();
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Подходящего ПО не найдено");
                    }
                  
                    
                }
            }
        }
    }
}
