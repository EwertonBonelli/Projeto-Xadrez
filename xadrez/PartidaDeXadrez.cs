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
        public bool xeque { get; private set; } // variavel para indicar se a minha partida esta em xeque.
        public Peca vulneravelEnPassant { get; private set; } // clamando a classe peça e dando o nome para ela.

        //Construtor padrao.
        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8); //O tab ira receber um novo tabuleiro com as proporções de 8x8.
            turno = 1; //O turno da partida ira começar com 1.
            jogadorAtual = Cor.Branca; //O jogador ira começar com a cor branca.
            terminada = false; //A partida esta recebendo falso porque aqui ela não esta terminada ainda.
            xeque = false; // ela começa com falso por ser um bool.
            vulneravelEnPassant = null;// ela ira iniciar como nulo.
            pecas = new HashSet<Peca>(); //Estanciando as pecas.
            capturadas = new HashSet<Peca>(); //Estanciando as capturadas. 
            colocarPecas(); // Metodo auxiliar que criamos a baixo.
        }

        //Criando uma metodo para executar o movimento da posição de (origem) para a posição de (destino).
        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);// O p que é a peça recebe o metodo da classe Tabuleiro retirarPeca de origem.
            p.incrementarQteMovimentos(); // O p incrementa o movimento da peça pelo metodo incrementarQteMovimentos que esta na classe Peca.
            Peca pecaCapturada = tab.retirarPeca(destino); // Se ja estiver um peça la no destino,a pecaCapturada retira a peça que esta no destino.
            tab.colocarPeca(p, destino);// O p que é a peça colocar ela no destino.
            if (pecaCapturada != null) { // Se a pecaCaptura não for igual a null e porque tem peça nele, então...
                capturadas.Add(pecaCapturada); // o meu conjunto HashSet capturadas ira adicionar a pecaCapturada.
            }

            //Jogada especial roque pequeno.
            //Se essa peça p for um Rei E a coluna de destino for igual a coluna de origem + 2, então...
            //quer dizer que moveu  o rei para duas casas a direira, então e um roque e ser for um roque tenho que mecher na posição da torre.
            if(p is Rei && destino.coluna == origem.coluna + 2) {
                //origem da torre recebe uma nova posição onde a torre esta (a posição da torre).
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                //o destino da torre vai receber uma nova posição da linha do rei e a coluna do rei mais um, pra ficar do lado do rei.
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                //agora vou tirar a torre onde ela estava.
                Peca T = tab.retirarPeca(origemT);
                //agora vou incrementar os movimentos desta torre para falar que ela foi movimentada.
                T.incrementarQteMovimentos();
                //agora tenho que colocar a torre que tirrei para o destino da torre que é destinoT.
                tab.colocarPeca(T, destinoT);
            }


            //Jogada especial roque grande.
            //Se essa peça p for um Rei E a coluna de destino for igual a coluna de origem + 2, então...
            //quer dizer que moveu  o rei para duas casas a esquerda, então e um roque e ser for um roque tenho que mecher na posição da torre.
            if (p is Rei && destino.coluna == origem.coluna - 2) {
                //origem da torre recebe uma nova posição onde a torre esta (a posição da torre).
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                //o destino da torre vai receber uma nova posição da linha do rei e a coluna do rei mais um, pra ficar do lado do rei.
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                //agora vou tirar a torre onde ela estava.
                Peca T = tab.retirarPeca(origemT);
                //agora vou incrementar os movimentos desta torre para falar que ela foi movimentada.
                T.incrementarQteMovimentos();
                //agora tenho que colocar a torre que tirrei para o destino da torre que é destinoT.
                tab.colocarPeca(T, destinoT);
            }

            //Jogadaespecial en passant.
            //Se o peça p é um peao, então...
            if (p is Peao) {
                //Se a origem da coluna não for igual a de destino E a peça capturada estiver vazio, então...
                //quer dizer que estou movendo para os lados e não nas linhas.
                if (origem.coluna != destino.coluna && pecaCapturada == null) {
                    //declarando a variavel da peça.
                    Posicao posP;
                    //Se a cor dessa peça p for a cor branca.
                    if (p.cor == Cor.Branca) {
                        //Aqui estou capturando a peça adversaria preta que esta a baixo da peça branca.
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    }
                    else { //Se for um peao preto...
                        //eu capturo a peça adversaria branca que esta a cima da preta.
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    //retira a peça capturada.
                    pecaCapturada = tab.retirarPeca(posP);
                    //adiciono a peça capturada no grupo de peças capturadas.
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        //Metodo para desfazer o movimento de jogada de xeque que não pode.
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retirarPeca(destino); // retiro a peça de destino que coloquei.
            p.decrementarQteMovimentos();// volto as quantidades de movimentos da peça.
            if (pecaCapturada != null) {// se a minha peça capturada não estiver vazia.
                tab.colocarPeca(pecaCapturada, destino);// devolto a antiga peça capturada na posição de destino
                capturadas.Remove(pecaCapturada);// aqui eu tiro a peça dos conjuntos das peças capturadas.
            }
            tab.colocarPeca(p, origem);// aqui eu volto a peça p na sua posição de origem.

            //Desfazendo a Jogada especial roque pequeno.
            //Se essa peça p for um Rei E a coluna de destino for igual a coluna de origem + 2, então...
            //quer dizer que moveu  o rei para duas casas a direira, então e um roque e ser for um roque tenho que mecher na posição da torre.
            if (p is Rei && destino.coluna == origem.coluna + 2) {
                //origem da torre recebe uma nova posição onde a torre esta (a posição da torre).
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                //o destino da torre vai receber uma nova posição da linha do rei e a coluna do rei mais um, pra ficar do lado do rei.
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                //agora vou pegar a peça no destino.
                Peca T = tab.retirarPeca(destinoT);
                //agora vou decrementar os movimentos desta torre para falar que voltou a jogada.
                T.decrementarQteMovimentos();
                //agora eu devolvo a peça na origemT.
                tab.colocarPeca(T, origemT);

            }

            //Desfazendo a Jogada especial roque grande.
            //Se essa peça p for um Rei E a coluna de destino for igual a coluna de origem + 2, então...
            //quer dizer que moveu  o rei para duas casas a esquerda, então e um roque e ser for um roque tenho que mecher na posição da torre.
            if (p is Rei && destino.coluna == origem.coluna - 2) {
                //origem da torre recebe uma nova posição onde a torre esta (a posição da torre).
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                //o destino da torre vai receber uma nova posição da linha do rei e a coluna do rei mais um, pra ficar do lado do rei.
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                //agora vou pegar a peça no destino.
                Peca T = tab.retirarPeca(destinoT);
                //agora vou decrementar os movimentos desta torre para falar que voltou a jogada.
                T.decrementarQteMovimentos();
                //agora eu devolvo a peça na origemT.
                tab.colocarPeca(T, origemT);

            }

            //Jogadaespecial en passant.
            //Se a peça p é um peao, então...
            if (p is Peao) {
                //Se a colina de origem não for igual a de destino E a peça capturada não for igual a peça vulneravel, então...
                if (origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant) {
                    // tiro o peao que estava no tabuleiro.
                    Peca peao = tab.retirarPeca(destino);
                    Posicao posP;
                    //Se a cor que moveu foi a cor branca...
                    if (p.cor == Cor.Branca) {
                        // posP guarda a posição onde a peça preta estava antes de ser capturada pela branca.
                        posP = new Posicao(3, destino.coluna);
                    }
                    else { //se ela for preta...
                        //posp guarda a posição onde a peça branca estava antes de ser capturada pela preta.
                        posP = new Posicao(4, destino.coluna);
                    }
                    //eu devolvo a peça do peao onde eu tinha retirado na posição posP
                    tab.colocarPeca(peao, posP);
                }
            }
        }


        //Metodo para realizar as jogadas de quem é a vez.
        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino); // a pecaCapturada recebe o executaMovimento da peça.

            if (estaEmXeque(jogadorAtual)) { // Se o jogador estiver em xeque.
                desfazMovimento(origem, destino, pecaCapturada); // ira desfazer a jogada.
                throw new TabuleiroException("Você não pode se colocar em xeque!"); // e apresentar o erro.
            }

            //armazeno a peça de destino.
            Peca p = tab.peca(destino);

            //Jogadaespecial promocao.
            //Se a peça p é um peao...
            if (p is Peao) {
                //Se a peça for da cor branca E a linha for igual a linha zero OU a peça for da cor preta E a linha for igual a 7 e
                //porque ele é uma jogada em promoção.
                //(O zero e a primeira linha do tabuleiro e o sete ea ultima linha do tabuleiro).
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7)) {
                    //vou retirar a peça do tabuleiro.
                    p = tab.retirarPeca(destino);
                    //retiro ele do conjunto de peças em jogo porque ele não é uma peça capturada.
                    pecas.Remove(p);
                    //Agoras eu crio uma nova dama com a mesma cor da peça p.
                    Peca dama = new Dama(tab, p.cor);
                    //Agora eu vou colocar essa nova peça la na posição de destino que retirei a outra peça.
                    //então estou trocando a peça peao pela peça dama, isso se chama jogada em promoção quando
                    // uma peça chega ate o final do tabuleiro e ela pode mudar sua peça pela dama.
                    tab.colocarPeca(dama, destino);
                    //Agora eu adciono essa dama nas peças do tabuleiro.
                    pecas.Add(dama);

                }
            }




            if (estaEmXeque(adversario(jogadorAtual))) { // Se o meu adversario atual estiver em xeque
                xeque = true; // ai sim ele pode, onde xeque recebe verdadeiro.
            }
            else {
                xeque = false;// Se nao xeque recebe falso.
            }

            //Se o meu adversario estiver em xeque mate, significa que o jogo acabou.
            if (testeXequemate(adversario(jogadorAtual))) {
                terminada = true;
            }
            else {// Se Nao eu passo o turno e mudo de jogador.
                turno++;
                mudaJogador();
            }

            // Jogadaespecial en passant.
            //Se essa peça p é um Peao E ela andou menos duas linhas OU ela andou mais duas linhas, então...
            //(o menos duas linhas é a peça branca e o mais duas linhas e a peça preta).
            if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2)) {
                vulneravelEnPassant = p; //essa peça esta vulneravel a timar passant no proximo turno.
            }
            else {//caso ao contrario não tem ninguel vulneravel em passant.
                vulneravelEnPassant = null; // ele continua vazio.
            }
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
            if (!tab.peca(origem).movimentoPossivel(destino)) {
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

        //Metodo para saber a cor do adversario quando de da o xeque.
        private Cor adversario(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        //Operação que ira me devolver um rei de uma dada cor.
        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) { // Pwca x no conjunto de pecasEmJogo de um dada cor.
                if (x is Rei) {// Se a peça x é uma instancia da classe rei, então... (a Peca é uma superclasse e o Rei é uma subclasse).
                    //por isso de usar o "is" se a Peca "é" uma instancia de uma subclasse que é o Rei.
                    return x;
                }
            }
            return null;
        }


        //Metodo para ver se o rei esta em xeque.
        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor); //peça R recebe o rei da cor informada.
            if (R == null) { // Excessão para ver se tem rei no tabuleiro.
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversario(cor))) {// para cada peça x nas peças em jogo nas cor adversarias.
                bool[,] mat = x.movimentosPossiveis();// vou pegar uma matriz de movimentos possiveis e vou testar...
                if (mat[R.posicao.linha, R.posicao.coluna]) {// Se a matriz na posição do rei de linha e coluna for verdadeiro...
                    return true; // significa que a peça x adversaria pode mover para o rei, onde da o xeque.
                }
            }
            return false;// se passar pelo foreach, significa que não esta em xeque.
        }

        //Metodo que ira percorrer todas as peças para ver que tira o rei do quexe, se não peça ai da xequemate.
        public bool testeXequemate(Cor cor) {
            //se o rei desta cor não estiver em xeque...
            if (!estaEmXeque(cor)) {
                return false; //então não esta em xeque.
            }
            //Vou fazer um foreach para percorrer toda peça do jogo que movendo tira o rei do xeque.
            foreach (Peca x in pecasEmJogo(cor)) {
                // eu vou pegar uma matriz de movimento possiveis dessa peça x e para cada movimento
                // possivel dessa matriz eu vou ver se tira do xeque.
                bool[,] mat = x.movimentosPossiveis();
                // vou criar um for para varrer a matriz.
                for (int i = 0; i < tab.linhas; i++) {
                    for (int j = 0; j < tab.colunas; j++) {
                        if (mat[i, j]) { // se a matriz na posicao i e j estiver marcada como verdadeira, então...

                            //Armazenando a posição de origem
                            Posicao origem = x.posicao;
                                         
                            // estanciando a classe Posicao.
                            Posicao destino = new Posicao(i, j);

                            // aqui eu vou executar um movimento da posição  de origem para a posição de destino que e o for do i, j.
                            Peca pecaCapturada = executaMovimento(origem, destino);

                            //agora vou ver se esta em xeque o rei desta cor.
                            bool testeXeque = estaEmXeque(cor);

                            // agora eu vou desfazer o movimento.
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) { //Se nao esta mais em xeque, siginifica que o movimento que fiz em pecaCapturada
                                               //ele nao esta mais em xeque.
                                return false; // retornando falso porque ele não esta mais em xequemate.
                            }
                        }
                    }
                }
            }
            return true; // Se teronar verdadeiro é porque ele esta em xequemate, ai acabou o jogo.
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
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this)); //Como criamos uma propriedade da classe PartidaDeXadrez la na classe Rei, temos que colocar o this para referenciar ela mesma.
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));

            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this)); //Como criamos uma propriedade da classe PartidaDeXadrez la na classe Rei, temos que colocar o this para referenciar ela mesma.
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));
        }
    }
}
