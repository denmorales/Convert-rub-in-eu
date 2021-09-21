using System;
using System.Net;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество рублей: ");
        double rub = double.Parse(Console.ReadLine());
        double cource = GetCourse();
        Console.WriteLine("Курс евро: " + cource);
        Console.WriteLine("{0} руб. = {1} евро.", rub, Math.Round(rub / GetCourse(), 2));
        Console.ReadKey();
    }
    static double GetCourse()
    {
        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8;
        string data = client.DownloadString("http://www.banki.ru/products/currency/cb/");
        string ff = data.Substring(data.IndexOf("<strong>Евро</strong>"));
        ff = ff.Substring(ff.IndexOf("<td>") + 4);
        ff = ff.Remove(ff.IndexOf("</td>")).Replace('.', ',');
        return double.Parse(ff);
    }
}