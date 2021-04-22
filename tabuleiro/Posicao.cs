﻿
namespace tabuleiro{
    class Posicao{
        //Criando os atributos.
        //O tabuleiro sao acessados por linhas e colunas.
        public int linha { get; set; }
        public int coluna { get; set; }

        //criando um construtor com argumentos.
        //a utilização do "this" é para identificar a "linha" e "coluna" que criamos como atributos.
        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        //Criação do ToString para poder converter os dados em uma string e apresentar ela na tela do usuario.
        public override string ToString(){
            return linha
                + ", "
                + coluna;
        }
    }
}
