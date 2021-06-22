/*
 Essa classe criamos a peça Rei.
 */

using tabuleiro; // importando o diretorio onde fica as classes.

namespace xadrez {//Deixar o namespace somente como xadrez.
    class Rei : Peca { //Herdando da classe Peca.


        //Criando uma propriedade da classe partidade de xadrez para que a Peça Rei poça fazer a jogada roque.
        private PartidaDeXadrez partida;


        //contrutor padrao com argumentos do construtor da classe Peca.
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
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

        //Metodo para ver se a Torre pode fazer roque com o Rei
        private bool testeTorreParaRoque(Posicao pos) {
            //pego a peça e armazeno ela no p.
            Peca p = tab.peca(pos);
            // ela pode ser roque se a peça não for nulo E a peça for uma estancia da torre E a cor da peça for da mesma cor do rei para não ser 
            //a do adversario E a peça nao pode ja ter movido antes.
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
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

            //jogadaespecial para roque .
            //Se a quantidade de movimentos for igual a zero E a partida não estr em xeque, então...
            if (qteMovimentos == 0 && !partida.xeque) {

                //Jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                //Se essa torre esta legivel para o teste terre para roque, então...
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    //Se a posição p1 e a posição p2 estiverem vazios, então...
                    if (tab.peca(p1) == null && tab.peca(p2) == null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //Jogadaespecial roque grande.
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                //Se essa torre esta legivel para o teste terre para roque, então...
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    //Se a posição p1, p2 e p3 estiverem vazios, então...
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null) {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }

            }

            return mat; // Retornando a matriz
        }
    }
}
