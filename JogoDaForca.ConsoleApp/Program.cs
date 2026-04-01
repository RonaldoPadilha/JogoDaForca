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

using System.Security.Cryptography;

string[] listaDePalavras = {
    "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "ARAÇA",
    "BACABA", "GRAVIOLA", "BACURI", "GOIABA", "BANANA",
    "JABUTICABA", "CAJA", "JENIPAPO", "MAÇA", "CAJU",
    "CARAMBOLA", "MANGABA", "CUPUAÇU", "MANGA", "MARACUJA",
    "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
    "TANGERINA", "UMBU", "UVA", "UVAIA"
};

bool jogoDeveContinuar = true;

while (jogoDeveContinuar == true)
{
    int indiceAleatorio = RandomNumberGenerator.GetInt32(listaDePalavras.Length);
    string palavraSecreta = listaDePalavras[indiceAleatorio];


    char[] letrasCorretas = new char[palavraSecreta.Length];

    for (int contadorLetras = 0; contadorLetras < palavraSecreta.Length; contadorLetras++)
    {
        letrasCorretas[contadorLetras] = '_';
    }

    bool jogadorAcertou = false;
    int erros = 0;
    String letrasChutadas = "";
    int limiteErros = 5;
    // Loop principal do jogo
    while (!jogadorAcertou && erros < limiteErros)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Jogo da forca");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Erros cometidos: {erros}/{limiteErros}");
        Console.WriteLine($"Chutes: {letrasChutadas}");

        Console.WriteLine("---------------------------------------------------");

        if (erros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |\       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        for (int contadorLetras = 0; contadorLetras < letrasCorretas.Length; contadorLetras++)
        {
            Console.Write(letrasCorretas[contadorLetras] + " ");
        }

        Console.Write("\n\nDigite uma letra: ");
        char chute = char.ToUpper(Convert.ToChar(Console.ReadLine())); // ToUpper garante que 'a' ou 'A' funcionem igual

        if (letrasChutadas.Contains(chute))
        {
            Console.WriteLine($"\nVocê já tentou a letra {chute}! Tente outra.");
            Console.ReadLine();
            continue;
        }

        letrasChutadas += chute + "";

        bool letraEncontrada = false;

        //comparar a letra com cada letra da palavraSecreta
        //descobrir os indices corretos
        for (int contadorPalavrasSecreta = 0; contadorPalavrasSecreta < palavraSecreta.Length; contadorPalavrasSecreta++)
        {
            if (chute == palavraSecreta[contadorPalavrasSecreta])
            {
                letrasCorretas[contadorPalavrasSecreta] = chute;
                letraEncontrada = true;
            }
        }
        if (!letraEncontrada)
        {
            erros++;
            Console.WriteLine("\nLetra incorreta! Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        String palavraAtual = new string(letrasCorretas);
        if (palavraAtual == palavraSecreta)
        {
            jogadorAcertou = true;
        }
        Console.Clear();
        if (jogadorAcertou)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Parabéns! Você acertou a palavra: {palavraSecreta}");
        }
        else
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Limite de {erros} erros atingidos. ");
            Console.WriteLine($"Você falhou misiravelmente! A palavra era: {palavraSecreta}");
        }
    }
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("Deseja jogar novamente ? (s /n): ");
    string opcaoContinuar = Console.ReadLine();

    if (opcaoContinuar != "S" && opcaoContinuar != "s")
    {
        jogoDeveContinuar = false;
    }
}

