using System;
using Herrera.LeilaoOnline.Core;
using Xunit;

namespace Herrera.LeilaoOnline.Tests;

public class LanceCtor
{
    [Fact]
    public void LancaArgumentExceptionDadosValorNegativo()
    {
        //Arrange
        var valorNegativo = -100;

        var myException = Assert.Throws<ArgumentException>(
            //Act
            () => new Lance(null, valorNegativo));

        //Assert
        Assert.Equal("Deu ruim!", myException.Message);
    }
}