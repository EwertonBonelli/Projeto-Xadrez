
namespace tabuleiro {
    class Peca {
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
        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor) {
            this.posicao = posicao;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

    }
}
