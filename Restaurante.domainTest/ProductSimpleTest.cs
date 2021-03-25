using NUnit.Framework;
using Restaurante.domain;

namespace Restaurante.solution
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*CASO 1
          HU1. ENTRADA DE PRODUCTO (1.5)
          COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
          CRITERIOS DE ACEPTACIÓN
            1. La cantidad de la entrada de debe ser mayor a 0
          DADO: EL CLIENTE DILIGENCIA 15 ENTRADAS AL SISTEMAS
         PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta"
        CUANDO: VA A REGITRAR UNA CANTIDAD MAYOR  0 
         ENTONCES: EL SISTEMA MOSTRAR UN MENSAJE el registro del producto: Salchicha fue realizado, cantidad: 15                     
         * 
        */

        [Test]
        public void RegistrarCantidadProductoMayorCeroTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            var result = productosimple.Registrar(15); 
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("el registro del producto: Salchicha fue realizado, cantidad: 15", result);
        }

        /*CASO 2 SI EL PRODUCTO ES IGUAL A 0 
         * HU1. ENTRADA DE PRODUCTO (1.5)
         * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
         * CRITERIOS DE ACEPTACIÓN
         *    1. La cantidad de la entrada de debe ser mayor a 0
         *     DADO: EL CLIENTE DILIGENCIA 0 ENTRADAS AL SISTEMAS
         PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta"
        CUANDO: VA A REGITRAR UNA CANTIDAD  0 
         ENTONCES: EL SISTEMA MOSTRAR UN MENSAJE la cantidad de registro es incorrecta  
        */

        [Test]
        public void NoPuedeRegistrarCantidadCeroTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            var result = productosimple.Registrar(0);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("la cantidad de registro es incorrecta", result); 
        }

        /*CASO 3 SI EL PRODUCTO ES MENOS A CERO 
         * HU1. ENTRADA DE PRODUCTO (1.5)
         * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
         * CRITERIOS DE ACEPTACIÓN
         *    1. La cantidad de la entrada de debe ser mayor a 0
         *     DADO: EL CLIENTE DILIGENCIA 0 ENTRADAS AL SISTEMAS
             PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta"
            CUANDO: VA A REGITRAR UNA CANTIDAD MENOR A 0 
             ENTONCES: EL SISTEMA MOSTRAR UN MENSAJE la cantidad de registro es incorrecta
        */
        [Test]
        public void NoPuedeRegistrarCantidadNegativaTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            var result = productosimple.Registrar(-15);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("la cantidad de registro es incorrecta", result);
        }

        /* CASO 4 RETIRAR PRODUCTOS DONDE LA CANTIDAD SEA MAYOR A CERO
        * HU1. ENTRADA DE PRODUCTO (1.5)
        * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
        * CRITERIOS DE ACEPTACIÓN
        *    1. En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente del producto.
        *    DADO: EL CLIENTE DILIGENCIA 20 ENTRADAS AL SISTEMAS
             PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta"
            CUANDO: VA A RETIRAR UNA CANTIDAD 20 
             ENTONCES: El producto: Salchicha se le resto la cantidad: 10, cantidad restante: 10
       */
        [Test]
        public void RetirarCantidadMayorCeroTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            productosimple.Registrar(20);
            var result = productosimple.Retirar(10);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("El producto: Salchicha se le resto la cantidad: 10, cantidad restante: 10", result);
        }

        /* CASO 5 El producto a retirar tiene que tener existencia en el inventrio
       * HU1. ENTRADA DE PRODUCTO (1.5)
       * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
       * CRITERIOS DE ACEPTACIÓN
       *    1.  En caso de un producto sencillo la cantidad de la salida se le disminuir
             a la cantidad existente del producto.
          DADO: EL CLIENTE DILIGENCIA uda salida de 10 ENTRADAS AL SISTEMAS
             PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "ventaDIrecta"
            CUANDO: VA A RETIRAR UNA CANTIDAD 10 
             ENTONCES: el producto que desea retirar no tiene existencia 
      */

        [Test]
        public void NoPuedeRetirarProductoSinExistenciaTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            var result = productosimple.Retirar(10);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("el producto que desea retirar no tiene existencia", result);
        }


        /* CASO 6 El tipo de venta no corresponde con el regitrado en el producto
       * HU1. ENTRADA DE PRODUCTO (1.5)
       * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
       * CRITERIOS DE ACEPTACIÓN
       *     1.En caso de un producto sencillo la cantidad de la salida se le disminuir� 
          a la cantidad existente del producto.

         DADO: EL CLIENTE DILIGENCIA uda salida de 100 ENTRADAS AL SISTEMAS
             PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "combo"
            CUANDO: VA A RETIRAR UNA CANTIDAD 10 
             ENTONCES: el producto que desea retirar no corresponde a venta directa 
      */
        [Test]
        public void NoPuedeRetirarProductoPorTipoTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "combo");
            //ACT ACCION CUANDO WHEN
            productosimple.Registrar(100);
            var result = productosimple.Retirar(10);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("el producto que desea retirar no corresponde a venta directa", result);
        }


        /* CASO 6 El tipo de venta no corresponde con el regitrado en el producto
       * HU1. ENTRADA DE PRODUCTO (1.5)
       * COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
       * CRITERIOS DE ACEPTACIÓN
       *    1.  En caso de un producto sencillo la cantidad de la salida se le disminuir� 
              a la cantidad existente del producto.
        
         DADO: EL CLIENTE DILIGENCIA uda salida de 100 ENTRADAS AL SISTEMAS
             PRODUCTO: idProduct: 0001, name: "Salchicha",cost: 1200, price: 2000,utilidad: "combo"
            CUANDO: VA A RETIRAR UNA CANTIDAD 101
             ENTONCES: la cantidad solicitada es mayor que la cantidad registrada en el sistema
      */

        [Test]
        public void NoPuedeRetirarCantidadMayorQueInventarioTest()
        {
            //ARRANGE PREPARAR DADO GIVEN
            var productosimple = new ProductSimple(idProduct: 0001, name: "Salchicha", cost: 1200, price: 2000, utilidad: "ventaDIrecta");
            //ACT ACCION CUANDO WHEN
            productosimple.Registrar(100);
            var result = productosimple.Retirar(101);
            //ASSERT AFIRMACION ENTONCES THEN
            Assert.AreEqual("la cantidad solicitada es mayor que la cantidad registrada en el sistema", result);
        }
    }
}