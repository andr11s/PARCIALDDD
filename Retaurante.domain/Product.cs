using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.domain
{
   public abstract class Product
    {
        protected Product(decimal idproduct, string name, decimal cost, decimal price)
        {
            idProduct = idProduct;
            Name = name;
            Cost = cost;
            Price = price;
        }

        public decimal idProduct { get;}
        public string Name { get;}
        public decimal Cost { get;}
        public decimal Price { get;}

        public virtual string Registrar(int Cantidad)
        {
            return "";
        }

        public virtual string Retirar(int cantidad)
        {
            return "";
        }

    }

     
}
