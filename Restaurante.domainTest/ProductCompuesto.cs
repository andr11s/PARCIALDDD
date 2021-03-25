using NUnit.Framework;
using Restaurante.domain;

namespace Restaurante.domainTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /* 
        * HU1. ENTRADA DE PRODUCTO (1.5)
        * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
        * CRITERIOS DE ACEPTACIÓN
        * 
        *    1. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente de cada uno de su ingrediente
       */

        [Test]
        public void NoPuedeRetirarCantidadMayorCeroProducto()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productoCompuesto = new ProductCompuesto(idProduct: 001, name: "perro caliente", cost: 0, price: 0);

            var productosimple = new ProductSimple(idProduct: 0002, name: "pan perro cliente", cost: 1000, price: 1500, utilidad: "combo");

            //ACT ACCION CUANDO WHEN
            productosimple.Registrar(10);
            productoCompuesto.AgregarIngrediente(productosimple);


            var productosimple2 = new ProductSimple(idProduct: 0042, name: "Lamina de queso", cost: 1000, price: 2500, utilidad: "combo");
            productosimple2.Registrar(30);
            productoCompuesto.AgregarIngrediente(productosimple2);

            var result = productoCompuesto.Retirar(10);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("El producto: Salchicha se le resto la cantidad: 10, cantidad restante: 10", result);

            
        }
    }
}