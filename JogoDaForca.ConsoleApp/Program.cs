/*
Requisitos
1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
assim como as letras erradas.
3. O jogador poderá cometer até cinco erros, caso erre pela quinta vez, ou acerte a palavra a partida
acaba.
4. Deve-se apresentar um desenho da forca sendo atualizado a cada erro.
*/


//1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
String palavraSecreta = "ABACATE";

//2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa 
//deverá ser apresentada, assim como as letras erradas.
char[] letrasCorretas = new char[7];

for (int contadorLetras = 0; contadorLetras < 7; contadorLetras++)
{
    letrasCorretas[contadorLetras] = '_';
}

bool jogadorAcertou = false;

while (!jogadorAcertou)
{
    //Console.Clear();

    for (int contadorLetras = 0; contadorLetras < 7; contadorLetras++)
    {
        Console.Write(letrasCorretas[contadorLetras]);
    }

    Console.Write("\nDigite uma letra: ");
    char chute = Convert.ToChar(Console.ReadLine());

    //comparar a letra com cada letra da palavraSecreta
    //descobrir os indices corretos
    for (int contadorPalavrasSecreta = 0; contadorPalavrasSecreta < palavraSecreta.Length; contadorPalavrasSecreta++)
    {

        char letraSecretaAtual = palavraSecreta[contadorPalavrasSecreta];

        if (chute == letraSecretaAtual)
        {
            letrasCorretas[contadorPalavrasSecreta] = chute;
        }

    }
    // condição de vitória
    String palavraAtual = new string(letrasCorretas); // transformo de char para String
    if (palavraAtual == palavraSecreta)
    {
        Console.WriteLine("Parabéns, você acertou a palavra! ");
        jogadorAcertou = true; // encerrar o while
    }


    Console.ReadLine();
}