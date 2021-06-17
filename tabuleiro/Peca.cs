/*
-Essa classe são as peças que iremos usar junto com a cor que é o enumerado e a posição do tabuleiro para
identificar quais posição a peça ira ficar.

-Irei criar um metodo para saber quantod movimentos a peça ira fazer na jogada.
 */
namespace tabuleiro {//Deixar o namespace somente como tabuleiro.
    abstract class Peca { //Classe abstrata.
        //Criando as propriedades.
        public Posicao posicao { get; set; } //propriedade da classe Posicao.
        public Cor cor { get; protected set; } //Propriedade do Enum Cor onde ela pode ser acessada pelas outras classes(get).
                                               //e pode ser alterada/escrita por ela mesma e outras subclasses dela(protected set).
        public int qteMovimentos { get; protected set; } //Propriedade quantidade de movimentos para ver se o pião esta sendo movimentado pela primeira vez.
                                                         //ela pode ser acessada/obtida pelas outras classes(get).
                                                         //e pode ser alterada/escrita por ela mesma e outras subclasses dela(protected set).
        public Tabuleiro tab { get; protected set; } //Propriedade da classe Tabuleiro.
                                                     //ela pode ser acessada/obtida pelas outras classes(get).
                                                     //e pode ser alterada/escrita por ela mesma e outras subclasses dela(protected set).

        //Construtor com argumentos.
        //O "this" é para identificar as propriedades que criamos no comeco do codigo.
        public Peca(Tabuleiro tab, Cor cor) {
            //quando criar uma peca a posição dela sera null porque ela não tem posição ainda.
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        //Criando um metodo para somar quantos movimentos a peça esta fazendo.
        public void incrementarQteMovimentos() {
            qteMovimentos++;
        }

        //Criando um metodo para tirar quantos movimentos a peça esta fazendo caso a peça tiver que voltar para sua origem.
        public void decrementarQteMovimentos() {
            qteMovimentos--;
        }

        //Operação para ver se a peça atual não esta bloqueada entre outras peças ao redor para fazer os movimentos.
        public bool existeMovimentosPossiveis() {
            //Criando uma matriz temporaria para receber o movimentosPossiveis de jogadas.
            bool[,] mat = movimentosPossiveis();
            //For para percorrer as linhas e colunas da matriz.
            for(int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) { 
                    if(mat[i, j] == true) { // se essa posição for verdadeiro, então...
                        return true;
                    }
                }
            }
            return false; // retorna quando não tem nenhum movimento possivel na minha operação.
        }


        //Metodo para ver se pode mover para uma dada posicao.
        // Esse metodo ira retornar verdadeiro ou falso para movimentos possiveis de uma peça. 
        public bool podeMoverPara(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna]; 
        }


        //Metodo abstrato para movimentos possiveis da peça.
        public abstract bool[,] movimentosPossiveis();

    }
}
