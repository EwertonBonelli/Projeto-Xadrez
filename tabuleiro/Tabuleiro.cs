
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
        
    }
}
