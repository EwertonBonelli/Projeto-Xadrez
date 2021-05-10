
namespace tabuleiro {
    class Tabuleiro {

        //propriedades da classe.
        public int linhas { get; set; } //Foi criado a "linhas" para o Tabuleiro porque ele pode variar.
        public int colunas { get; set; } // Foi criado a "colunas" porque o Tabuleiro tem a dimensão 8x8.
        private Peca[,] pecas; // Propriedade de matris da classe Pecas e coloquei ele como private para não
                               // ser acessada de outras classes somente nesta classe mesmo.

        //Construtor com argumentos.
        //O "this" é para identificar as propriedades que criamos no comeco do codigo.
        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas]; //criei uma nova matriz de linhas e colunas.
        }

        //Como a Propriedade Peca esta como privado, não conseguirei utilizar em outras classes.
        //Para isso vou criar um Metodo publico Peca para dar acesso a uma peça do meu tabuleiro.
        //Esse metodo ira receber como argumento de entrada, linha e coluna.
        public Peca peca(int linha, int coluna) {
            //Ele ira retornar a matriz pecas na posicao linha e coluna.
            return pecas[linha, coluna];
        }

        //Operação para colocar peças no tabuleiro.
        public void colocarPeca(Peca p, Posicao pos) {
            //Estou pegando a peça p e colocando la na matriz de pecas nas posição de pos.linha e pos.coluna, então ela esta
            //recebendo o valor de p nessas posições.
            pecas[pos.linha, pos.coluna] = p;
            //Agora a posicao da peça p vai ser a posicao pos.
            p.posicao = pos;
        }
    }
}
