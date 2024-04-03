using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkEstudo1;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkEstudo1{
    public class Cliente{ //Modelo de entidade

        public int Id {get;set;}
        //Automaticamente Id sera uma primary key, devido a convencao pelo nome
        public string Nome {get;set;}
        [Column(TypeName = "varchar(100)")]
        public string? Sobrenome {get;set;}
       
        //praaplicar mudancas, adicione uma Migration
        //dotnet ef migrations add TabelaClientesSobrenome
        //dotnet ef database update
        public List<Pedido>? Pedidos{get;set;}=new List<Pedido>();
        //ja representa o relacionamento

    }
}