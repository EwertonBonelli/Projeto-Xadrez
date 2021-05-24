using System;
using tabuleiro; //importando o diretorio das classes.

/*
-Aqui irei criar as partidas de xadrez.

-Nessa partida ira ter o tabuleiro tab, o turno das partidas, jogadorAtual para saber de quem é a vez de jogar e a
terminada para indicar se a partida esta terminada ou nao.

-Vou criar um contrutor sem argumentos e neles ira conter o tab que é o tabuleiro com as proporções de 8x8,
a partida ira iniciar com o turno 1 e o jogador ira iniciar com a cor da peça branca.

-Irei criar uma operação onde ela ira fazer as movimentações das peças da sua posição de origem para destino.

-Irei criar um metodo para colocar as peças no xadrez e já fazendo a conversão de matriz para xadrez.

 */

namespace xadrez {//Deixar o namespace somente como xadrez.
    class PartidaDeXadrez {
        //Criação das propriedades.
        public Tabuleiro tab { get; private set; } // estou chamando a classe Tabuleiro e dando o nome de tab.
        private int turno; // Turno das jogadas.
        private Cor jogadorAtual; // Chamei o Enum
        public bool terminada { get; private set; } // somente leitura.

        //Construtor padrao.
        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8); //O tab ira receber um novo tabuleiro com as proporções de 8x8.
            turno = 1; //O turno da partida ira começar com 1.
            jogadorAtual = Cor.Branca; //O jogador ira começar com a cor branca.
            terminada = false; //A partida esta recebendo falso porque aqui ela não esta terminada ainda.
            colocarPecas(); // Metodo auxiliar que criamos a baixo.
        }

        //Criando uma operacao para executar o movimento da posição de (origem) para a posição de (destino).
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);// O p que é a peça recebe o metodo da classe Tabuleiro retirarPeca de origem.
            p.incrementarQteMovimentos(); // O p incrementa o movimento da peça pelo metodo incrementarQteMovimentos que esta na classe Peca.
            Peca pecaCapturar = tab.retirarPeca(destino); // Se ja estiver um peça la no destino,a pecaCapturada retira a peça que esta no destino.
            tab.colocarPeca(p, destino);// O p que é a peça colocar ela no destino
        }

        //Criando um metodo para colocar as peças no xadrez.
        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao()); // O "toPosicao()" ele faz aquela conversão dos numeros
            //da matriz para os numeros e letras do jogo de xadrez.
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
