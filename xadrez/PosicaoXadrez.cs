/*
 Essa classe é para trabalhar com as posições do xadrez de forma certa.
Nos criamos uma matriz que percore deste jeito:

  0 1 2 3 4 5 6 7
0
1
2
3
4
5
6
7

No jogo de xadrez ele é lido desta forma, por padrao do proprio jogo:

8
7
6
5
4
3
2
1 
  a b c d e f g h

Então para o usuario ele ira jogar com a forma do proprio xadrez mas pelo sistema usamos a forma da matriz.
Sendo assim, temos que fazer essa conversão para o usuario.
 
 */

using tabuleiro;

namespace xadrez { // deixar o namespace somente como xadrez.
    class PosicaoXadrez {
        //Propriedades.
        public char coluna { get; set; }
        public int linha { get; set; }

        //Construtor com argumentos.
        public PosicaoXadrez(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        //Metodo para converter uma posicao do xadrez para uma posição interna da matriz.
        public Posicao toPosicao() {
            //retornar uma nova posicao.
            return new Posicao(8 - linha, coluna - 'a');
            /*
             NO XADREZ SAO DE 8 POSIÇÕES POR ISSO COLOCAMOS 8 - LINHA, QUE É O NUMERO QUE O USUARIO IRA DIGITAR.
            ENTÃO TEMOS QUE FAZER ESSA CONVERSAO PARA A MATRIZ, VAMOS SUPOR QUE A LINHA VALE 3, ENTÃO É 8-3:
            EU CONTO DA MATRIZ DE CIMA PARA BAIXO COMEÇANDO COM O ZERO.
            8 TIRA 3 FICA 5 QUE A POSICAO DA MATRIZ.

                 XADREZ                 MATRIZ
            8                 ||   0
            7                 ||   1      
            6                 ||   2
            5                 ||   3
            4                 \/   4
            3 -------------------- 5
            2                      6
            1                      7
              a b c d e f g h        0 1 2 3 4 5 6 7

            NA COLUNA - 'A' USAMOS UM MACETE PARA PERCORRER AS COLUNAS.
            PARA O SISTEMA O 'A' ELE É UM NUMERO INTEIRO ENTÃO VAMOS SUPOR QUE O USUARIO DIGITOU A LETRA 'C', ENTÃO VAI SER
            'A' - 'C' QUE É 0 - 2 = 2 

                   XADREZ                 MATRIZ
            8                      0
            7                      1      
            6                      2
            5                      3
            4                      4
            3                      5
            2                      6
            1                      7
              a b c d e f g h        0 1 2 3 4 5 6 7
              |                          |
              |--------------------------|

             */
        }

        //ToString para mostrar na tela do usuario.
        public override string ToString() {
            return "" + coluna + linha;
        }
    }
}
