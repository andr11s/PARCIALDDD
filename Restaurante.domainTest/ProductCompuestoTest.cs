using NUnit.Framework;
using Restaurante.domain;
using System.Collections.Generic;

namespace Restaurante.domainTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /*CASO 1
         HU1. SALIDA DE PRODUCTO (3.5)
          COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCT
          CRITERIOS DE ACEPTACIÓN
            1. La cantidad de la salida de debe ser mayor a 0 
          DADO: EL CLIENTE REALIZA UNA COMPRA DE UN COMBO SENCILLO
         PRODUCTOs:
             idProduct: 0001, name: "pan de perro", cost: 1000, price: 1500, utilidad: "combo",
             idProduct: 0002, name: "salchicha", cost: 1000, price: 1500, utilidad: "combo",
             idProduct: 0003, name: "lamina de queso", cost: 1000, price: 1500, utilidad: "combo" 
        CUANDO: VA A REGITRAR UNA CANTIDAD MENOR  0
         ENTONCES: No se puede registrar un producto con cntidad menor o igual cero                  
         * 
        */

        [Test]
        public void NoPuedeRetirarCantidadMenorCeroProducto()
        {
             List<ProductSimple> ingredientes = new List<ProductSimple>();
            //ARRANGE PREPARAR DADO GIVEN
            
            var productosimple1 = new ProductSimple(idProduct: 0001, name: "pan de perro", cost: 1000, price: 1500, utilidad: "combo");
            productosimple1.Registrar(10);
            var productosimple2 = new ProductSimple(idProduct: 0002, name: "salchicha", cost: 1000, price: 1500, utilidad: "combo");
            productosimple2.Registrar(10);
            var productosimple3 = new ProductSimple(idProduct: 0003, name: "lamina de queso", cost: 1000, price: 1500, utilidad: "combo");
            productosimple3.Registrar(10);

            ingredientes.Add(productosimple1);
            ingredientes.Add(productosimple2);
            ingredientes.Add(productosimple3);
            //ACT ACCION CUANDO WHEN    

            var productoCompuesto = new ProductCompuesto(idProduct: 001, name: "perro sencillo", cost: 8000, price: 5000, ingredientes);
            var result = productoCompuesto.crearCombo(0);

            Assert.AreEqual("No se puede registrar un producto con cntidad menor o igual cero", result);
        }


        /*CASO 2
         HU1. SALIDA DE PRODUCTO (3.5)
          COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCT
          CRITERIOS DE ACEPTACIÓN
           3. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad
                existente de cada uno de su ingrediente
        4. Cada salida debe registrar el costo del producto y el precio de la venta
        5. El costo de los productos compuestos corresponden al costo de sus ingredientes por la
            cantidad de estos.
          DADO: EL CLIENTE REALIZA UNA COMPRA DE UN COMBO COMPUESTO
         PRODUCTOs:
             idProduct: 0001, name: "pan de perro", cost: 1000, price: 1500, utilidad: "combo",
             idProduct: 0002, name: "salchicha", cost: 1000, price: 1500, utilidad: "combo",
             idProduct: 0003, name: "lamina de queso", cost: 1000, price: 1500, utilidad: "combo" 
        CUANDO: VA A RETIRAR 1 COMBO "UN SUPER PERRO"
         ENTONCES: lA CANTIDAD RECIBIDA DEBE SER IGUAL A LA CANTIDAD RESTADA A LOS ONGREDIENTES
            EJEMPLO: 
                Para la venta de un super perro la cantidad que se necesita es:
                Un perro extragrande = CANTIDAD 1
                Una salchicha reanchera = CANTIDAD 1
                Dos laminas de queso = CANTIDAD 2
                
            Para cada ingrediente se le resta la cantidad registrada para cada ingrediente hay 10 
               
            En la comparacion final se compara la cantidad de los ingredientes con la deseas 
                Cantidad de ingrediente 1 es 9 y esperamos un 9 
         * 
        */

        [Test]
        public void disminuirCantidadPorductosCompuestosTest()
        {
            List<ProductSimple> ingredientes = new List<ProductSimple>();
            //ARRANGE PREPARAR DADO GIVEN

            var productosimple1 = new ProductSimple(idProduct: 0001, name: "perro extragrande", cost: 2000, price: 1500, utilidad: "combo");
            productosimple1.Registrar(10);
            var productosimple2 = new ProductSimple(idProduct: 0002, name: "salchicha ranchera", cost: 2000, price: 1500, utilidad: "combo");
            productosimple2.Registrar(10);
            var productosimple3 = new ProductSimple(idProduct: 0002, name: "lamina de queso", cost: 2000, price: 1500, utilidad: "combo");
            productosimple3.Registrar(10);


            ingredientes.Add(productosimple1);
            ingredientes.Add(productosimple2);
            ingredientes.Add(productosimple3);
            //ACT ACCION CUANDO WHEN    

            var productoCompuesto = new ProductCompuesto(idProduct: 001, name: "un super perro", cost: 8000, price: 5000, ingredientes);
            var result = productoCompuesto.Retirar(1);

            Assert.AreEqual(productosimple1.Cantidad, 9);
            Assert.AreEqual(productosimple2.Cantidad, 9);
            Assert.AreEqual(productosimple2.Cantidad, 9);


        }


        /*CASO 3
        HU1. SALIDA DE PRODUCTO (3.5)
         COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCT
         CRITERIOS DE ACEPTACIÓN
           1. La cantidad de la salida de debe ser mayor a 0 
         DADO: EL CLIENTE REALIZA UNA COMPRA DE UN COMBO SENCILLO
        PRODUCTOs:
            idProduct: 0001, name: "pan de perro", cost: 1000, price: 1500, utilidad: "combo",
            idProduct: 0002, name: "salchicha", cost: 1000, price: 1500, utilidad: "combo",
            idProduct: 0003, name: "lamina de queso", cost: 1000, price: 1500, utilidad: "combo" 
       CUANDO: VA A RETIRAR 1
        ENTONCES: El precio de la venta es de $6000                
        * 
       */
        [Test]
        public void ventaProductoCompuestoTest()
        {
            List<ProductSimple> ingredientes = new List<ProductSimple>();
            //ARRANGE PREPARAR DADO GIVEN

            var productosimple1 = new ProductSimple(idProduct: 0001, name: "perro extragrande", cost: 2000, price: 1500, utilidad: "combo");
            productosimple1.Registrar(10);
            var productosimple2 = new ProductSimple(idProduct: 0002, name: "salchicha ranchera", cost: 2000, price: 1500, utilidad: "combo");
            productosimple2.Registrar(10);
            var productosimple3 = new ProductSimple(idProduct: 0002, name: "lamina de queso", cost: 2000, price: 1500, utilidad: "combo");
            productosimple3.Registrar(10);


            ingredientes.Add(productosimple1);
            ingredientes.Add(productosimple2);
            ingredientes.Add(productosimple3);
            //ACT ACCION CUANDO WHEN    

            var productoCompuesto = new ProductCompuesto(idProduct: 001, name: "un super perro", cost: 8000, price: 5000, ingredientes);
            var result = productoCompuesto.Retirar(1);

            Assert.AreEqual("El precio de la venta es de $6000", result);
        }


    }
}
