﻿using EntityFrameWorkEstudo1;

namespace EntityFrameworkEstudo1
{

    class Program
    {
        static void Main(string[] args)
        {
            //o Using garante que a conexao com o db sera fechada, mesmo se ocorrer algum tipo de erro durante a compilacao
            // O comando dispose faria o corte da conexao, mas, na ocorrencia de um ERRO, essa conexao nao seria fechada, pois
            //nao chegariamos nessa linha de instrucao no codigo
            using (var baseDeDados = new AppDbContext())
            {
               
                List<string> nomes = new List<string>();

                nomes.Add("Saulo");
                nomes.Add("Cora");
                nomes.Add("Samuel");
                foreach (var nome in nomes)
                {

                    baseDeDados.Clientes.Add(new Cliente { Nome = nome, Sobrenome = "Sobrenome"});
                }

                baseDeDados.SaveChanges();
                Console.WriteLine("Consulta 1");
                ConsultaClientes(baseDeDados);
                AdicionarPedido(1,12,baseDeDados);
                


            }


        }
        static void ConsultaClientes(AppDbContext context)
        {
            foreach (var client in context.Clientes)
            {
                Console.WriteLine($"Id:{client.Id} Nome:{client.Nome} Sobrenome:{client.Sobrenome}");


            }
        }
        static void AdicionarPedido(int id, decimal Valor, AppDbContext context)
        {
            var cliente = context.Clientes.Find(id);
            //retorna o objeto, ou seja, um ponteiro
            if (cliente == null)
            {
                Console.WriteLine("Id inexistente");
                return;
            }
            //Busca pela primary key
        
            context.SaveChanges();
        }
        static void LimparTabela(AppDbContext tabela)
        {
            foreach (var item in tabela.Clientes)
            {
              
                    tabela.Clientes.Remove(item);

            }
            tabela.SaveChanges();

        }
    }
}