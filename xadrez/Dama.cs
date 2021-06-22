using tabuleiro; // importando o diretorio onde fica as classes.

namespace xadrez {//Deixar o namespace somente como xadrez.
    class Dama : Peca {//Herdando da classe Peca.

        //contrutor padrao com argumentos do construtor da classe Peca.
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }


        //Metodo ToString.
        public override string ToString() {
            return "D";
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

            //Verificando a posicao ESQUERDA da Dama.
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha, pos.coluna - 1);
            }

            //Verificando a posicao DIREITA da Dama.
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha, pos.coluna + 1);
            }


            //Verificando a posicao ACIMA da Dama.
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha - 1, pos.coluna);
            }


            //Verificando a posicao ABAIXO da Dama.
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha + 1, pos.coluna);
            }


            //Verificando a posicao ESQUERDA-ACIMA da Dama.
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }


            //Verificando a posicao DIREITA-ACIMA da Dama.
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }


            //Verificando a posicao DIREITA-ABAIXO da Dama.
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }


            //Verificando a posicao ESQUERDA-ABAIXO da Dama.
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario.
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // A matriz mat recebe verdadeiro para mover a peça
                // Se a posição da peça não estiver vazia e a cor a peça não for da mesma cor 
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // eu paro
                }

                //definir valores guarda a posicao da linha e coluna.
                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;

        }
    }
}
