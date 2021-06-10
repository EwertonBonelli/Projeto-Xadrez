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
        public int turno { get; private set; } // Turno das jogadas.
        public Cor jogadorAtual { get; private set; } // Chamei o Enum
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

        //Metodo para realizar as jogas de quem é a vez.
        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        //Metodo para ver se a peça de origem que o usuario digitou e valida.
        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) { //Se a peça que esta no batuleiro nesta possição estiver vazio, então...
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!"); //apresento essa mensagem.
            }
            if (jogadorAtual != tab.peca(pos).cor) {//Se a peça do jogador atual não for da mesma cor da peça escolhida, então... 
                throw new TabuleiroException("A peça de origem escolhida não é sua!"); //apresento essa mensagem.
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) { //Se não existe movimentos possiveis para essa peça, então...
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!"); //apresento essa mensagem.
            }
        }

        //Metodo para validar a posição de destino da peça.
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            //Se a minha peça de origem não poder mover para a posição de destino, então...
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino invalida!"); //apresente a mensagem de erro.
            }
        }


        //Metodo para saber de quem é a vez de jogar.
        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca) { //Se o jogador atual for igual a cor branca, então...
                jogadorAtual = Cor.Preta; // e a vez do jogador preto.
            }
            else { //Se nao...
                jogadorAtual = Cor.Branca; // e a vez do jogador branco.
            }
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
