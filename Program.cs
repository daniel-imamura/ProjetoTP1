//Fábio Alves Dos Santos  RA: 20129
//Daniel Henry Matheus Imamura  RA:20128
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.Math;
using static Utilitarios;

namespace Projeto1
{
    class Program
    {
        static void SelecionarOpcoes()
        {
            int opcao;

            do
            {
                //Opções de escolha para o usuário
                EscreverXY(3, 4, "1 - MMC entre dois valores digitados");
                EscreverXY(3, 6, "2 - Números centrais");
                EscreverXY(3, 8, "3 - Cálculos de Pi");
                EscreverXY(3, 10, "4 - Lista de números de Fibonacci");
                EscreverXY(3, 12, "5 - Raiz Quadrada de um real digitado");
                EscreverXY(3, 14, "6 - Processamento de dados armazenados em um arquivo texto em disco");
                EscreverXY(3, 16, "0 - Terminar o programa");
                EscreverXY(3, 20, "Selecione a opção desejada: ");
                opcao = int.Parse(ReadLine());
                Clear();
                switch (opcao) //Chamar método correspondente a opção escolhida
                {
                    case 1:
                        CalcularMMC();
                        break;
                    case 2:
                        NumerosCentrais();
                        break;
                    case 3:
                        CalcularPi();
                        break;                   
                    case 4:
                        ExibirListaDeFibonacci();
                        break;
                    case 5:
                        CalcularRaizQuadrada();
                        break;
                    case 6:
                        ArquivoTexto();
                        break;
                }
                Clear();
            }
            while (opcao != 0);
        }
        static void CalcularMMC() 
        {
            EscreverXY(1, 3, "Digite os valores que deseja saber o mínimo múltiplo comum");//obtenção dos valores
            EscreverXY(3, 5, "1o valor: ");
            int valorUm = int.Parse(ReadLine());
            EscreverXY(3, 6, "2o valor: ");
            int valorDois = int.Parse(ReadLine());
            var mmc = new Matematica(valorUm);
            EscreverXY(3,10,$"O mmc entre esses dois números é: {mmc.MMC(valorDois)}");//cálculo e escrita do mmc entre os valores digitados
            EsperarEnter();
        }
        static void CalcularPi()
        {
            Clear();

            EscreverXY(3, 3, "Para obter valores mais próximos, utilizar números acima de 50");
            EscreverXY(3, 4, "Digite a quantidade de repetições que deveram ser executadas no cálculo: ");//entrada de dados
            int numDigitado = int.Parse(ReadLine());

            if (numDigitado < 0) //Caso impossível de cálculo
            {
                EscreverXY(3, 8, "[ERRO] O número digitado deve ser igual ou maior que 0!");//Mensagem de erro
            }
            else
            {
                var oPi1 = new Matematica(numDigitado);
                var oPi2 = new Matematica(numDigitado);

                EscreverXY(3, 8, "Método de cálculo 1:");
                EscreverXY(3, 9, $"O valor aproximado de PI é: {oPi1.Pi1()}");//Primeiro método de cálculo

                EscreverXY(3, 12, "Método de cálculo 2:");
                EscreverXY(3, 13, $"O valor aproximado de PI é: {oPi2.Pi2()}");//Segundo método de cálculo

                EscreverXY(3, 16, $"Diferença do resultado entre os dois métodos: {Abs(oPi1.Pi1() - oPi2.Pi2())}");//Diferença entre métodos

            }
            EsperarEnter();
        }
        static void ExibirListaDeFibonacci()
        {
            Clear();

            EscreverXY(3, 4, "Quantidade de números da lista de fibonacci que deseja exibir: ");//entrada de dados
            int numDigitado = int.Parse(ReadLine());

            var aLista = new Matematica(numDigitado);
            int espaco = 6; // variável para marcar espaçamento na exibição

            if (numDigitado < 1)//Caso impossível de exibição da lista
            {
                EscreverXY(3, 8, "[ERRO] O número digitado deve ser maior que 0!");//Mensagem de erro
            }
            else
            {
                foreach (int item in aLista.Fibonacci())//Exibe lista de fibonacci item por item
                {
                    EscreverXY(3, espaco, $"{item.ToString()}");
                    espaco++; 
                }
            }
            EsperarEnter();
        }
        static void CalcularRaizQuadrada()
        {
            Clear();

            EscreverXY(3, 4, "Digite qual será o último número a calcular: ");//entrada de dados
            double numDigitado = double.Parse(ReadLine());

            var contaRepeticoes = new Contador(1, numDigitado + 0.1, 0.1);//+ 0.1 tem função para o contador de exibir até o número digitado pelo usuário
            int espaco = 8; // variável que marca espaçamento na exibição dos valores

            while (contaRepeticoes.Prosseguir())
            {
                var aRaiz = new Matematica(contaRepeticoes.Valor);
                EscreverXY(3, espaco, $"A raiz quadrada de {Convert.ToSingle(contaRepeticoes.Valor)} é: {Convert.ToSingle(aRaiz.RaizQuadrada())}");//Exibir valores
                //Incrementos
                espaco++;
                contaRepeticoes.Contar();
            }
            EsperarEnter();
        }
        static void NumerosCentrais()
        {
            EscreverXY(3, 3,"Vossa senhoria deseja saber a soma dos números centrais de um número específico");
            EscreverXY(3, 3,"\nou de todos os números entre dois valores que digitar?");
            EscreverXY(3, 6, "Digite '1' para a primeira opção");
            EscreverXY(3, 7,"Digite '2' para a segunda opção");
            EscreverXY(3, 9, "\n\nQual deseja realizar? ");//escolha das opções de execução do exercício
            int opcaoEscolhida = int.Parse(ReadLine());
            if (opcaoEscolhida == 1)
            {
                Clear();
                EscreverXY(3, 3,"Digite o número que deseja saber a soma de seus dígitos centrais: ");
                int numeroDesejado = int.Parse(ReadLine());
                var opeCentral = new Matematica(numeroDesejado);
                opeCentral.SomaCentral(0,0);//calculo e escrita da opção 1 do programa NumeroCentrais
            }
            else
            if (opcaoEscolhida == 2)
            {
                Clear();
                EscreverXY(3, 3,"Digite o valor inicial: ");
                int comeco = int.Parse(ReadLine());
                EscreverXY(3, 5,"Digite o valor final: ");
                int fim = int.Parse(ReadLine());
                var opeCentral = new Matematica(0);
                opeCentral.SomaCentral(comeco, fim);//calculo e escrita da opção 2 do programa NumeroCentrais
            }
            else
                EscreverXY(3, 3, "\nDigite uma opção válida, por favor.");//caso o usuário não digite uma opção válida aparece esta tela
            EsperarEnter();
        }
        static void ArquivoTexto() 
        {
            string nomeArquivo = ""; //armazena qual arquivo o usuário escolherá
            double mediaMaior = double.MinValue; //a variável armazena a maior média harmônica
            string raMediaMaior = ""; //variável que armazena o ra do aluno que obteu a maior média
            string turmaAnterior = ""; //variável servirá para definir se o StreamReader entrou em uma outra turma
            string raAnterior = ""; //variável existe para comparar se o StreamReader entrou em um novo RA
            int numeroLinhas = 0; //conta o número de linhas usadas
            int numeroAprovados = 0, numeroRetidos = 0, numeroRecuperacao = 0; //variáveis que armazenam os números de aprovados, Retidos e em recuperação na turma
            while(nomeArquivo == "")
            {
                EscreverXY(2, 3, "Dados armazenados em um arquivo texto em disco");
                EscreverXY(2, 5, "notasInfo = exemplo de RAs e notas no curso de Informática");
                EscreverXY(2, 6, "notasMec = exemplo de RAs e notas no curso de Mecatrônica");
                EscreverXY(2, 7, "notasEletro = exemplo de RAs e notas no curso de Eletroeltrônica");
                EscreverXY(2, 9, "Digite o nome do arquivo que deseja consultar:");
                nomeArquivo = ReadLine(); // lê o nome do arquivo 
                Clear();
            }
          
            var arquivo = new StreamReader($@"arquivosTexto\{nomeArquivo}.txt");//procura o arquivo texto salvo em bin/Debug/arquivosTexto
            var arquivoSeguinte = new StreamReader($@"arquivosTexto\{nomeArquivo}.txt");//arquivo que sempre estará na linha seguinte em relação ao principal
                 
            
            var Media = new Somatoria(); // instancia objeto da Classe Somatoria
            arquivoSeguinte.ReadLine(); // lê o arquivo
            var mateca = new Matematica(0); //instancia um objeto da classe Matemática
            var MediaFinal = new Somatoria(); // instancia outro objeto da classe Somatotoria para calcular a média final
            while (!arquivo.EndOfStream) //enquanto o arquivo não terminou de ser lido
            {
                string linha = arquivo.ReadLine(); //lê uma linha do arquivo e a armazena na string linha
                string turma = linha.Substring(0, 6); //lê a substring da string linha e armazena ela na string turma
                string RA = linha.Substring(6, 5); //lê a substring e armazena na string RA
                double nota = double.Parse(linha.Substring(11, 4)); //lê a substring e a converte para a forma de double

                string linhaSeguinte = arquivoSeguinte.ReadLine(); //lê uma linha a frente do StremReader prinicipal e a grava na string linha
                string turmaSeguinte = ""; //cria a variável proximaTurma
                string RASeguinte = ""; //cria a variável proximoRA

                if (linhaSeguinte != null) //verifica se proxima linha não está em branco
                {
                    turmaSeguinte = linhaSeguinte.Substring(0, 6); //dá o valor de proximaClasse
                    RASeguinte = linhaSeguinte.Substring(6, 5); //dá o valor de proximoRA
                }

                if (turma != turmaAnterior) //compara a turma atual e a anterior, se forem diferentes ele realizará os comandos dentro de if
                {
                    EscreverXY(0, numeroLinhas,$"Turma: {turma}"); numeroLinhas++;
                    EscreverXY(0, numeroLinhas, "RA      Nota");
                }

                if (RA != raAnterior) //compara o RA atual e o anterior, se forem diferentes, o programa executa os comandos dentro de if
                {
                    EscreverXY(0, numeroLinhas, RA);
                    EscreverXY(8, numeroLinhas, $": {nota}");
                    Media.Somar(nota);
                }
                else //se não realizará os comandos do else
                {
                    EscreverXY(8, numeroLinhas, $"{nota}");
                    Media.Somar(nota);
                }

                if (RA != RASeguinte) //compara o RA atual e o RA da linhna seguinte, se não forem iguais, executa os comando dentro de if.
                {
                    EscreverXY(15, numeroLinhas, $"Média: {Math.Round(Media.MediaAritmetica(), 2)}"); //escreve a média aritmétrica aproximada das notas tiradas pelo aluno(a)
                    if (Media.MediaAritmetica() > mediaMaior) //compara se média artimétrica é maior que a maior média da turma se sim ela assume o lugar de mediaMaior
                    {
                        mediaMaior = Media.MediaAritmetica();
                        raMediaMaior = RA;
                    }
                    MediaFinal.Somar(Media.MediaAritmetica()); //soma o valor de MediaAritmetrica para a Soma da MediaFinal
                    Media.SomarInverso(Media.MediaAritmetica()); //somao valor de MediaAritmetrica para a SomaInversos


                    if (Media.MediaAritmetica() < 3) //condições, por ex: aprovado, retido, etc...
                    {
                        EscreverXY(25, numeroLinhas, "Aluno retido");
                        numeroRetidos++; //adiciona 1 ao número de retidos
                    }
                    else
                    if (Media.MediaAritmetica() >= 3 && Media.MediaAritmetica() < 5)
                    {
                        EscreverXY(25, numeroLinhas, "Aluno em recuperação");
                        numeroRecuperacao++;//adiciona 1 ao número de alunos em recuperação
                    }
                    else
                    {
                        EscreverXY(25, numeroLinhas, "Aluno aprovado");
                        numeroAprovados++;//adiciona 1 ao número de aprovados
                    }

                    numeroLinhas++; //adiciona 1 a contagem de linhas
                    Media.ZerarSoma(); //Zera o valor da soma
                }
                else //se não for diferente apenas adiciona 1 ao número de linhas
                {
                    numeroLinhas++;
                }

                if (turmaSeguinte != turma) //se a próxima turma for diferente da turma atual, executa os comando dentro de if
                {
                    EscreverXY(0, numeroLinhas, $"Total da turma {turma}: "); numeroLinhas++;
                    EscreverXY(6, numeroLinhas, $"Média harmônica: {Math.Round(Media.MediaHarmonica(), 2)}"); numeroLinhas++; //calcula e escreve a media harmonica da classe
                    EscreverXY(6, numeroLinhas, $"Aprovados: {numeroAprovados}"); //escreve o número de aprovados
                    EscreverXY(22, numeroLinhas, $"Em recuperação: {numeroRecuperacao}"); //escreve o número de alunos em recuperação
                    EscreverXY(42, numeroLinhas, $"Retidos: {numeroRetidos}"); numeroLinhas++; //escreve o número de retidos
                    EscreverXY(6, numeroLinhas, $"Aluno com melhor desempenho: {raMediaMaior} ({Math.Round(mediaMaior, 2)})"); numeroLinhas++; //escreve o RA do aluno com a melhor média
                    numeroLinhas++;
                    numeroAprovados = 0; //zera os valores
                    numeroRecuperacao = 0;
                    numeroRetidos = 0;
                    mediaMaior = 0;
                    Media.ZerarSomaInversa(); //recomeça a média harmônica
                }

                raAnterior = RA; //raAnterior recebe o RA atual
                turmaAnterior = turma; //turmaAnterior recebe a turma atual
            }
            arquivo.Close(); //fecha o arquivo 
            EsperarEnter();
        }
        static void Main(string[] args)
        {
            SelecionarOpcoes();
        }
    }
}
