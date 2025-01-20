using System;
using System.Collections.Generic;
using System.IO;

class Livro
{
    public string Titulo;
    public string Autor;
    public int Ano;
    public string Prateleira;
}

class Exercicio2
{
    static void AdicionarLivro(List<Livro> biblioteca)
    {
        Livro novoLivro = new Livro();
        Console.WriteLine("*** Adicionar Livro ***");
        Console.Write("Título: ");
        novoLivro.Titulo = Console.ReadLine();
        Console.Write("Autor: ");
        novoLivro.Autor = Console.ReadLine();
        Console.Write("Ano: ");
        novoLivro.Ano = int.Parse(Console.ReadLine());
        Console.Write("Prateleira: ");
        novoLivro.Prateleira = Console.ReadLine();

        biblioteca.Add(novoLivro);
        Console.WriteLine("Livro adicionado com sucesso!\n");
    }

    static void ListarLivros(List<Livro> biblioteca)
    {
        Console.WriteLine("*** Livros Cadastrados ***");
        if (biblioteca.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        else
        {
            for (int i = 0; i < biblioteca.Count; i++)
            {
                Console.WriteLine($"*** Livro {i + 1} ***");
                Console.WriteLine($"Título: {biblioteca[i].Titulo}");
                Console.WriteLine($"Autor: {biblioteca[i].Autor}");
                Console.WriteLine($"Ano: {biblioteca[i].Ano}");
                Console.WriteLine($"Prateleira: {biblioteca[i].Prateleira}");
                Console.WriteLine("------------------------------");
            }
        }
    }

    static void BuscarLivroPorTitulo(List<Livro> biblioteca)
    {
        Console.Write("Informe o título do livro que deseja buscar: ");
        string tituloBusca = Console.ReadLine();
        bool encontrado = false;

        foreach (var livro in biblioteca)
        {
            if (livro.Titulo.Equals(tituloBusca, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("*** Livro Encontrado ***");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Prateleira: {livro.Prateleira}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void ListarLivrosMaisNovos(List<Livro> biblioteca)
    {
        Console.Write("Informe o ano para filtrar livros mais novos: ");
        int anoFiltro = int.Parse(Console.ReadLine());
        bool encontrado = false;

        Console.WriteLine("*** Livros Mais Novos ***");
        foreach (var livro in biblioteca)
        {
            if (livro.Ano > anoFiltro)
            {
                Console.WriteLine($"Título: {livro.Titulo} | Autor: {livro.Autor} | Ano: {livro.Ano} | Prateleira: {livro.Prateleira}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Nenhum livro mais novo que o ano informado.");
        }
    }

    static void SalvarDados(List<Livro> biblioteca, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (var livro in biblioteca)
            {
                writer.WriteLine($"{livro.Titulo},{livro.Autor},{livro.Ano},{livro.Prateleira}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void CarregarDados(List<Livro> biblioteca, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (var linha in linhas)
            {
                string[] campos = linha.Split(',');
                Livro livro = new Livro
                {
                    Titulo = campos[0],
                    Autor = campos[1],
                    Ano = int.Parse(campos[2]),
                    Prateleira = campos[3]
                };
                biblioteca.Add(livro);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado.");
        }
    }

    static int Menu()
    {
        Console.WriteLine("*** Sistema de Gerenciamento de Biblioteca ***");
        Console.WriteLine("1 - Adicionar Livro");
        Console.WriteLine("2 - Listar Livros");
        Console.WriteLine("3 - Buscar Livro por Título");
        Console.WriteLine("4 - Listar Livros Mais Novos que um Ano");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void Main()
    {
        List<Livro> biblioteca = new List<Livro>();
        string nomeArquivo = "biblioteca.txt";

        CarregarDados(biblioteca, nomeArquivo);

        int opcao;
        do
        {
            opcao = Menu();
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    AdicionarLivro(biblioteca);
                    break;
                case 2:
                    ListarLivros(biblioteca);
                    break;
                case 3:
                    BuscarLivroPorTitulo(biblioteca);
                    break;
                case 4:
                    ListarLivrosMaisNovos(biblioteca);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    SalvarDados(biblioteca, nomeArquivo);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        } while (opcao != 0);
    }
}


