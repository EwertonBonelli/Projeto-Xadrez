﻿using System;
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.
using xadrez; // Importando o diretorio das classes.

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                //estanciando a classe PartidaXadrez.
                PartidaDeXadrez partida = new PartidaDeXadrez();

                //Enquanto a minha partida não estiver terminada...
                while (!partida.terminada) {

                    Console.Clear(); // Limpa a tela.
                    //Imprimindo o tabuleiro.
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    //metodo para ler do teclado uma posicao do xadrez.
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); // Lendo a posicao e transformando ela em matriz (toPosicao()).
                    
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }


                
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();
        }
    }
}
