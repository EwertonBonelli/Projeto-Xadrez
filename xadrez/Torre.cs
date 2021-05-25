/*
 Essa classe criamos a peça Torre.
 */

using tabuleiro;// importando o diretorio de classes.

namespace xadrez {//Deixar o namespace somente como xadrez.
    class Torre : Peca { //Herdando da classe Peca.

        //contrutor padrao com argumentos do construtor da classe Tabuleiro e da classe Cor.
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }


        //Metodo ToString.
        public override string ToString() {
            return "T";
        }


        //metodo para ver se a peça pode mover na posicação dada.
        private bool podeMover(Posicao pos) {
            //pega a peça na posição digitada pelo usuario.
            Peca p = tab.peca(pos);
            //Retorna se o posição do meu p estiver vazio OU a cor da peça do meu p for diferente da minha Torre(for da cor do adversario).
            return p == null || p.cor != cor;
        }

        // metodo abstrato da classe Peca.
        public override bool[,] movimentosPossiveis() {
            //Criando uma matriz com o mesmo numero de linhas e colunas que sao 8x8.
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // linhas e colunas da classe tabuleiro.

            //Estanciando uma posição do tabuleiro com 0x0.
            Posicao pos = new Posicao(0, 0);

            //Verificando e definindo as posições do xadrez, onde no tabuleiro as linhas são contado de cima para baixo 1,2,3... etc.
            // e as colunas vao andando da esquerda para direita a,b,c... etc.

            //Verificando a posição a CIMA da Torre.
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario...
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // Enquando for verdadeiro, pode mover.
                //Tenho que fazer um if para quando a peça achar a outra peça adversaria ela parar naquela posição.
                //Se minha peça daposição não estiver vazia E a minha peça tiver com a cor diferente, então...
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // Eu paro a peça nesta posição.
                }
                // Caso o if não achar nenhuma peça adversaria eu continuo a pular de casa.
                pos.linha = pos.linha - 1; // pos.linha recebe ela mesma com -1, o -1 faz ela pular de casa.
            }

            //Verificando a posição a BAIXO da Torre.
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario...
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // Enquando for verdadeiro, pode mover.
                //Tenho que fazer um if para quando a peça achar a outra peça adversaria ela parar naquela posição.
                //Se minha peça daposição não estiver vazia E a minha peça tiver com a cor diferente, então...
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // Eu paro a peça nesta posição.
                }
                // Caso o if não achar nenhuma peça adversaria eu continuo a pular de casa.
                pos.linha = pos.linha + 1; // pos.linha recebe ela mesma com +1, o +1 faz ela pular de casa.
            }

            //Verificando a posição a DIREITA da Torre.
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario...
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // Enquando for verdadeiro, pode mover.
                //Tenho que fazer um if para quando a peça achar a outra peça adversaria ela parar naquela posição.
                //Se minha peça daposição não estiver vazia E a minha peça tiver com a cor diferente, então...
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // Eu paro a peça nesta posição.
                }
                // Caso o if não achar nenhuma peça adversaria eu continuo a pular de casa.
                pos.coluna = pos.coluna + 1; // pos.linha recebe ela mesma com -1, o -1 faz ela pular de casa.
            }

            //Verificando a posição a ESQUERDA da Torre.
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            //Enquanto a posição do meu tabuleiro estiver nos padroes de acordo E o podeMover estiver campo vazio ou peça adversario...
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true; // Enquando for verdadeiro, pode mover.
                //Tenho que fazer um if para quando a peça achar a outra peça adversaria ela parar naquela posição.
                //Se minha peça daposição não estiver vazia E a minha peça tiver com a cor diferente, então...
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break; // Eu paro a peça nesta posição.
                }
                // Caso o if não achar nenhuma peça adversaria eu continuo a pular de casa.
                pos.coluna = pos.coluna - 1; // pos.linha recebe ela mesma com -1, o -1 faz ela pular de casa.
            }



            return mat; // Retornando a matriz
        }

    }
}