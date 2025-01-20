using System;
using System.Collections.Generic;
using System.IO;

class DataNascimento
{
    public int mes;
    public int ano;
}

class Gado
{
    public int codigo;
    public double leite; // Litros de leite por semana
    public double alim; // Quantidade de alimento ingerido por semana
    public DataNascimento nasc;
    public char abate; // 'N' para não e 'S' para sim
}

class Exercicio5

{
    static void lerDados(List<Gado> fazenda)
    {
        Console.Write("Quantas cabeças de gado há na fazenda? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Gado gado = new Gado();
            gado.nasc = new DataNascimento();

            Console.WriteLine($"\nDigite os dados para o gado {i + 1}:");

            Console.Write("Código: ");
            gado.codigo = int.Parse(Console.ReadLine());

            Console.Write("Leite produzido por semana (em litros): ");
            gado.leite = double.Parse(Console.ReadLine());

            Console.Write("Alimento consumido por semana (em quilos): ");
            gado.alim = double.Parse(Console.ReadLine());

            Console.Write("Mês de nascimento: ");
            gado.nasc.mes = int.Parse(Console.ReadLine());

            Console.Write("Ano de nascimento: ");
            gado.nasc.ano = int.Parse(Console.ReadLine());

            gado.abate = 'N'; // Inicialmente o animal não vai para o abate

            fazenda.Add(gado);
        }
    }

    static void calcularAbate(List<Gado> fazenda)
    {
        DateTime hoje = DateTime.Now;
        foreach (Gado gado in fazenda)
        {
            // Calculando a idade do gado
            int idade = hoje.Year - gado.nasc.ano;

            // Verificando se o gado deve ir para o abate
            if (idade > 5 || gado.leite < 40)
            {
                gado.abate = 'S'; // Gado vai para o abate
            }
        }
    }

    static double totalLeite(List<Gado> fazenda)
    {
        double total = 0;
        foreach (Gado gado in fazenda)
        {
            total += gado.leite;
        }
        return total;
    }

    static double totalAlimento(List<Gado> fazenda)
    {
        double total = 0;
        foreach (Gado gado in fazenda)
        {
            total += gado.alim;
        }
        return total;
    }

    static void listarAbate(List<Gado> fazenda)
    {
        Console.WriteLine("\nAnimais que devem ir para o abate:");
        bool encontrado = false;
        foreach (Gado gado in fazenda)
        {
            if (gado.abate == 'S')
            {
                Console.WriteLine($"Código: {gado.codigo} | Leite: {gado.leite} | Alimento: {gado.alim} | Nascimento: {gado.nasc.mes}/{gado.nasc.ano}");
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("Nenhum animal precisa ir para o abate.");
    }

    static void salvarDados(List<Gado> fazenda, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (Gado gado in fazenda)
            {
                writer.WriteLine($"{gado.codigo},{gado.leite},{gado.alim},{gado.nasc.mes},{gado.nasc.ano},{gado.abate}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Gado> fazenda, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            using (StreamReader reader = new StreamReader(nomeArquivo))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');

                    Gado gado = new Gado();
                    gado.nasc = new DataNascimento();

                    gado.codigo = int.Parse(dados[0]);
                    gado.leite = double.Parse(dados[1]);
                    gado.alim = double.Parse(dados[2]);
                    gado.nasc.mes = int.Parse(dados[3]);
                    gado.nasc.ano = int.Parse(dados[4]);
                    gado.abate = char.Parse(dados[5]);

                    fazenda.Add(gado);
                }
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado.");
        }
    }

    static int menu()
    {
        Console.WriteLine("\n*** Sistema de Controle de Fazenda ***");
        Console.WriteLine("1 - Ler Dados");
        Console.WriteLine("2 - Calcular Abate");
        Console.WriteLine("3 - Total de Leite Produzido por Semana");
        Console.WriteLine("4 - Total de Alimento Consumido por Semana");
        Console.WriteLine("5 - Listar Animais que Devem Ir para o Abate");
        Console.WriteLine("6 - Salvar Dados em Arquivo");
        Console.WriteLine("7 - Carregar Dados de Arquivo");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void Main()
    {
        List<Gado> fazenda = new List<Gado>();
        int opcao;

        carregarDados(fazenda, "dados.txt");

        do
        {
            opcao = menu();
            switch (opcao)
            {
                case 1:
                    lerDados(fazenda);
                    break;
                case 2:
                    calcularAbate(fazenda);
                    break;
                case 3:
                    Console.WriteLine($"Total de leite produzido por semana: {totalLeite(fazenda)} litros");
                    break;
                case 4:
                    Console.WriteLine($"Total de alimento consumido por semana: {totalAlimento(fazenda)} quilos");
                    break;
                case 5:
                    listarAbate(fazenda);
                    break;
                case 6:
                    Console.Write("Digite o nome do arquivo para salvar: ");
                    string salvarArquivo = Console.ReadLine();
                    salvarDados(fazenda, salvarArquivo);
                    break;
                case 7:
                    Console.Write("Digite o nome do arquivo para carregar: ");
                    string carregarArquivo = Console.ReadLine();
                    carregarDados(fazenda, carregarArquivo);
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    salvarDados(fazenda, "dados.txt");
                    break;
            }

            Console.ReadKey();
            Console.Clear();

        } while (opcao != 0);
    }
}
