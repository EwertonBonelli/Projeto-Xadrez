/*
 Nessa classe iremos montar como ira ser apresentado o tabuleiro na tela para o usuario.
 */



using System;
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.
using xadrez; //Importando o diretorio para comunicacao das classes.

namespace xadrez_console {//Deixar o namespace com o mesmo nome do Program (programa padrao).
    class Tela {

        //Metodo estatico void, somente ira imprimir o tabuleiro na tela do usuario.
        public static void imprimirTabuleiro(Tabuleiro tab) {

            //for para percorrer e imprimir todas as linhas do tabuleiro.
            for (int i = 0; i < tab.linhas; i++) {
                //Para aparecer os numeros do lado do tabuleiro na tela do usuario.
                Console.Write(8 - i + " ");
                //for para percorrer as colunas do tabuleiro.
                for (int j = 0; j < tab.colunas; j++) {
                    //Se o valores da matriz peca de i e j estiverem vazios, então emprima uma traço " - "
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else { // imprimo a Peça e depois dou um espaço em branco.
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            //Depois do for eu imprimo as letras que sairam em ordem no tabuleiro.
            Console.WriteLine("  a b c d e f g h");
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
        }
    }
}
