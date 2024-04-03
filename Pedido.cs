using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameWorkEstudo1;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkEstudo1
{
    public class Pedido{
        public int Id {get;set;}
        public decimal valor {get;set;}
        public Cliente ClienteID;
      
    }
}