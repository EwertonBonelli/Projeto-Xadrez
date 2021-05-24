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
    }
}