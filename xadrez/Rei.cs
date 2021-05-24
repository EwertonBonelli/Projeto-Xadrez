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
    }
}
