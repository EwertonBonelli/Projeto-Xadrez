/*
 Nessa classe iremos criar o tabuleiro e como ela ira se comportar com as outras classes.

-Irei criar as propriedades como linha e coluna porque no tabuleiro iremos usar para identificar cada posicação e amarrar ela com as
outras classes, irei clamar a classe Peca porque la foi criado as peças para o jogo.

-Irei criar um contrutor com argumentos, neste contrutor estanciei a matriz pecas com suas linhas e colunas.

-Irei criar uma propriedade Peca com parametros de entrada linha e coluna mas ira retornar a matriz de pecas 
que criamos na propriedade a cima.

-Irei criar um metodo para ver se existe a peça na mesma posição para nao dar erro.

-Irei criar uma operação para colocar a peça no tabuleiro.

-Irei criar um metodo para retirar a peça do tabuleiro.

-Irei criar um metodo para posicaovalida da matriz se ela esta entre as proporções 8x8.

-Irei criar um metodo para validarposicao com a tratativa de erro com exceção personalizada.


 */
namespace tabuleiro {//Deixar o namespace somente como tabuleiro.
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
            //retorne se a peca na posição pos for diferente de nulo.
            return peca(pos) != null; // Ao contrario do null, se isso for verdade é porque existe uma peça naquela posição.
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

        //Metodo para retirar uma peça do tabuleiro do jogo dejuma dada posição pos.
        public Peca retirarPeca(Posicao pos) {
            // Se a peca do tabuleiro na posicao pos for igual a nulo, quer dizer se não tiver peca neste posicao para retirar, então...
            if (peca(pos) == null) {
                return null; // retorna o valor nulo porque não teve nenhuma peca para ser retirado.
            }
            // Se passar esse if é porque existe peca para ser retirada, sendo assim irei criar um auxililar recebendo a posicação da peça.
            Peca aux = peca(pos); // O aux esta recebendo a peca na posicao dada.
            // Agora o auxiliar aux ira receber nulo porque estou retirando a peca da posição dada.
            aux.posicao = null; //essa peca na sua posicao foi retirada onde ela nao existe mais no tabuleiro.
            //agora la no meu tabuleiro da matriz, eu passo eles como nulo.
            pecas[pos.linha, pos.coluna] = null; // falando que nas posições das peças no babuleiro não existe mais(a peça foi retirada do jogo).
            return aux; //retornando o auxiliar.
        }



        //Criando metodo para testar se a posição do tabuleiro é valida ou não.
        //Se atente as proporções da matrix de 8x8.
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
