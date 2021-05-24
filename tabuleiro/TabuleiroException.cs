/*
 Nessa classe iremos criar a tratativa de erro para as outras classes.
 */

using System;

namespace tabuleiro {//Deixar o namespace somente como tabuleiro.
    class TabuleiroException : Exception { // Extanciando a classe oculta Exception.

        //Criando um contrutor com argumento msg para uma exceção personalizada.
        public TabuleiroException(string msg) : base(msg) {

        }
    }
}
