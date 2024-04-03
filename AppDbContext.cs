using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameWorkEstudo1;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkEstudo1
{
    public class AppDbContext : DbContext
    //esse e o db
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //fala onde esta o banco de dados
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=NovaBaseDeDados;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().Property(c=>c.Nome).HasColumnType("varchar").HasMaxLength(100);
        }
        //cada tabela do banco de dados
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Pedido> Pedidos {get;set;}
        //A tabela utiliza a classe clientes, ou seja, é uma tabela de que contem objetos da classe clientes
        //Os atributos dessa classe correspondem as colunas
    }
}