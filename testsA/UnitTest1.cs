using Microsoft.AspNetCore.Mvc;
using TestAndSuperJest;
using TestAndSuperJest.Models;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new TestAndSuperJest.Controllers.ProductController();
            var lista = controller.listar();
            // retorna un objeto de ese tipo
            var res = Assert.IsType<OkObjectResult>(lista);
            //Assert, clase estatica de metodos para test
            //IsType, genericos
            //resultado general del re
            var list = Assert.IsType<List<ClassProduct>>(res.Value);
            //list[2];

            Assert.True(list.Count > 1);

            string el = "holapepi";
            string com = "pea";
            //Si pasa porque la segunda variable contiene lo de la variable principal asi sea un letra
            Assert.Contains(el, com);

            //No pasa porque en la lista si hay informacion
            Assert.Empty(list);

        }
    }
}