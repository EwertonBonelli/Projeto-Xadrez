/*
 Enumerodo para as cores das peças do xadrez.
 */
namespace tabuleiro {//Deixar o namespace somente como tabuleiro.
    enum Cor { //Criação tipo enumerado (Enum).

        Branca,
        Preta,
        Amarela,
        Azul,
        Vermelha,
        Verde,
        Laranja

        /*
         Neste caso não precisei colocar valor na frente dos objetos enum porque o proprio sistema ja identifica
         os valores comecando ele com o Zero.
          Branca = 0,
          Preta = 1,
          Amarela = 2,
          Azul = 3,
          Vermelha = 4,
          Verde = 5,
          Laranja = 6
         */
    }
}
