using Lab5.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class Program
    {
        public void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<CarContext>();
                SeedDB(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private void SeedDB(CarContext context)
        {
            var carItemList = context.CarItems.ToList();
            if (carItemList.Count > 0) return;

            var cars = new List<Car>();
            cars.Add(new Car
            {
                Id = 1,
                Marka = "Ford",
                Model = "Mustang",
                MocSilnika = 450,
                Przebieg = 12000,
                Rocznik = DateTime.Now.ToString(),
            });
            cars.Add(new Car
            {
                Id = 2,
                Marka = "Dodge",
                Model = "Charger",
                MocSilnika = 520,
                Przebieg = 40000,
                Rocznik = DateTime.Now.ToString(),
            });
            cars.Add(new Car
            {
                Id = 3,
                Marka = "Dodge",
                Model = "Demon SRT",
                MocSilnika = 840,
                Przebieg = 2000,
                Rocznik = DateTime.Now.ToString(),
            });
            cars.Add(new Car
            {
                Id = 4,
                Marka = "Dodge",
                Model = "Viper",
                MocSilnika = 540,
                Przebieg = 128000,
                Rocznik = DateTime.Now.ToString(),
            });
            context.AddRange(cars);
            context.SaveChanges();

        }

    }

}
