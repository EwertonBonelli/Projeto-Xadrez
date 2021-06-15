using System;
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.
using xadrez; // Importando o diretorio das classes.

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                //estanciando a classe PartidaXadrez.
                PartidaDeXadrez partida = new PartidaDeXadrez();

                //Enquanto a minha partida não estiver terminada...
                while (!partida.terminada) {

                    try {
                        Console.Clear(); // Limpa a tela.
                                         //Imprimindo o tabuleiro.
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        //metodo para ler do teclado uma posicao do xadrez.
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); // Lendo a posicao e transformando ela em matriz (toPosicao()).
                        partida.validarPosicaoDeOrigem(origem); // validando a possição de origem digitado pelo usuario.

                        //Irei criar uma matriz boleano para pegar a peça de origem que o usuario digitou e nessa posição irei
                        //pegar os movimentos possiveis que a peça pode fazer.
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear(); // Limpando a tela novamente.
                                         //Imprimindo o tabuleiro com as posiçoes marcadas e passando a matriz como argumento.
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();
        }
    }
}
