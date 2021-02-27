using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace semLinqTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Нужно дополнить модель WeatherEvent, создать список этого типа List<>
            //И заполнить его, читая файл с данными построчно через StreamReader
            //Ссылка на файл https://www.kaggle.com/sobhanmoosavi/us-weather-events

            //Написать Linq-запросы, используя синтаксис методов расширений
            //и продублировать его, используя синтаксис запросов
            //(возможно с вкраплениями методов расширений, ибо иногда первого может быть недостаточно)

            //0. Linq - сколько различных городов есть в датасете.
            //1. Сколько записей за каждый из годов имеется в датасете.
            //2. Вывести данные самых долгих(топ - 1) снегопадов в Америке по годам(за каждый из годов) - с какого времени, по какое время, в каком городе
            //Потом будут еще запросы

            WeatherEvent we = new WeatherEvent()
            {
                EventId = "W-1",
                Type = WeatherEventType.Rain,
                Severity = Severity.Light,
                StartTime = DateTime.Now
            };
            StreamReader sr = new StreamReader("../../../table.csv");
            string curLine;
            List<WeatherEvent> weatherEvents = new List<WeatherEvent>();
            sr.ReadLine();
            while ((curLine = sr.ReadLine()) != null)
            {
                var props = curLine.Split(',');
                WeatherEvent curWe = new WeatherEvent()
                {
                    EventId = props[0],
                    Type = (WeatherEventType)(props[1])[0],
                    Severity = (Severity)(props[2][0]),
                    StartTime = DateTime.Parse(props[3].Replace(' ', 'T')),
                    EndTime = DateTime.Parse(props[4].Replace(' ', 'T')),
                    TimeZone = (TimeZone)(props[5])[3],
                    AirportCode = props[6],
                    // Делаю на русской локали приходится заменять
                    LocationLat = double.Parse(props[7].Replace('.', ',')),
                    LocationLng = double.Parse(props[8].Replace('.', ',')),
                    City = props[9],
                    Country = props[10],
                    State = props[11],
                    // Zipcode строка потому что где-то с 40080 коды становятся пустыми, потом опять возвращаются
                    ZipCode = props[12]
                };

                weatherEvents.Add(curWe);
            }
            Console.WriteLine($"0.Уникальных городов: {weatherEvents.Select(x => x.City).ToHashSet().Count}");
            Console.WriteLine($"1.Сколько записей за года:");
            var years = WeatherEvent.GetAllYears(weatherEvents);
            foreach (var e in years)
            {
                Console.WriteLine($"{e}: {WeatherEvent.GetYearAmount(weatherEvents, e)}");
            }
            Console.WriteLine($"2.Топ снегопад за каждый год:");
            foreach (var e in years)
            {
                Console.WriteLine($"{e}: {WeatherEvent.GetTopSnowfallByYear(weatherEvents, e)}");
            }
        }
    }

    class WeatherEvent
    {
        public string EventId { get; set; }
        public WeatherEventType Type { get; set; }
        public Severity Severity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeZone TimeZone { get; set; }
        public string AirportCode { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public double DeltaT
        {
            get => (StartTime - StartTime).TotalSeconds;
        }

        public static int GetYearAmount(List<WeatherEvent> events, int year)
            => events.Where(x => x.StartTime.Year == year).Count();
        public static List<int> GetAllYears(List<WeatherEvent> events)
            => events.Select(x => x.StartTime.Year).ToHashSet().ToList();
        public static WeatherEvent GetTopSnowfallByYear(List<WeatherEvent> events, int year)
            => events.Where(x => x.StartTime.Year == year && x.Type == WeatherEventType.Snow).OrderBy(x => x.DeltaT).Last();

        public override string ToString()
        {
            return $"{EventId} {Severity} {StartTime} {EndTime} {City} {Country}";
        }

    }
    // Чтобы не писать парсер строк в enum будем использовать первые буквы, благо они уникальные
    enum WeatherEventType
    {
        Unknown = 'U',
        Snow = 'S',
        Fog = 'F',
        Rain = 'R',
        Cold = 'C',
    }

    enum Severity
    {
        Unknown = 'U',
        Light = 'L',
        Severe = 'S',
    }

    enum TimeZone
    {
        Mountain = 'M',
        Central = 'C',
        Eastern = 'E',
        Pacific = 'P'
    }
}