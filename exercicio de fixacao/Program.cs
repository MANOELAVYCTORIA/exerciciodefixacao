using System;
using System.Globalization;
using System.Collections.Generic;
using exercicio_de_fixacao.Entities;


namespace exercicio_de_fixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();


            Console.Write("Quantidade de protudos? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <=n; i++)
            {
                Console.WriteLine($"Produto #{i} data: ");
                Console.Write("Comum, Usado ou Importado (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string name = Console.ReadLine();
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if (ch == 'u')
                {

                    Console.Write("Data de fabricação: (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else 
                {
                    Console.Write("Taxa da alfandega: ");
                    double customs = double.Parse(Console.ReadLine());
                    list.Add(new ImportedProduct(name, price, customs));
                }
            }

            Console.WriteLine();
            Console.WriteLine("ETIQUETA DE PREÇOS: ");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
