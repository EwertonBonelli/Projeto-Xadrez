

/*   
//Jogadaespecial en passant.
//no jogo de xadrez so pode fazer passant quando o peao banco estiver no meio do tabuleiro, somente no meio, com isso,
//contar as possições ate chegar no meio do tabuleiro, esse numero é 3.
//para o peao preto tem que contar ate 4. 



     |             |  0
     |p p   p p p p|  1
     |             |  2
     |--- p p -----|  3 peao branco
     |             |  4 peao preto
     |             |  5
     |p p p   p p p|  6
     |             |  7

 */



using tabuleiro; // importando o diretorio onde fica as classes.

namespace xadrez { //Deixar o namespace somente como xadrez.
    class Peao : Peca { //Herdando da classe Peca.

        //Criando um atributo da classe PartidaDeXadrex.
        private PartidaDeXadrez partida;


        //contrutor padrao com argumentos do construtor da classe Peca.
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
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


                //Jogadaespecial en passant peça branca.
                //Se a minha posicao da peça peao branca for igual na posicao 3 do tabuleiro, então.
                if (posicao.linha == 3) {
                    //como estamos trabalhando com o peao branco ele vai ter que capturar a peça peao preta do lado esquerda dele.
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1); // então essa é a posição vuneravel da peça adversaria.
                    //Se a posicao esquerda for valida E existe um inimigo la na posicao esquerda E o inimigo da esquerda é o peao que esta vulneravel, então...
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha -1, esquerda.coluna] = true; // é uma posilçai posivel para o peao mecher.
                    }
                    //como estamos trabalhando com o peao branco ele vai ter que capturar a peça peao preta do lado direito dele.
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1); // então essa é a posição vuneravel da peça adversaria.
                    //Se a posicao direita for valida E existe um inimigo la na posicao direita E o inimigo da direita é o peao que esta vulneravel, então...
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha -1, direita.coluna] = true; // é uma posilçai posivel para o peao mecher.
                    }
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

                //Jogadaespecial en passant peça Preta.
                //Se a minha posicao da peça peao preto for igual na posicao 4 do tabuleiro, então.
                if (posicao.linha == 4) {
                    //como estamos trabalhando com o peao preto ele vai ter que capturar a peça peao branco do lado esquerda dele.
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    //Se a posicao esquerda for valida E existe um inimigo la na posicao esquerda E o inimigo da esquerda é o peao que esta vulneravel, então...
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha + 1, esquerda.coluna] = true; // é uma posilçai posivel para o peao mecher.
                    }
                    //como estamos trabalhando com o peao preto ele vai ter que capturar a peça peao branca do lado direito dele.
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    //Se a posicao direita for valida E existe um inimigo la na posicao direita E o inimigo da direita é o peao que esta vulneravel, então...
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha + 1, direita.coluna] = true; // é uma posilçai posivel para o peao mecher.
                    }
                }
            }

            return mat;

        }
    }
}
