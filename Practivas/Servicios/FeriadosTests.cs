using Practicas.Servicios;
using System;
using Xunit;

namespace Practivas.test.Servicios
{
    public class FeriadosTests
    {
        private Feriados CreateFeriados()
        {
            return new Feriados();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var feriados = this.CreateFeriados();

            // Act


            // Assert
            Assert.True(false);
        }
    }
}
