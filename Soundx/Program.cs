string boasVindas = "Seja bem vindo ao Soundx!";
//List<string> listaDeBandas = new List<string> { "U2", "Beatles", "Sepultura"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();//DIcionário bandas registradas pelo usuario
bandasRegistradas.Add("U2", new List<int> { 10, 2, 8, 9 });
bandasRegistradas.Add("Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
███████████████████████████████████████
█─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█▄─▀─▄█
█▄▄▄▄─█─██─██─██─███─█▄▀─███─██─██▀─▀██
▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀▄▄█▄▄▀
");
    Console.WriteLine(boasVindas);
}

void ExibirTitulo(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void FinalizacaoDeCaso()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    MostrarMenu();
}

void MostrarMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para adicionar uma banda");
    Console.WriteLine("Digite 2 para ver todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a opção desejada: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoNum = int.Parse(opcaoEscolhida);//transforma string em int

    switch (opcaoNum)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMedia();
            break;
        case 0:
            Console.Clear();
            ExibirTitulo("Obrigado por usar o Soundx! Até a próxima!");
            break;
        default:
            OpcaoInvalida();
            break;
    }
}

void RegistrarBandas()
{
    Console.Clear();
    ExibirTitulo("Registro das bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"A banda {nomeBanda} foi registrada!");
    Thread.Sleep(2000); // Pausa de 2 segundos para o usuário ler a mensagem
    Console.Clear();
    MostrarMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulo("Banda(s) registrada(s)\n");
    /*for (int i = 0; i < listaDeBandas.Count; i++)
    {
        Console.WriteLine($"Bandas: {listaDeBandas[i]}\n");
    }*/

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Bandas: {banda}\n");
    }
    FinalizacaoDeCaso();
}

void AvaliarBanda()
{
    //banda que deseja avaliar
    //tem que exister no dicionario

    Console.Clear();
    ExibirTitulo("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota que você deseja dar para a banda {nomeBanda}? (0 a 10): ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada para a banda {nomeBanda}.\n");
        Thread.Sleep(1000);
        FinalizacaoDeCaso();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.\n");
        FinalizacaoDeCaso();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTitulo("Nota media das bandas");

    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notas = bandasRegistradas[nomeBanda];
        if (notas.Count > 0)
        {
            double media = notas.Average();
            Console.WriteLine($"\nA média das notas da banda {nomeBanda} é: {media:F2}\n");
            FinalizacaoDeCaso();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeBanda} não possui avaliações registradas.\n");
            FinalizacaoDeCaso();
        }
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.\n");
    }
    FinalizacaoDeCaso();
}

void OpcaoInvalida()
{
    Console.WriteLine("\nOpcao Invalida, tente novamente\n");
    FinalizacaoDeCaso();
}

MostrarMenu();