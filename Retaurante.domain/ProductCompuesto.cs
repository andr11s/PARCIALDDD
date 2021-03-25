using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.domain
{
    public class ProductCompuesto : Product
    {
        private List<ProductSimple> Ingredientes;
        private decimal NumeroIngredientes { get; set; }

        public int cantidadminima { get; set; }
        public int cantidadRequeridaIngredienteTotal = 0;


        public ProductCompuesto(decimal idProduct, string name, decimal cost, decimal price) : base(idProduct, name, cost, price)
        {
            NumeroIngredientes = 0;
        }

        public string Retirar(decimal codigo, string nombre, decimal numeroIngredientes)
        {

            if(numeroIngredientes <= 0) return "No se puede vender un producto con cantidad menor o igual a cero";

            return "";
        }

        public void AgregarIngrediente(ProductSimple ingrediente)
        {
            Ingredientes.Add(ingrediente);
        }
    }
}
