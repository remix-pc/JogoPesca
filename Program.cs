using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pescaria
{
    class Program
    {
        static void Main(string[] args) {


            //Variáveis
            int numJogadores = 0;
            int numJogadas;
            int numPeixes;


            //Entradas Jogadores

            Console.Write("Digite o número de jogadores: ");
            numJogadores = int.Parse(Console.ReadLine());

            String[] nome = new String[numJogadores];




            for (int i = 0; i < numJogadores; i++) {
                Console.Write("Digite o nome do Jogador: ");
                nome[i] = Console.ReadLine();

            }

            //Entradas Jogadas
            Console.Write("Digite o número de Iscas: ");
            numJogadas = int.Parse(Console.ReadLine());



            //Entradas Peixes

            Console.Write("Digite o número de Peixes: ");
            numPeixes = int.Parse(Console.ReadLine());


            Console.WriteLine("\n");







            //TABELA 

            void tabela() {
                for (int linha = 0; linha <= 5; linha++) {

                    for (int coluna = 0; coluna < 10; coluna++) {


                        Console.Write("     " + "[" + coluna + "," + linha + "]");

                    }

                    Console.WriteLine("\n");

                }
            }





            //Posições aleatórias


            String posicoes = null;



            Random r = new Random();

            String[] tanques = new String[numPeixes];

            for (int i = 0; i < numPeixes; i++) {



                posicoes = r.Next(0, 10) + "" + r.Next(0, 6);

                //For para não repetir o peixe

                Boolean jaTem = false;

                for(int b = 0; b < tanques.Length; b++) {



                       if(posicoes.Equals(tanques[b])) {
                    

                        jaTem = true;
                        break;

                    } 

                }


                if(!jaTem) {
                
                
                    tanques[i] = posicoes;

                } else {
                i--;
                }

                
            }
           


                                //******** Hora do jogo! *******//



            //Pontos

            int[] pontos = new int[numJogadores];

            //Hora do jogo

            String jogar = null;


            for (int i = 0; i < numJogadas; i++) {
                tabela();
                int rodada = i;
                Console.Write("RODADA: " + (rodada + 1));
                Console.WriteLine();
                for (int x = 0; x < numJogadores; x++) {

                    Console.WriteLine(nome[x] + " é a sua vez! ");
                    Console.Write("Insira a posição (xy) sem ponto ou virgula: ");
                    jogar = Console.ReadLine();

                    for (int b = 0; b < (tanques.Length + 1); b++) {

            
                        

                        if (tanques[b].Equals(jogar)) {
                 
                            Console.WriteLine(nome[x] + " ACERTOU!!!!!! PARABÉNS");
                            pontos[x] = pontos[x] + 1;
                            tanques[b] = "";
                            break;

                        }
                             if (b == (tanques.Length - 1)) {

                            Console.WriteLine(nome[x] + " sim, você errou.");
                            break;
                        }
                    }

                }
            }



            //Mostrando os pontos
           
            for (int i = 0; i < numJogadores; i++) {

                if (pontos[i] == 0) {
                    Console.WriteLine(nome[i] + " Você não pescou nada :/");
                } else {
                    Console.WriteLine(nome[i] + " pescou: " + pontos[i] + " peixes, parabéns!!");
                }
                
            }

            //Resultados: 

            int maiorPontuacao = pontos[0];
            String vencedor = nome[0];
            for(int i = 1; i < numJogadores; i++) {

                if(pontos[i] > maiorPontuacao) {
                    maiorPontuacao = pontos[i];
                    vencedor = nome[i];
                }
            }

            int empate = 0;
            if(maiorPontuacao != 0) {

                //Ver se deu empate

                for(int i = 0; i < pontos.Length; i++) {
                    if(pontos[i] == maiorPontuacao) {
                        empate++;
                    }
                }

                if(!(empate >= 2)) {
                    Console.WriteLine(vencedor + " é o pescador divino dentre todos!!");
                } else {
                    Console.WriteLine("empatou.. ambos ganharam parabéns!");
                }

            } else {
                Console.WriteLine("nimguem pescou nada.");
            }


            Console.Read();



        }
    }
}

