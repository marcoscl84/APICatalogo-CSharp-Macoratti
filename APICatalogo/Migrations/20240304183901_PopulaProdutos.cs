using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImageUrl,Estoque,DataCadastro,CategoriaId) values ('Coke','Refri de Cola 350ml',5.45,'coke.jpg',50,now(),1)");
            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImageUrl,Estoque,DataCadastro,CategoriaId) values ('Sanduba','Sanduba de atum',8.90,'sand.jpg',50,now(),1)");
            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImageUrl,Estoque,DataCadastro,CategoriaId) values ('Pudim','Pudim de leite',4.30,'pudim.jpg',50,now(),1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
