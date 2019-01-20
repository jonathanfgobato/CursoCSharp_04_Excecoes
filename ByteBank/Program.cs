using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exemplo try catch
            /*
            try
            {
                Console.WriteLine("Digite o número a ser divididoo");
                int dividido = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o número divisor");
                int divisor = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Resultado da divisão: { dividido / divisor}");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Não é possível divisão por 0");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Codigo erro { e.HResult}");
                Console.WriteLine($"Erro de { e.Message}\n");
                Console.WriteLine($"Pilha de rastreio {e.StackTrace}");
            }
            finally
            {
                Console.WriteLine("bla");
            }
            */
            #endregion

            try
            {
                ContaCorrente contaCorrente = new ContaCorrente(10, 10);
                ContaCorrente contaCorrente2 = new ContaCorrente(10, 11);

                contaCorrente.Depositar(50);

                Console.WriteLine($"Saldo da conta {contaCorrente.Saldo}");
                contaCorrente.Transferir(10000, contaCorrente2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argumento que ocorreu problema: {ex.ParamName}");
                Console.WriteLine($"Erro ocorrido: {ex.Message}");
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine($"Exceção do tipo {nameof(SaldoInsuficienteException)}");
                Console.Write($"Pilha de execução {ex.StackTrace}");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
            finally
            {
                Console.WriteLine("\nFechando conexão...\n");
            }

            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
