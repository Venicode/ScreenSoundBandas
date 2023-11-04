//Variáveis camel case
string boasVindas = "Bem vindo(a) ao Screen Sound";
//instanciou a lista com o new
//List<string> listaBandas = new List<string> { "The Strokes", "Arctic Monkeys", "The Smiths"};
Dictionary<string, List<int>> bandasRegistradas = new ();
bandasRegistradas.Add("Linkin Park", new() { 10, 8, 7 });
bandasRegistradas.Add("The Smiths", new() { 10, 8, 7 });
bandasRegistradas.Add("The Beatles", new());
//Variáveis pascal case
void ExibirMensagem()
{
    //Simbolo @ é utilizado para exibir um símbolo de forma literal -- Verbatim Literal
    Console.WriteLine(@"
███████╗ ██████╗██████╗ ███████╗███████╗███╗   ██╗    ███████╗ ██████╗ ██╗   ██╗███╗   ██╗██████╗ 
██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝████╗  ██║    ██╔════╝██╔═══██╗██║   ██║████╗  ██║██╔══██╗
███████╗██║     ██████╔╝█████╗  █████╗  ██╔██╗ ██║    ███████╗██║   ██║██║   ██║██╔██╗ ██║██║  ██║
╚════██║██║     ██╔══██╗██╔══╝  ██╔══╝  ██║╚██╗██║    ╚════██║██║   ██║██║   ██║██║╚██╗██║██║  ██║
███████║╚██████╗██║  ██║███████╗███████╗██║ ╚████║    ███████║╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝
╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═══╝    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ");
    Console.WriteLine(boasVindas);
}
//criando uma função sem retorno
void Menu()
{
    Console.Clear();
    ExibirMensagem();

    List<string> opcoes = new(){ "1- Registrar uma nova banda", "2- Exibir as bandas",
            "3- Avaliar uma banda", "4-Exibir a média de uma banda", "0- Sair do programa" };

    Console.WriteLine("\nEscolha uma das opções:");
    foreach (string i in opcoes)
    {
        Console.WriteLine(i);
    }

    Console.Write("\nDigite a sua opção:");
    string opcaoMenu = Console.ReadLine()!;//exclamação significa que pode receber valor nulo
    int opcaoMenuN = int.Parse(opcaoMenu); //convertendo para inteiro

    switch (opcaoMenuN)
    {
        //interpolãção de string
        case 1:
            RegistrarBandas();
            break;
        case 2:
            ExibirBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            Console.WriteLine($"Você escolheu a opção: {opcaoMenuN}");
            break;
        case 0:
            Console.WriteLine("Até breve.");
            break;
        default:
            Console.WriteLine("Digite uma opção válida");
            break;
    }
}

void RegistrarBandas()
{

    Console.Clear();
    ExibirTituloOpcoes("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string novaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(novaBanda, new List<int>());
    Console.WriteLine($"A banda {novaBanda} foi registrada com sucesso!");
    Console.WriteLine("\nAperte uma tecla para voltar ao menu");
    Console.ReadKey();
    Menu();
}

void ExibirBandas()
{
    Console.Clear();
    ExibirTituloOpcoes("Bandas registradas");
    //for (int i = 0; i < listaBandas.Count; i++)
    //{
    //    Console.WriteLine(listaBandas[i]);
    //}
    foreach (string i in bandasRegistradas.Keys)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("\nAperte uma tecla para voltar ao menu");
    Console.ReadKey();
    Menu();
}

void ExibirTituloOpcoes(string titulo)
{
    int qtdLetras = titulo.Length;
    string estilo = string.Empty.PadLeft(qtdLetras, '-');
    Console.WriteLine($"{estilo}\n{titulo}\n{estilo}");
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloOpcoes("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string bandaAvaliar = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(bandaAvaliar))
    {
        Console.Write($"Qual a nota que a banda {bandaAvaliar} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[bandaAvaliar].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso " +
            $"para a banda {bandaAvaliar}!");
        Thread.Sleep(2000);
        Menu();
    }
    else
    {
        Console.WriteLine($"A banda {bandaAvaliar} não foi encontrada. Registre-a para poder avaliar.");
        Console.WriteLine("Aperte uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Menu();
    }
}

Menu();