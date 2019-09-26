using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceReference1.RegistrarGastosClient obj = new ServiceReference1.RegistrarGastosClient();
            ServiceReference1.Inmuebles obj2 = new ServiceReference1.Inmuebles();
            ServiceReference1.Inmuebles rpta = new ServiceReference1.Inmuebles();
            obj2.codigo = "004";
            obj2.direccion = "San Miguel";
            obj2.gAlquiler = 600;
            obj2.gMantenimiento = 500;
            obj2.gAdicionales = 300;
            rpta = obj.CrearInmueble(obj2);

            if (rpta != null)
            {

                Assert.AreEqual(rpta.codigo, "004");                
                Assert.AreEqual(rpta.direccion, "San Miguel");
                Assert.AreEqual(rpta.gAlquiler, 600);
                Assert.AreEqual(rpta.gMantenimiento, 500);
                Assert.AreEqual(rpta.gAdicionales, 300);

            }
        }
    }
}
