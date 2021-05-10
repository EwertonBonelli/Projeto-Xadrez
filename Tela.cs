using System;
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.


namespace xadrez_console {
    class Tela {

        //Metodo estatico void, somente ira imprimir o tabuleiro na tela do usuario.
        public static void imprimirTabuleiro(Tabuleiro tab) {

            //for para percorrer as linhas do tabuleiro.
            for (int i = 0; i < tab.linhas; i++) {
                //for para percorrer as colunas do tabuleiro.
                for (int j = 0; j < tab.colunas; j++) {
                    //Se o valores da matriz peca de i e j estiverem vazios, então emprima uma traço " - "
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {//se não, imprime a matriz peca.
                        Console.Write(tab.peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
