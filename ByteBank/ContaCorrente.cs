// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }
        public static int ContadorTransferenciasNaoPermitidas { get; private set; }
        public int Agencia{ get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if(numeroAgencia <= 0)
                throw new ArgumentException("Agencia não pode ser menor ou igual a 0.", nameof(numeroAgencia)); ;

            if(numeroConta <= 0)
                throw new ArgumentException("Numero de conta não pode ser menor ou igual a 0.", nameof(numeroConta)); ;


            Agencia = numeroAgencia;
            Numero = numeroConta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            }
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(_saldo, valor);
            }
            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                //Criação de nova Exceção com a exceção de SaldoInsuficienteException como InnerException
                throw new Exception("Operação não realizada", ex);
            }
            contaDestino.Depositar(valor);
            
        }
    }
}
