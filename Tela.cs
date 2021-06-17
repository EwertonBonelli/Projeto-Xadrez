/*
 Nessa classe iremos montar como ira ser apresentado o tabuleiro na tela para o usuario.
 */



using System;
using System.Collections.Generic; //Importando a biblioteca para usar o conjunto de HashSet.
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.
using xadrez; //Importando o diretorio para comunicacao das classes.

namespace xadrez_console {//Deixar o namespace com o mesmo nome do Program (programa padrao).
    class Tela {

        //Metodo para imprimir a partida na tela para o usuario.
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            if (partida.xeque) {
                Console.WriteLine("XEQUE!");
            }
        }

        //Metodo para imprimir para o usuario as peças que ja foram capturadas no jogo.
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            //Para as peças da cor preta imprimirem amarelos, vamos mudar a cor e depois voltar ao na cor normal.
            ConsoleColor aux = Console.ForegroundColor; //aux recebe a cor padrao.
            Console.ForegroundColor = ConsoleColor.Yellow; //trocando a cor padrao para o amarelo.
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;// Voltando para a cor padrao.
            Console.WriteLine();
        }

        //Metodo para imprimir o conjunto de peças.
        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach (Peca x in conjunto) {// para toda peça x no conjunto...
                Console.Write(x + " "); // imprima a peça.
            }
            Console.Write("]");
        }


        //Metodo estatico void, somente ira imprimir o tabuleiro na tela do usuario.
        public static void imprimirTabuleiro(Tabuleiro tab) {

            //for para percorrer e imprimir todas as linhas do tabuleiro.
            for (int i = 0; i < tab.linhas; i++) {
                //Para aparecer os numeros do lado do tabuleiro na tela do usuario.
                Console.Write(8 - i + " ");
                //for para percorrer as colunas do tabuleiro.
                for (int j = 0; j < tab.colunas; j++) {
                     imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            //Depois do for eu imprimo as letras que sairam em ordem no tabuleiro.
            Console.WriteLine("  a b c d e f g h");
        }


        //Metodo de sobrecarga estatico void, somente ira imprimir o tabuleiro na tela do usuario.
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
           
            //Estou armazenando a cor original de fundo do tabuleiro que é o preto por padrao.
            ConsoleColor fundoOriginal = Console.BackgroundColor;

            //Estou armazenando a cor cinza nesta variavel.
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            //for para percorrer e imprimir todas as linhas do tabuleiro.
            for (int i = 0; i < tab.linhas; i++) {
                //Para aparecer os numeros do lado do tabuleiro na tela do usuario.
                Console.Write(8 - i + " ");
                //for para percorrer as colunas do tabuleiro.
                for (int j = 0; j < tab.colunas; j++) {
                    //Se a posicoesPossiveis for verdadeiro, então...
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado; // Mudando para a cor cinza de fundo da tela.
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal; // ele recebe a cor original que é preto.
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            //Depois do for eu imprimo as letras que sairam em ordem no tabuleiro.
            Console.WriteLine("  a b c d e f g h");
            //Se no if mudar para a cor cinza depois que ele percorrer o for eu forço ele a voltar para a cor original.
            Console.BackgroundColor = fundoOriginal;
        }


        //Metodo que ira ler o que o usuario digitar no teclado
        public static PosicaoXadrez lerPosicaoXadrez() {

            string s = Console.ReadLine(); //Recebendo os dados digitados pelo usuario.
            char coluna = s[0]; // Aqui estou armazenando somente a letra do tabuleiro.
            int linha = int.Parse(s[1] + ""); // estou pegando o valor digitado pelo usuario e convertendo ele para int.
            return new PosicaoXadrez(coluna, linha); //Retornando o resultados.
        }

        //Metodo static com parametro de entrada para alterar a cor a peça preta para o amarelo.
        public static void imprimirPeca(Peca peca) {

            //Se a casa onde eu quero imprimir a peca estiver vazia, então...
            if (peca == null) {
                Console.Write("- "); //Eu coloco o - no tabuleiro.
            }
            else {//Se não eu imprimo a peça.
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else { //Se essa peça for preta, então...
                       //O consoleColor é um tipo do C# que pega a cor do sistema.
                    ConsoleColor aux = Console.ForegroundColor; // Essa é a cor cinza que apresenta na tela do usuario e esta sendo armazenado na variavel aux.
                    Console.ForegroundColor = ConsoleColor.Yellow;// Estou alterando a cor cinza para o amarelo.
                    Console.Write(peca); // é imprimindo na tela.
                    Console.ForegroundColor = aux; // Depois ele volta na cor cinza normal pra não ficar direto na cor amarelo.
                }
                Console.Write(" ");
            }
        }
    }
}
