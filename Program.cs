using System;
using MixDaCasa.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MixDaCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new hamburgueriaContext())
            {
                var name = db.BurguerIngrediente
                    .Include(b => b.Burguer)
                    .Include(b => b.Ingrediente)
                    .Where(b => b.Ingrediente.Name.Contains("Burguer Mix da Casa"))
                    .OrderBy(b => b.Burguer.Preco)
                    .ThenBy(b => b.Burguer.Name);
                
                foreach (var burguer in name)
                {
                    Console.WriteLine($"O hamburguer chama-se {burguer.Burguer.Name} e custa {burguer.Burguer.Preco:C}");
                }
            }
        }
    }
}