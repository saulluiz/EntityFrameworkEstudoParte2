using System.Security.AccessControl;
using EntityFrameWorkEstudo1;
using Microsoft.EntityFrameworkCore.Storage;

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

                    baseDeDados.Clientes.Add(new Cliente { Nome = nome, Sobrenome = "Sobrenome" });
                }

                baseDeDados.SaveChanges();
                Console.WriteLine("Consulta 1");
                ConsultaClientes(baseDeDados);
                Console.WriteLine("Digite o id que deseja adicionar o pedido de valor 120");
                AdicionarPedido(int.Parse(Console.ReadLine()), 120, baseDeDados);
                string auxEnd = "";
                while (auxEnd != "fim")
                {
                    System.Console.WriteLine("Qual cliente deseja conferir os pedidos?(Digite Fim para finalizar o programa)");
                    auxEnd = Console.ReadLine();

                    if (auxEnd == "fim") break;
                    else
                    {
                        var cliente = baseDeDados.Clientes.Find(int.Parse(auxEnd));
                        foreach (var pedido in cliente.Pedidos)
                        {
                            Console.WriteLine($"Pedido {pedido.Id} valor:{pedido.valor}");
                        }

                    }
                }
                Console.WriteLine("Qual nome deseja encontrar o Id?");
                
                var buscaCliente =baseDeDados.Clientes.Where(c=>c.Nome==Console.ReadLine()).FirstOrDefault();
                //O where retorna um conjunto, o First ou default faz com que retorne nulo se nao existir, ou o primeiro que encontrar
                Console.WriteLine("O Id do nome buscado é "+buscaCliente.Id);



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
            cliente.Pedidos.Add(new Pedido { valor = Valor });
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