using System;
using System.Collections.Generic;

class Emprestimo
{
    public DateTime data;
    public string nomePessoa;
    public char emprestado; // 'S' ou 'N'
}

class Jogo
{
    public string titulo;
    public string console;
    public int ano;
    public int ranking;
    public Emprestimo emprestimo;
}

class Exercicio4
{
    static void adicionarJogo(List<Jogo> catalogo)
    {
        Jogo novoJogo = new Jogo();
        novoJogo.emprestimo = new Emprestimo();

        Console.WriteLine("*** Dados do Jogo ***");
        Console.Write("Título: ");
        novoJogo.titulo = Console.ReadLine();
        Console.Write("Console: ");
        novoJogo.console = Console.ReadLine();
        Console.Write("Ano: ");
        novoJogo.ano = int.Parse(Console.ReadLine());
        Console.Write("Ranking: ");
        novoJogo.ranking = int.Parse(Console.ReadLine());

        novoJogo.emprestimo.emprestado = 'N'; // Inicialmente não emprestado

        catalogo.Add(novoJogo);
        Console.WriteLine("Jogo adicionado com sucesso!");
    }

    static void listarJogos(List<Jogo> catalogo)
    {
        Console.WriteLine("*** Jogos Cadastrados ***");
        for (int i = 0; i < catalogo.Count; i++)
        {
            Jogo jogo = catalogo[i];
            Console.WriteLine($"Título: {jogo.titulo}");
            Console.WriteLine($"Console: {jogo.console}");
            Console.WriteLine($"Ano: {jogo.ano}");
            Console.WriteLine($"Ranking: {jogo.ranking}");
            Console.WriteLine($"Emprestado: {(jogo.emprestimo.emprestado == 'S' ? "Sim" : "Não")}");
            if (jogo.emprestimo.emprestado == 'S')
            {
                Console.WriteLine($"Pessoa: {jogo.emprestimo.nomePessoa}");
                Console.WriteLine($"Data de Empréstimo: {jogo.emprestimo.data.ToString("dd/MM/yyyy")}");
            }
            Console.WriteLine("-----------------------------");
        }
    }

    static void procurarPorTitulo(List<Jogo> catalogo, string titulo)
    {
        bool encontrado = false;
        foreach (Jogo jogo in catalogo)
        {
            if (jogo.titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                Console.WriteLine($"Emprestado: {(jogo.emprestimo.emprestado == 'S' ? "Sim" : "Não")}");
                if (jogo.emprestimo.emprestado == 'S')
                {
                    Console.WriteLine($"Pessoa: {jogo.emprestimo.nomePessoa}");
                    Console.WriteLine($"Data de Empréstimo: {jogo.emprestimo.data.ToString("dd/MM/yyyy")}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        if (!encontrado)
            Console.WriteLine("Jogo não encontrado.");
    }

    static void listarPorConsole(List<Jogo> catalogo, string console)
    {
        bool encontrado = false;
        foreach (Jogo jogo in catalogo)
        {
            if (jogo.console.Equals(console, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                Console.WriteLine($"Emprestado: {(jogo.emprestimo.emprestado == 'S' ? "Sim" : "Não")}");
                if (jogo.emprestimo.emprestado == 'S')
                {
                    Console.WriteLine($"Pessoa: {jogo.emprestimo.nomePessoa}");
                    Console.WriteLine($"Data de Empréstimo: {jogo.emprestimo.data.ToString("dd/MM/yyyy")}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        if (!encontrado)
            Console.WriteLine("Nenhum jogo encontrado para este console.");
    }

    static void emprestarJogo(List<Jogo> catalogo, string titulo)
    {
        bool encontrado = false;
        foreach (Jogo jogo in catalogo)
        {
            if (jogo.titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) && jogo.emprestimo.emprestado == 'N')
            {
                encontrado = true;
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                Console.WriteLine("Digite o nome da pessoa que vai pegar o jogo:");
                jogo.emprestimo.nomePessoa = Console.ReadLine();
                jogo.emprestimo.data = DateTime.Now;
                jogo.emprestimo.emprestado = 'S';
                Console.WriteLine("Jogo emprestado com sucesso!");
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("Jogo não encontrado ou já emprestado.");
    }

    static void devolverJogo(List<Jogo> catalogo, string titulo)
    {
        bool encontrado = false;
        foreach (Jogo jogo in catalogo)
        {
            if (jogo.titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) && jogo.emprestimo.emprestado == 'S')
            {
                encontrado = true;
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                Console.WriteLine($"Pessoa: {jogo.emprestimo.nomePessoa}");
                Console.WriteLine($"Data de Empréstimo: {jogo.emprestimo.data.ToString("dd/MM/yyyy")}");
                Console.WriteLine("O jogo foi devolvido. Alterando o status para 'Não emprestado'.");
                jogo.emprestimo.emprestado = 'N';
                Console.WriteLine("Jogo devolvido com sucesso!");
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("Jogo não encontrado ou não está emprestado.");
    }

    static void listarJogosEmprestados(List<Jogo> catalogo)
    {
        bool encontrado = false;
        foreach (Jogo jogo in catalogo)
        {
            if (jogo.emprestimo.emprestado == 'S')
            {
                encontrado = true;
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                Console.WriteLine($"Emprestado para: {jogo.emprestimo.nomePessoa}");
                Console.WriteLine($"Data de Empréstimo: {jogo.emprestimo.data.ToString("dd/MM/yyyy")}");
                Console.WriteLine("-----------------------------");
            }
        }

        if (!encontrado)
            Console.WriteLine("Nenhum jogo está emprestado.");
    }

    static int menu()
    {
        Console.WriteLine("*** Sistema de Catálogo de Jogos ***");
        Console.WriteLine("1 - Adicionar Jogo");
        Console.WriteLine("2 - Listar Todos os Jogos");
        Console.WriteLine("3 - Procurar Jogo por Título");
        Console.WriteLine("4 - Listar Jogos por Console");
        Console.WriteLine("5 - Emprestar Jogo");
        Console.WriteLine("6 - Devolver Jogo");
        Console.WriteLine("7 - Listar Jogos Emprestados");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void Main()
    {
        List<Jogo> catalogo = new List<Jogo>();
        int op;

        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    adicionarJogo(catalogo);
                    break;
                case 2:
                    listarJogos(catalogo);
                    break;
                case 3:
                    Console.Write("Digite o título do jogo: ");
                    string tituloBusca = Console.ReadLine();
                    procurarPorTitulo(catalogo, tituloBusca);
                    break;
                case 4:
                    Console.Write("Digite o console: ");
                    string consoleBusca = Console.ReadLine();
                    listarPorConsole(catalogo, consoleBusca);
                    break;
                case 5:
                    Console.Write("Digite o título do jogo para emprestar: ");
                    string tituloEmprestimo = Console.ReadLine();
                    emprestarJogo(catalogo, tituloEmprestimo);
                    break;
                case 6:
                    Console.Write("Digite o título do jogo para devolver: ");
                    string tituloDevolucao = Console.ReadLine();
                    devolverJogo(catalogo, tituloDevolucao);
                    break;
                case 7:
                    listarJogosEmprestados(catalogo);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.ReadKey(); // Pausa
            Console.Clear(); // Limpa a tela
        } while (op != 0);
    }
}
