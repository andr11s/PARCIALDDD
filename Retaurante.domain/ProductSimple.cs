using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.domain
{
    public class ProductSimple : Product
    {

        private decimal Cantidad { get; set; }
        private string Utilidad { get;set; }
        string Estado { get; set; }
        private decimal CostoProducto { get; set; }
        private decimal PrecioVenta { get; set; }

        public ProductSimple(decimal idProduct, string name, decimal cost, decimal price, string utilidad) : base(idProduct, name, cost, price)
        {
            Cantidad = 0;
            Utilidad = utilidad;
            Estado = "nodisponible";
        }

      

        public override string Registrar(decimal cantidadRegistro)
        {
            if (cantidadRegistro > 0)
            {
                Cantidad += cantidadRegistro;
                Estado = "Disponible";
                return $"el registro del producto: {Name} fue realizado, cantidad: {cantidadRegistro}";
            }
            return "la cantidad de registro es incorrecta";

        }

        public override string Retirar(decimal cantidadRegistro)
        {
            if (Estado.Equals("nodisponible"))
            {
                return "el producto que desea retirar no tiene existencia";
            }

            if (Utilidad.Equals("combo"))
            {
                return "el producto que desea retirar no corresponde a venta directa";
            }


            if (cantidadRegistro <= 0)
            {
                return "La cantidad para retirar el producto es incorrecta";
            }

            if (cantidadRegistro > Cantidad)
            {
                return "la cantidad solicitada es mayor que la cantidad registrada en el sistema";
            }

            

            if (Cantidad == 0)
            {
                Estado = "nodisponible";
            }

            Cantidad -= cantidadRegistro;
            return $"El producto: {Name} se le resto la cantidad: {cantidadRegistro}, cantidad restante: {Cantidad}";
        }

    }
}
