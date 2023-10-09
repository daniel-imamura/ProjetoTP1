//Fábio Alves Dos Santos  RA: 20129
//Daniel Henry Matheus Imamura  RA:20128
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
class Matematica
{
    int numInt;
    double numReal;
    public Matematica(double valorDesejado)
    {
        numInt = Convert.ToInt32(valorDesejado);
        numReal = valorDesejado;
    }

    public int Fatorial()
    {
        var umFatorial = new Produtorio();
        var contaFatorial = new Contador(1, numInt, 1);

        while (contaFatorial.Prosseguir())
        {
            umFatorial.Multiplicar(contaFatorial.Valor);
            contaFatorial.Contar();
        }
        return Convert.ToInt32(umFatorial.Valor);
    }

    public string Divisores()
    {
        int quociente,
            resto,
            metadeNum,
            divisor;

        string lista = "";
        metadeNum = numInt / 2;
        var contaDivisores = new Contador(2, metadeNum, 1);

        while (contaDivisores.Prosseguir())
        {
            divisor = Convert.ToInt32(contaDivisores.Valor);
            quociente = numInt / divisor;
            resto = numInt - quociente * divisor;

            if (resto == 0)
                lista = lista + Convert.ToString(divisor) + ", ";

            contaDivisores.Contar();
        }
        return "1, " + lista + numInt;
    }

    public int mdc(int segundoNum)
    {
        int resto = 0;
        int oMdc = 0;
        int divisor = segundoNum;
        int dividendo = numInt;
        do
        {
            int quociente = dividendo / divisor;
            resto = dividendo - quociente * divisor;

            if (resto == 0)
                oMdc = divisor;

            dividendo = divisor;
            divisor = resto;
        }
        while (resto != 0);
        return oMdc;
    }

    public bool EhPalindromo()
    {
        int aux = 0;
        int numDigitado = numInt;
        while (numDigitado > 0)
        {
            int quociente = numDigitado / 10;
            int resto = numDigitado - quociente * 10;
            aux = aux * 10 + resto;
            numDigitado = quociente;
        }
        return aux == numInt;
    }

    public int SomarDivisores()
    {
        int quociente,
            resto,
            divisor;

        var somaDivisores = new Somatoria();
        var contaDivisores = new Contador(1, numInt, 1);

        while (contaDivisores.Prosseguir())
        {
            divisor = Convert.ToInt32(contaDivisores.Valor);
            quociente = numInt / divisor;
            resto = numInt - quociente * divisor;

            if (resto == 0)
                somaDivisores.Somar(divisor);

            contaDivisores.Contar();
        }
        return Convert.ToInt32(somaDivisores.Valor);
    }

    public bool EhPerfeito()
    {
        int metadeNum = SomarDivisores() / 2;

        if (numInt == metadeNum)
            return true;

        else
            return false;
    }

    public double Cosseno(double anguloEmGraus)
    {
        double cosX = 1;
        double radianos = (PI * anguloEmGraus / 180);

        var contaQuant = new Contador(2, numInt * 2, 2);
        var positivoeNegativo = new Contador(1, 0, 1);

        while (contaQuant.Prosseguir())
        {
            numInt = Convert.ToInt32(contaQuant.Valor);
            cosX += Pow(-1, positivoeNegativo.Valor) * Pow(radianos, contaQuant.Valor) / Fatorial();

            positivoeNegativo.Contar();
            contaQuant.Contar();
        }
        return cosX;

    }
    public int ParaBinario()
    {
        int resto;
        int numero = numInt;
        double numBinario = 0;

        var umExpoente = new Contador(0, int.MaxValue, 1);

        while (numero != 0)
        {
            resto = numero % 2;

            numBinario += resto * Pow(10, umExpoente.Valor);

            numero /= 2;
            umExpoente.Contar();
        }
        return Convert.ToInt32(numBinario);

    }

public bool EhPrimo(int numero)
    {
        int metadeNumero = numero / 2;
        var possivelDivisor = new Contador(2, metadeNumero, 1);
        int SomaDivisores = 0;        
        while (possivelDivisor.Prosseguir())
        {
            int quociente = numero / Convert.ToInt32(possivelDivisor.Valor);
            int resto = numero - quociente * Convert.ToInt32(possivelDivisor.Valor);
            if (resto == 0)
                SomaDivisores += quociente;
            possivelDivisor.Contar(); // gera próximo potencial divisor
        }
        if (numero < 2)
        {
            return false;
        }
        else
        {
            if (SomaDivisores == 0)
                return true;
            else
                return false;
        }
    }

