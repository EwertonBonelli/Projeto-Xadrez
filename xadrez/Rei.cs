/*
 Essa classe criamos a peça Rei.
 */

using tabuleiro; // importando o diretorio onde fica as classes.

namespace xadrez {//Deixar o namespace somente como xadrez.
    class Rei : Peca { //Herdando da classe Peca.

        //contrutor padrao com argumentos do construtor da classe Tabuleiro e da classe Cor.
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) { 
            
        }


        //Metodo ToString.
        public override string ToString() {
            return "R" ;

        }

        //metodo para ver se a peça pode mover na posicação dada.
        private bool podeMover(Posicao pos) {
            //pega a peça na posição digitada pelo usuario.
            Peca p = tab.peca(pos);
            //Retorna se o posição do meu p estiver vazio OU a cor da peça do meu p for diferente do meu Rei(for da cor do adversario).
            return p == null || p.cor != cor;
        }

        // metodo abstrato da classe Peca.
        public override bool[,] movimentosPossiveis() {
            //Criando uma matriz com o mesmo numero de linhas e colunas que sao 8x8.
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // linhas e colunas da classe tabuleiro.

            //Estanciando uma posição do tabuleiro com 0x0.
            Posicao pos = new Posicao(0, 0);

            //Verificando e definindo as posições do xadrez, onde no tabuleiro as linhas são contado de cima para baixo 1,2,3... etc.
            // e as colunas são andados da esquerda para direita a,b,c... etc.

            //Verificando a posição a CIMA do Rei.
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a CIMA-DIREITA do Rei.
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a DIREITA do Rei.
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a BAIXO-DIREITA do Rei.
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a BAIXO do Rei.
            pos.definirValores(posicao.linha +1, posicao.coluna);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a BAIXO-ESQUERDA do Rei.
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a ESQUERDA do Rei.
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }

            //Verificando a posição a CIMA-ESQUERDA do Rei.
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            //Se a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario, então...
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça..
            }
            return mat; // Retornando a matriz
        }
    }
}
