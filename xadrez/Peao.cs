using tabuleiro; // importando o diretorio onde fica as classes.

namespace xadrez { //Deixar o namespace somente como xadrez.
    class Peao : Peca { //Herdando da classe Peca.


        //contrutor padrao com argumentos do construtor da classe Peca.
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }


        //Metodo ToString.
        public override string ToString() {
            return "P";
        }


        //Metodo para ver se existe peça adversaria.
        private bool existeInimigo(Posicao pos) {
            // o p recebe a peça do tabuleiro a sua posição.
            Peca p = tab.peca(pos);
            //e retornar se o p não for vazio ou a cor não for igual do mesmo que quer dizer que é peça adversaria
            return p != null && p.cor != cor;
        }

        //Metodo para ver se a posição esta livre sem nenhuma peça.
        private bool livre(Posicao pos) {
            //retorna se a posição da peça no tabuleiro for igual a fazio.
            return tab.peca(pos) == null;
        }


        // metodo abstrato da classe Peca.
        public override bool[,] movimentosPossiveis() {
            //Criando uma matriz com o mesmo numero de linhas e colunas que sao 8x8.
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // linhas e colunas da classe tabuleiro.

            //Estanciando uma posição do tabuleiro com 0x0.
            Posicao pos = new Posicao(0, 0);

            //Verificando e definindo as posições do xadrez, onde no tabuleiro as linhas são contado de cima para baixo 1,2,3... etc.
            // e as colunas são andados da esquerda para direita a,b,c... etc.

            //PARTICULARIEDADE DO PEAO

            // Se a minha cor do jogo for iguala cor branca, então...
            if (cor == Cor.Branca) {

                //Verificando a posicao ACIMA do Peao.
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Verificando a posicao mais a ACIMA do Peao.
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                //Se a minha posição for valida, livre e a minha quantidade de movimentos para essa peça for o primeiro movimento, então...
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Verificando a posicao ESQUERDA-ACIMA do Peao.
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                //Se a minha posição for valida e existir peça adversaria, então...
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Verificando a posicao DIREITA-ACIMA do Peao.
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                //Se a minha posição for valida e existir peça adversaria, então...
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else { // Se não vai ser a cor preta.

                //Verificando a posicao ABAIXO do Peao.
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }


                //Verificando a posicao mais ABAIXO do Peao.
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                //Se a minha posição for valida, livre e a minha quantidade de movimentos para essa peça for o primeiro movimento, então...
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Verificando a posicao ESQUERDA-ABAIXO do Peao.
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                //Se a minha posição for valida e existir peça adversaria, então...
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Verificando a posicao DIREITA-ABAIXO do Peao.
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                //Se a minha posição for valida e existir peça adversaria, então...
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;

        }
    }
}
