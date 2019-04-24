using ClairG.ChatApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new EFDbContext())
            {
                ctx.Database.Delete();
                ctx.Database.Create();
            }

            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}
