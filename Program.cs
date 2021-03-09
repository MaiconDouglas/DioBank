using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1" : 
                            ListarContas();
                        break;
                    case "2" : 
                            CadastrarConta();
                        break;
                    case "3" : 
                           Transferir();
                        break;
                    case "4" : 
                            Sacar();
                        break;
                    case "5" : 
                            Depositar();
                        break;
                    case "C" : Console.Clear();
                        break;
                    default :
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar os serviços MyBank 8) ");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Informe a conta de origem :");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Informe a conta de destino :");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser transferido :");
            double valorTransferir = double.Parse(Console.ReadLine());

            ListContas[indiceContaOrigem].Transferir(valorTransferir, ListContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Informe a conta que deseja depositar :");
            int indiceConta = int.Parse(Console.ReadLine()); 

            Console.Write("Qual valor deseja depositar ?");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }

            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("Cadastrar nova Conta :");
            Console.WriteLine();
            Console.Write("Digite 1 para conta Física ou 2 para conta Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome :");
                String entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo inicial :");
                double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito : ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                                    saldo : entradaSaldo,
                                                    credito : entradaCredito,
                                                    nome : entradaNome);
            ListContas.Add(novaConta);        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" MyBank a seu dispor !!");
            Console.WriteLine();
            Console.WriteLine(" Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine(" 1 - Listar Contas");
            Console.WriteLine(" 2 - Cadastrar nova Conta");
            Console.WriteLine(" 3 - Transferir");
            Console.WriteLine(" 4 - Sacar");
            Console.WriteLine(" 5 - Depositar");
            Console.WriteLine(" C - Limpar tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        } 
    }
}