    public int MMC(int outroValor)
    {
        int maiorValor;
        var umProdutorio = new Produtorio();        
        if (outroValor < numInt)
            maiorValor = numInt;
        else
            maiorValor = outroValor;
        var cont = new Contador(2, maiorValor, 1);
        
        while(cont.Prosseguir())
        {
            int contador = Convert.ToInt32(cont.Valor);
            while ((EhPrimo(contador) && numInt % cont.Valor == 0) || (EhPrimo(contador) && outroValor % cont.Valor == 0))
            {
                if (numInt % cont.Valor == 0 && outroValor % cont.Valor == 0)
                {
                    numInt /= contador;
                    outroValor /= contador;
                    umProdutorio.Multiplicar(cont.Valor);
                }
                else
                {

                    if (numInt % cont.Valor == 0)
                    {
                        numInt /= contador;
                        umProdutorio.Multiplicar(cont.Valor);
                    }
                    if (outroValor % cont.Valor == 0)
                    {
                        outroValor /= contador;
                        umProdutorio.Multiplicar(cont.Valor);
                    }
                }

            }
            cont.Contar();
        }
        int oMMC = Convert.ToInt32(umProdutorio.Valor);
        return oMMC;
    }
    
    public int SomaCentral(int valorInicial, int valorFinal)
    {
        int primeiroDigito, segundoDigito, terceiroDigito, quartoDigito, somaCentral = 0;
        if (valorInicial == 0 && valorInicial == valorFinal && TemQuatroDigitos(numInt))
        {
            primeiroDigito = numInt / 1000;
            segundoDigito = numInt / 100 - primeiroDigito * 10;
            terceiroDigito = numInt / 10 - primeiroDigito * 100 - segundoDigito * 10;
            quartoDigito = numInt - primeiroDigito * 1000 - segundoDigito * 100 - terceiroDigito * 10;
            somaCentral = segundoDigito + terceiroDigito;
            WriteLine("{0} - {1}", numInt, somaCentral);
            return somaCentral;
        }
        else
        if (TemQuatroDigitos(valorInicial) && TemQuatroDigitos(valorFinal))
        {
            var cont = new Contador(valorInicial, valorFinal, 1);            
            if (valorInicial > valorInicial)
            {
                Write("Por favor, digite os valores na ordem adequada da contagem.");
                return default(int);
            }
            else
            {
                WriteLine("A soma dos números centrais entre os números que vossa senhoria digitou são: ");
                while (TemQuatroDigitos(valorInicial) && TemQuatroDigitos(valorFinal) && cont.Prosseguir())
                {
                    int contador = Convert.ToInt32(cont.Valor);
                    primeiroDigito = contador / 1000;
                    segundoDigito = contador / 100 - primeiroDigito * 10;
                    terceiroDigito = contador / 10 - primeiroDigito * 100 - segundoDigito * 10;
                    quartoDigito = contador - primeiroDigito * 1000 - segundoDigito * 100 - terceiroDigito * 10;
                    somaCentral = segundoDigito + terceiroDigito;
                    WriteLine("{0} - {1}", contador, somaCentral);
                    cont.Contar();
                }
                return somaCentral;
            }
        }
        else
        {
            Write("Digite um número que possua quatro dígitos, por favor");
            return default(int);
        }
    }
    public bool TemQuatroDigitos(int valor)
    {
        if ((valor < 100000 && valor > 999) || (valor < -999 && valor > -10000 && valor < 0))
            return true;
        else
            return false;
    }

    public List<int> Fibonacci()
    {
        List<int> fibonacci = new List<int>();
        var quantValores = new Contador(0, numInt - 1, 1);

        while (quantValores.Prosseguir())
        {
            if (quantValores.Valor == 0)
                fibonacci.Add(1);

            else if (quantValores.Valor == 1)
                fibonacci.Add(1);

            else
            {
                int doisAnterior = fibonacci[Convert.ToInt32(quantValores.Valor) - 2];
                int umAnterior = fibonacci[Convert.ToInt32(quantValores.Valor) - 1];

                fibonacci.Add(Abs(doisAnterior + umAnterior));
            }
            quantValores.Contar();
        }
        return fibonacci;
    }

    public double RaizQuadrada()
    {
        double
            y,
            aproximacaoY,
            raiz;

        y = numReal;
        aproximacaoY = y;

        do
        {
            raiz = (aproximacaoY + (y / aproximacaoY)) / 2.0;

            if ((Abs(aproximacaoY / raiz) - 1) > 0.00001)
                aproximacaoY = raiz;

            else
                break;
            
        }
        while (aproximacaoY == raiz);

        return raiz;
    }

    public double Pi1()
    {
        var umaSoma = new Somatoria();
        var contaValores = new Contador(1, numInt * 2 - 1, 2);

        int sinal = 2;

        while (contaValores.Prosseguir())
        {
            umaSoma.Somar(Pow(-1, sinal) * (1 / Pow(contaValores.Valor, 3)));

            contaValores.Contar();
            sinal++;
        }

        return Pow((32 * umaSoma.Valor), 1.0 / 3);
    }

    public double Pi2()
    {
        var umaSoma = new Somatoria();
        var contaValores = new Contador(1, numInt, 2);

        int sinal = 2;
         
        while (contaValores.Prosseguir())
        {
            umaSoma.Somar(Pow(-1, sinal) * 4 / contaValores.Valor);

            sinal++;
            contaValores.Contar();
        }
         
        return umaSoma.Valor;
    }

}



