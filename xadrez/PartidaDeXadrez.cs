using System.Collections.Generic; //biblioteca para criar um CONJUNTO de peças capturada do tabuleiro.
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
        private HashSet<Peca> pecas; //Esse conjunto ira guardar todas as minhas peças da partida.
        private HashSet<Peca> capturadas; //Esse cojunto ira guardar as peças capturadas na partida.

        //Construtor padrao.
        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8); //O tab ira receber um novo tabuleiro com as proporções de 8x8.
            turno = 1; //O turno da partida ira começar com 1.
            jogadorAtual = Cor.Branca; //O jogador ira começar com a cor branca.
            terminada = false; //A partida esta recebendo falso porque aqui ela não esta terminada ainda.
            pecas = new HashSet<Peca>(); //Estanciando as pecas.
            capturadas = new HashSet<Peca>(); //Estanciando as capturadas. 
            colocarPecas(); // Metodo auxiliar que criamos a baixo.
        }

        //Criando uma operacao para executar o movimento da posição de (origem) para a posição de (destino).
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);// O p que é a peça recebe o metodo da classe Tabuleiro retirarPeca de origem.
            p.incrementarQteMovimentos(); // O p incrementa o movimento da peça pelo metodo incrementarQteMovimentos que esta na classe Peca.
            Peca pecaCapturada = tab.retirarPeca(destino); // Se ja estiver um peça la no destino,a pecaCapturada retira a peça que esta no destino.
            tab.colocarPeca(p, destino);// O p que é a peça colocar ela no destino.
            if (pecaCapturada != null) { // Se a pecaCaptura não for igual a null e porque tem peça nele, então...
                capturadas.Add(pecaCapturada); // o meu conjunto HashSet capturadas ira adicionar a pecaCapturada.
            }
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


        //Metodo que ira me informar qual a cor da peça que foi capturada la no metodo executaMovimento.
        //porque quando eu capturo as peças elas não são separadas por cor, elas ficam tudo misturadas.
        //aqui eu passo como parametro a cor que eu quero, a cor que eu vou digitar.
        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>(); //Criei um conjunto temporario com nome de aux.
            foreach (Peca x in capturadas) {// Aqui eu vou percorrer todas as peças x no conjunto capturadas.(o x é u apelido da Peca).
                if (x.cor == cor) {// Se a cor capturada de x for igual a cor que digitei como parametro, então...
                    aux.Add(x); //Meu conjunto aux adiciona a cor x.
                }
            }
            return aux; // eu retorno o conjunto de aux.
        }


        //Metodo que ira me informar as peças que estão em jogo de uma determina cor.
        public HashSet<Peca> pecasEmJogo(Cor cor) { 
            HashSet<Peca> aux = new HashSet<Peca>(); //Criei um conjunto temporario com nome de aux.
            foreach (Peca x in pecas) {// estou percorrendo todas as peças daqui do jogo
                if (x.cor == cor) { // Se a cor capturada de x for igual a cor que digitei como parametro, então...
                    aux.Add(x); //Meu conjunto aux adiciona a cor x.
                }
            }
            aux.ExceptWith(pecasCapturadas(cor)); // Aqui estou pegando meu aux e vou retirar todas as pecasCapturas desta mesma cor.
            //Assim eu irei ter somente as peças que estão em jogo
            return aux;
        }



        //Metodo auxiliar para colocar as peças no xadrez.
        //Esse metodo ira receber os dados nas suas posições de xadrez (ex: c1 para c4).
        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            //Ele vai colocar essa peça no tabuleiro em uma nova posição de coluna e linha com o ToPosicao().
            // O "toPosicao()" ele faz aquela conversão dos numeros da matriz para os numeros e letras do jogo de xadrez.
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca); //No conjunto PECAS que é o hashSet, vou adicionar a PECA da minha partida para dizer que essa peca faz parte da minha partida.

        }

        //Criando um metodo para colocar as peças no xadrez.
        private void colocarPecas() {
            // Eu estou chamando o metodo colocarNovapeca e acrescentando nela as peças e as suas posições.
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
            
        }
    }
}
