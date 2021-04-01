using System;
using System.Collections.Generic;
using System.Text;

namespace Retaurante.domain
{
   public class Inventory
    { 
        public Inventory(int cantidadExistente, string nombreProducto, decimal costoProducto, decimal precioProducto, string tipoProducto)
        {
            NombreProducto = nombreProducto;
            CostoProducto = costoProducto;
            PrecioProducto = precioProducto;
            CantidadExistente = cantidadExistente;
            TipoProducto = tipoProducto;
        }

        public string NombreProducto { get; set; }
        public decimal CostoProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int CantidadExistente { get; set; }
        public string TipoProducto { get; set; }

    }
}
