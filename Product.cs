using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Product
    {
        private static int _id;
        private int _salePrice;
        public int ID { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice
        {
            get => _salePrice;
            set
            {
                try
                {
                    if (value < CostPrice)
                    {
                        throw new ArgumentException("SalePrice cannot be lower than CostPrice.");
                    }
                    _salePrice = (int)value;
                }
                catch (ArgumentException ex) {


                    Console.WriteLine("SalePrice cannot be lower than CostPrice.");
                }
               
            }
        }

        public Product(string name, double costPrice, double salePrice)
        {
            ID = ++_id;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }
    }
}
