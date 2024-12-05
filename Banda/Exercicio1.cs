using System;
using System.IO;
class TipoBanda
{
    public string nome;
    public string genero;
    public int integrantes;
    public int ranking;
}
class Program
{
    static void addBanda(List<TipoBanda> listadeBandas)
    {
        TipoBanda novaBanda = new TipoBanda();
        Console.WriteLine("*** Dados para Banda ***");
        Console.Write("Nome:");
        novaBanda.nome = Console.ReadLine();
        Console.Write("Gênero:");
        novaBanda.genero = Console.ReadLine();
        Console.Write("Integrantes:");
        novaBanda.integrantes = int.Parse(Console.ReadLine());
        Console.Write("Ranking:");
        novaBanda.ranking = int.Parse(Console.ReadLine());
        listadeBandas.Add(novaBanda);
        Console.WriteLine("Dados adicionados com sucesso!");
    }
    static void mostraBandas(List<TipoBanda> listadeBandas)
    {
        Console.WriteLine("*** Bandas Cadastradas ***");
        for (int i = 0; i < listadeBandas.Count; i++)
        {
            Console.WriteLine($"*** Banda {i + 1} ***");
            Console.WriteLine($"Nome:{listadeBandas[i].nome}");
            Console.WriteLine($"Gênero:{listadeBandas[i].genero}");
            Console.WriteLine($"Integrantes:{listadeBandas[i].integrantes}");
            Console.WriteLine($"Ranking:{listadeBandas[i].ranking}");
            Console.WriteLine("------------------------------");
        }
    }

    static void buscaBanda(List<TipoBanda> listadeBandas,
                                            string nomeBusca)
    {
        bool encontrado = false;
        for (int i = 0; i < listadeBandas.Count; i++)
        {
            string nomeAtual = listadeBandas[i].nome.ToUpper();

            if (nomeAtual.Contains(nomeBusca.ToUpper()))
            {
                encontrado = true;
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome:{listadeBandas[i].nome}");
                Console.WriteLine($"Gênero:{listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes:{listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking:{listadeBandas[i].ranking}");
                Console.WriteLine("------------------------------");
                break;
            }// fim if
        }// fim for

        if (encontrado == false) Console.WriteLine("Banda não encontrado");


    }
    static void alteraBanda(List<TipoBanda> listadeBandas,
                                           string nomeBusca)
    {
        for (int i = 0; i < listadeBandas.Count; i++)
        {
            string nomeAtual = listadeBandas[i].nome.ToUpper(); 

            if (nomeAtual.Contains(nomeBusca.ToUpper() ))
            {
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome:{listadeBandas[i].nome}");
                Console.WriteLine($"Gênero:{listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes:{listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking:{listadeBandas[i].ranking}");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Tem certeza que deseja alterar [S/N]?");
                char resp = char.Parse(Console.ReadLine());
                if (resp == 'S' || resp == 's')
                {
                    TipoBanda novaBanda = new TipoBanda();
                    Console.WriteLine("*** Dados para alterar a Banda ***");
                    Console.Write("Nome:");
                    novaBanda.nome = Console.ReadLine();
                    Console.Write("Gênero:");
                    novaBanda.genero = Console.ReadLine();
                    Console.Write("Integrantes:");
                    novaBanda.integrantes = int.Parse(Console.ReadLine());
                    Console.Write("Ranking:");
                    novaBanda.ranking = int.Parse(Console.ReadLine());
                    listadeBandas[i] = novaBanda;
                    Console.WriteLine("Dados adicionados com sucesso!");
                    Console.WriteLine("Banda alterada com sucesso!");
                }
                else
                    Console.WriteLine("Operação cancelada");

                break;
            }// fim if
        }// fim for

    }

    static void buscaGenero(List<TipoBanda> listadeBandas,
                                           string nomeBusca)
    {
        bool encontrado = false;
        for (int i = 0; i < listadeBandas.Count; i++)
        {
            string nomeAtual = listadeBandas[i].nome.ToUpper();

            if (nomeAtual.Contains(nomeBusca.ToUpper()))
            {
                encontrado = true;
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome:{listadeBandas[i].nome}");
                Console.WriteLine($"Gênero:{listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes:{listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking:{listadeBandas[i].ranking}");
                Console.WriteLine("------------------------------");

            }// fim if
        }// fim for

        if (encontrado== false) Console.WriteLine("Genero não encontrado");

    }

    static void removeBanda(List<TipoBanda> listadeBandas,
                                            string nomeBusca)
    {
        for (int i = 0; i < listadeBandas.Count; i++)
        {
            if (listadeBandas[i].nome.Equals(nomeBusca))
            {
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome:{listadeBandas[i].nome}");
                Console.WriteLine($"Gênero:{listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes:{listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking:{listadeBandas[i].ranking}");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Tem certeza que deseja excluir [S/N]?");
                char resp = char.Parse(Console.ReadLine());
                if (resp == 'S' || resp == 's')
                {
                    listadeBandas.RemoveAt(i);
                    Console.WriteLine("Banda excluída com sucesso!");
                }
                else
                    Console.WriteLine("Operação cancelada");

                break;
            }// fim if
        }// fim for

    }
    static void salvarDados(List<TipoBanda> listadeBandas, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);

        foreach (TipoBanda banda in listadeBandas)
        {
            writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
        }

        Console.WriteLine("Dados salvos com sucesso!");
        writer.Dispose();
    }



    static void carregarDados(List<TipoBanda> listadeBandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda();
                banda.nome = campos[0];
                banda.genero = campos[1];
                banda.integrantes = int.Parse(campos[2]);
                banda.ranking = int.Parse(campos[3]);
                listadeBandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }


    static int menu()
    {
        Console.WriteLine("*** Sistema de Cadastro 4Rocks ****");
        Console.WriteLine("1-Inserir");
        Console.WriteLine("2-Mostrar");
        Console.WriteLine("3-Busca banda");
        Console.WriteLine("4-Busca genero");
        Console.WriteLine("5-Remover");
        Console.WriteLine("6-Altera banda");
        Console.WriteLine("0-Sair");
        int op = int.Parse(Console.ReadLine());
        return op;
    }
    static void Main()
    {
        List<TipoBanda> listadeBandas = new List<TipoBanda>();
        int op;
        carregarDados(listadeBandas, "dados.txt");
        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    addBanda(listadeBandas);
                    break;
                case 2:
                    mostraBandas(listadeBandas);
                    break;
                case 3:
                    Console.WriteLine("Banda para buscar:");
                    string nomebanda = Console.ReadLine();
                    buscaBanda(listadeBandas, nomebanda);
                    break;
                case 4:
                    Console.WriteLine("Genero para buscar:");
                    string nomegenero = Console.ReadLine();
                    buscaGenero(listadeBandas, nomegenero);
                    break;
                case 5:
                    Console.WriteLine("Banda para buscar:");
                    nomebanda = Console.ReadLine();
                    removeBanda(listadeBandas, nomebanda);
                    break;
                case 6:
                    Console.WriteLine("Banda para alterar:");
                    nomebanda = Console.ReadLine();
                    alteraBanda(listadeBandas, nomebanda);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    salvarDados(listadeBandas, "dados.txt");
                    break;
            }// fim switch
            Console.ReadKey(); // pausa
            Console.Clear(); // limpa tela
        } while (op != 0);


    }// fim main

}



