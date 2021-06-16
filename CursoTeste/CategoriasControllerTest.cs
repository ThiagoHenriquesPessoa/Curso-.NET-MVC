using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CursoTeste
{
    public class CategoriasControllerTest
    {

        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste de Categoria" };

            _mockContext.Setup(m => m.Categoria).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Categoria.FindAsync(1)).ReturnsAsync(_categoria);
        }

        [Fact]
        public async Task Get_Categoria()
        {
            var servico = new CategoriasController(_mockContext.Object);

            await servico.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }
    }
}
