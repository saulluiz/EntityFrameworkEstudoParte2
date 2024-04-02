using EntityFrameWorkEstudo1;

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
                baseDeDados.Clientes.Add(new Cliente { Nome = "Saulo" });
                baseDeDados.Clientes.Add(new Cliente { Nome = "Luiz" });
                baseDeDados.Clientes.Add(new Cliente { Nome = "Oliveira" });
                baseDeDados.SaveChanges();
                Console.WriteLine("Consulta 1");
                ConsultaClientes(baseDeDados);
                AlterarCliente(2,"Saulo",baseDeDados);
                Console.WriteLine("Consulta 2");
                ConsultaClientes(baseDeDados); 
                //LimparTabela(baseDeDados);
                Console.WriteLine("Consulta 3");
                ConsultaClientes(baseDeDados);
               // baseDeDados.Dispose();
               int value=0;
            }
                using (var bancoDeDados = new AppDbContext()){
                 
                    Console.WriteLine("Verificando se utiliza-se o mesmo db;");
                    //A resposta é sim, ou seja, bancoDeDados é somente a conexao
                    ConsultaClientes(bancoDeDados);
                //ConsultaClientes(baseDeDados);
                //essa conexao nao existe mais, pois utilizamos dentro do using
                // e todas as variaveis utilizadas dentro do using, deixaram de existir



                }

        }
        static void ConsultaClientes(AppDbContext context)
        {
            foreach (var client in context.Clientes)
            {
                Console.WriteLine($"Id:{client.Id} Nome:{client.Nome}");

            }
        }
        static void AlterarCliente(int id, string nome,AppDbContext context)
        {
           var cliente=context.Clientes.Find(id);
           //retorna o objeto, ou seja, um ponteiro
           if(cliente==null){
            Console.WriteLine("Id inexistente");
            return;
           }
           //Busca pela primary key
           cliente.Nome= nome;
           context.SaveChanges();
        }
        static void LimparTabela(AppDbContext tabela){
            foreach(var item in tabela.Clientes){
                tabela.Clientes.Remove(item);
                
            }
            tabela.SaveChanges();

        }
    }
}