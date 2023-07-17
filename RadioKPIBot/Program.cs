

  using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.DependencyInjection;
// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RadioKPIBot.DataAccess;
using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadioKPIBot;
using RadioKPIBot.DataAccess.Repository;

class Program
{
    
    static void Main(string[] args)
    {
       // Bot bot = new Bot(new UnitOfWork(new AppDbContext(new DbContextOptions<AppDbContext> { })));
        Bot bot = new Bot();
        bot.Start();
        Console.ReadKey();



        //var serviceProvider = new ServiceCollection()
        //    .AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer("Data Source=WIN-QMKROI2FDJV;Initial Catalog=RadioKPIBot;Integrated Security=True;"))
        //    .BuildServiceProvider();




        //using (var context = serviceProvider.GetService<AppDbContext>())
        //{
        //    // Your code here
        //}
    }
}