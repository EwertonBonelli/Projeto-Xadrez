using System;

namespace tabuleiro {
    class TabuleiroException : Exception { // Extanciando a classe oculta Exception.

        //Criando um contrutor com argumento msg para uma exceção personalizada.
        public TabuleiroException(string msg) : base(msg) {

        }
    }
}
