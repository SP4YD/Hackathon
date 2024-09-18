using System;
using Lab1.Models;

internal class Program {
    private const string PathJuns = "D:\\Программист\\C#\\Hackathon\\Lab1\\Lab1\\ListsParticipants\\Juniors20.csv";
    private const string PathTLs = "D:\\Программист\\C#\\Hackathon\\Lab1\\Lab1\\ListsParticipants\\Teamleads20.csv";

    private static void Main(string[] args) {
        Initialization(out var juns, out var tls);
        
        var manager = new HRManager(juns, tls);
        var director = new HRDirector(manager);

        for (int i = 0; i < 1000; i++)
        {
            // Проведение хакатона
            ConductingHackathon.StartHackathon(juns, tls);
        
            // Формирование команд с помощью стратегии
            int[] matches = manager.TeamFormation(juns, tls);
            
            // Подсчёт гармонического
            double curHarmonic = director.CalculationHarm(juns, tls, matches);
        
            // Вывод гармонического
            Console.WriteLine($"Гармоническое: {curHarmonic}");
        }
        
        Console.WriteLine($"Среднее Арифметическое Гармоническое: {director.HarmonicMean}");
    }

    private static void Initialization(out List<Junior> juns, out List<TeamLead> tls)
    {
        juns = new List<Junior>();
        tls = new List<TeamLead>();
        
        List<string> strJuns = ReadFromCsv(PathJuns);
        List<string> strTls = ReadFromCsv(PathTLs);
        
        foreach (string strjun in strJuns)
        {
            string[] param = strjun.Split(";");
            juns.Add(new Junior(int.Parse(param[0]) - 1, param[1]));
        }
        
        foreach (string strtl in strTls)
        {
            string[] param = strtl.Split(";");
            tls.Add(new TeamLead(int.Parse(param[0]) - 1, param[1]));
        }
    }

    private static List<string> ReadFromCsv(string filePath)
    {
        List<string> persons = new List<string>();
  
        try
        {
            using StreamReader sr = new StreamReader(filePath);
            string line;
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                persons.Add(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }

        return persons;
    }
}
