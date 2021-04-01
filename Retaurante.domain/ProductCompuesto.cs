using Retaurante.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.domain
{
    public class ProductCompuesto : Product
    {
        private List<ProductSimple> ComboProductos = new List<ProductSimple>();
        private List<Inventory> inventarioVentas = new List<Inventory>();


        ProductSimple cproductsimple;
        
 
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }

        public ProductCompuesto(decimal idProduct, string name, decimal cost, decimal price, List<ProductSimple> ingredientes) : base(idProduct, name, cost, price)
        {
            ComboProductos = ingredientes;
        }

        public string Retirar(int cantidadRetirar)
        {
            decimal costo = 0 , totalPagar = 0, precioTotal = 0;
            if(cantidadRetirar <= 0) return "No se puede vender un producto con cantidad menor o igual a cero";

            foreach (var product in ComboProductos)
            {
                if (Name.Equals("un super perro"))
                {
                    if (product.Name.Equals("perro extragrande"))
                    {
                        product.Cantidad -= 1;
                    }
                    if (product.Name.Equals("salchicha ranchera"))
                    {
                        product.Cantidad -= 1;
                    }
                    if (product.Name.Equals("lamina de queso"))
                    {
                        product.Cantidad -= 2;
                    }
                    totalPagar += product.Cost;
                }              
            }


            var precioVenta = cantidadRetirar * totalPagar;

            //llevo el registro la venta del producto agregandolo a la lista
            inventarioVentas.Add(new Inventory(cantidadRetirar, Name, totalPagar, Price, "Venta"));
            return $"El precio de la venta es de ${precioVenta}";
        }

        public string crearCombo(int cantidad)
        {
          
            decimal costoProducto = 0, utilidad = 0;
            
         if (cantidad <= 0) return "No se puede registrar un producto con cntidad menor o igual cero";
            
          foreach(var product in ComboProductos)
            { 
                costoProducto += product.Cost; 
            }

            if (costoProducto > 0)
            {
                utilidad = Precio - costoProducto;
                //llevo el registro los productos agregados
                inventarioVentas.Add(new Inventory(cantidad, Name, costoProducto, Price, "agregado"));
                return $"El producto fue creado costo total: {costoProducto:n2}, utilidad: {utilidad:n2}";
            }  
            return "El producto no pudo ser creado"; 
            
        }


    }
}
