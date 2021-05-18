
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

        //Criando uma sobre carga do metodo Peca.
        public Peca peca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        //Metoda para testar se existe uma peça em uma dada posição
        public bool existePaca(Posicao pos) {
            //Se essa posição for invalida, então ele ira mostrar a trataviva de erro que criamos aqui na classe metodo ValidarPosicao.
            validarPosicao(pos);
            //retorme se a peca na posição pos for diferente de nulo.
            return peca(pos) != null; // se isso for verdade é porque existe uma peça naquela posição.
        }

        //Operação para colocar peças no tabuleiro.
        public void colocarPeca(Peca p, Posicao pos) {
            //Esse if valida se ja existe uma peça em uma determinada posicao, caso se tiver ele ira dar um
            //erro para não criar duas peças na mesma posição.
            if (existePaca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            //Estou pegando a peça p e colocando la na matriz de pecas nas posição de pos.linha e pos.coluna, então ela esta
            //recebendo o valor de p nessas posições.
            pecas[pos.linha, pos.coluna] = p;
            //Agora a posicao da peça p vai ser a posicao pos.
            p.posicao = pos;
        }

        //Craindo metodo para testar se a posição do tabuleiro é valida ou não.
        public bool posicaoValida(Posicao pos) {
            //Se pos.linha for menor que zero OU pos.linha for maior igual a quantidade de linhas do tabuleiro OU pos.coluna
            //for menor que zero OU pos.coluna for maior igual a quantidade de colunas do tabuleiro, então...
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas) {
                return false; //Ele é falso.

            } else //Se não...
            return true; // retorna verdadeiro
        }


        //Metodo para validar a posicao do tabuleiro e retornar um erro (uma exceção personalizada).
        public void validarPosicao(Posicao pos) {
            // Se a minha posição não for valida, então...
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
