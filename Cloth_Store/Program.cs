using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloth_Store
{
    class Program

    {
        //variáveis globais
        static string[,] cadprodutos = new string[100, 4];
        static int nProduto = 0;
        static int dadoP = 0;//coluna da matriz do cadastro do produto
        static int novoProduto = 0;//linha da matriz usada apenas no cadastro do produto

        static string[,] vendas = new string[100, 4]; // matriz com uma coluna a mais do que o projeto, para armazenar info (valor da venda)
        static int nVenda = 0; //linha da matriz de venda   
        static int dadoV = 0;//coluna da matriz de venda   



        static void Main(string[] args)
        {


            int opcaoMenu = Menu();
            while (opcaoMenu != 0)
            {
                Console.Clear();
                switch (opcaoMenu)
                {

                    case 1:
                        cadastroProduto();

                        break;

                    case 2:
                        Vendas();

                        break;

                    case 3:
                        relatorioVendas();
                        break;

                    case 4:
                        relatorioVendasFuncionario();
                        break;

                    default:
                        Console.WriteLine("Opção inválida");

                        break;
                }
                Console.Clear();
                opcaoMenu = Menu();


            }
            Console.ReadKey();
        }
        static int Menu()
        {
            Console.WriteLine("============== Menu Incial ====================");
            Console.WriteLine("  ");
            Console.WriteLine("[1] - Cadastrar produtos");
            Console.WriteLine("[2] - Realizar uma venda");
            Console.WriteLine("[3] - Relatório de vendas");
            Console.WriteLine("[4] - Relatório de vendas por funcionários");
            Console.WriteLine("[0] - Sair");
            int opcaoMenu = int.Parse(Console.ReadLine());
            return opcaoMenu;
        }
        static string cadastroProduto()
        {
            int reposta1 = 0;
            int reposta2 = 0;
            dadoP = 0;  //coluna da matriz produto (variavel global)


            while (reposta2 != 1)
            {
                while (reposta1 != 1)
                {
                    Console.WriteLine("======== Menu Cadastro =========");
                    Console.WriteLine("  ");

                    Console.WriteLine("Digite o código do produto: ");
                    cadprodutos[novoProduto, dadoP] = Console.ReadLine();
                    dadoP++;
                    Console.Clear();

                    Console.WriteLine("======== Menu Cadastro =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Digite a descrição do produto: ");
                    cadprodutos[novoProduto, dadoP] = Console.ReadLine();
                    dadoP++;
                    Console.Clear();

                    Console.WriteLine("======== Menu Cadastro =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Informe o valor do produto: ");
                    cadprodutos[novoProduto, dadoP] = Console.ReadLine();
                    dadoP++;
                    Console.Clear();

                    Console.WriteLine("======== Menu Cadastro =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Informe a quantidade em estoque: ");
                    cadprodutos[novoProduto, dadoP] = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("======== Menu Cadastro =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Confira o cadastro:");
                    Console.WriteLine("  ");
                    Console.WriteLine("Código do produto: " + cadprodutos[novoProduto, 0]);
                    Console.WriteLine("Descrição do produto: " + cadprodutos[novoProduto, 1]);
                    Console.WriteLine("Valor do produto: " + cadprodutos[novoProduto, 2]);
                    Console.WriteLine("Quantidade em estoque: " + cadprodutos[novoProduto, 3]);
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("Deseja salvar [1]Sim / [0]Não");

                    reposta1 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    dadoP = 0; //coluna da matriz produto

                }

                novoProduto++;

                Console.WriteLine("======== Menu Cadastro =========");
                Console.WriteLine("[0] Cadastrar novo produto.");
                Console.WriteLine("[1] Retornar ao Menu inicial.");
                reposta2 = int.Parse(Console.ReadLine());

                Console.Clear();

                reposta1 = 0;
            }
            return cadprodutos[nProduto, dadoP];

        }
        static void Vendas()
        {
            int totalEstoque = 0;
            int linhaProduto = 0;
            int Resposta1 = 0;

            int Resposta3 = 0;
            double totalDaVenda; // variavel criada para armazenar o resultado da multiplicação (quantidade * valor do produto)
            bool cadastroDeProduto = false;


            while (Resposta3 != 1)
            {
                Console.WriteLine("======== Menu Vendas =========");
                Console.WriteLine("  ");

                Console.WriteLine("Digite o código do produto: ");
                vendas[nVenda, dadoV] = Console.ReadLine();



                for (nProduto = 0; nProduto < 100; nProduto++)
                {
                    if (Convert.ToInt32(vendas[nVenda, dadoV]) == Convert.ToInt32(cadprodutos[nProduto, dadoP]))
                    {
                        linhaProduto = nProduto;
                        nProduto = 100;
                        dadoP = 0;
                        dadoV++;
                        cadastroDeProduto = true;
                    }
                }

                if (cadastroDeProduto == false)
                {
                    Console.Clear();
                    Console.WriteLine("======== Menu Vendas =========");
                    Console.WriteLine("Código do produto não se refere aos produtos cadastrado na base de dados");
                    Console.WriteLine("Deseja cadastrar um produto? [1]Sim / [2]Não");
                    Resposta1 = int.Parse(Console.ReadLine());

                    if (Resposta1 == 1)
                    {
                        Console.Clear();
                        cadastroProduto();
                        Console.Clear();
                        nProduto = 0;
                    }
                    if (Resposta1 == 2)
                    {

                        nProduto = 100;
                        Console.Clear();
                    }
                }


                if (Resposta1 != 1 && Resposta1 != 2)
                {


                    Console.Clear();

                    Console.WriteLine("======== Menu Vendas =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Digite o código do funcinário: ");
                    vendas[nVenda, dadoV] = Console.ReadLine();
                    dadoV++;
                    Console.Clear();

                    Console.WriteLine("========  Menu Vendas =========");
                    Console.WriteLine("  ");
                    Console.WriteLine("Informe a quantidade vendida: ");
                    vendas[nVenda, dadoV] = Console.ReadLine();
                    totalDaVenda = Convert.ToDouble(vendas[nVenda, dadoV]) * Convert.ToDouble(cadprodutos[linhaProduto, 2]);
                    vendas[nVenda, 3] = Convert.ToString(totalDaVenda);//coluna extra na matriz de acordo com o projeto

                    if (Convert.ToInt32(vendas[nVenda, dadoV]) <= Convert.ToInt32(cadprodutos[linhaProduto, 3]))
                    {

                        Console.Clear();

                        Console.WriteLine("========  Menu Vendas =========");
                        Console.WriteLine("  ");
                        Console.WriteLine("Confira a venda:");
                        Console.WriteLine("  ");
                        Console.WriteLine("Código do produto: " + vendas[nVenda, 0]);
                        Console.WriteLine("Descrição do produto: " + cadprodutos[linhaProduto, 1]);
                        Console.WriteLine("Código do vendedor: " + vendas[nVenda, 1]);
                        Console.WriteLine("Valor do produto: " + cadprodutos[linhaProduto, 2]);
                        Console.WriteLine("Valor total da venda: " + vendas[nVenda, 3]);
                        Console.WriteLine("  ");
                        Console.WriteLine("  ");

                        Console.ReadKey();

                        totalEstoque = (Convert.ToInt32(cadprodutos[linhaProduto, 3]) - Convert.ToInt32(vendas[nVenda, 2]));
                        cadprodutos[linhaProduto, 3] = Convert.ToString(totalEstoque);

                        dadoV = 0;
                        nVenda++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Estoque insuficiente");
                        Console.ReadKey();

                    }
                }//fim if codigo do produto            
                Console.Clear();
                Console.WriteLine("======== Menu Cadastro =========");
                Console.WriteLine("[0] Realizar nova venda.");
                Console.WriteLine("[1] Retornar ao Menu inicial.");
                Resposta3 = int.Parse(Console.ReadLine());
                dadoV = 0;
                Console.Clear();
                totalEstoque = 0;
            }
        }
        static void relatorioVendas()
        {
            Console.Clear();

            int l;
            double totalVendas = 0;

            Console.WriteLine("======== Relatório de Vendas =========");
            for (l = 0; l < 100; l++)
            {
                Console.Write(vendas[l, 0] + "  " + vendas[l, 1] + "  " + vendas[l, 3]);

                totalVendas = totalVendas + Convert.ToDouble(vendas[l, 3]);
            }
            Console.WriteLine(" ");
            Console.WriteLine("O total de vendas realizada é: " + totalVendas);

            Console.ReadKey();
        }
        static void relatorioVendasFuncionario()
        {
            Console.Clear();

            Console.WriteLine("Digite o código do funcionário: ");
            string codigoFuncionario = Console.ReadLine();
            Console.Clear();

            int l;
            double totalVendas = 0;


            Console.WriteLine("======== Relatório de Vendas Funcionário =========");
            for (l = 0; l < 100; l++)
            {
                if (codigoFuncionario == vendas[l, 1])
                {
                    Console.WriteLine(vendas[l, 0] + "  " + vendas[l, 1] + "  " + vendas[l, 3] + "  ");
                    totalVendas = totalVendas + Convert.ToDouble(vendas[l, 3]);
                }
            }

            Console.WriteLine("O total de vendas realizada é " + totalVendas);
            Console.WriteLine("A comissão do vendedor é: " + ((totalVendas * 10) / 100));

            Console.ReadKey();
        }





    }
}


