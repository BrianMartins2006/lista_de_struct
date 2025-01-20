using System;
using System.Collections.Generic;
using System.IO;

class Eletrodomestico
{
    public string Nome;
    public double Potencia;
    public double TempoAtivo;
}

class Exercicio3
{
    static void AdicionarEletrodomestico(List<Eletrodomestico> lista)
    {
        Eletrodomestico novo = new Eletrodomestico();
        Console.WriteLine("*** Adicionar Eletrodoméstico ***");
        Console.Write("Nome: ");
        novo.Nome = Console.ReadLine();
        Console.Write("Potência (kW): ");
        novo.Potencia = double.Parse(Console.ReadLine());
        Console.Write("Tempo médio ativo por dia (horas): ");
        novo.TempoAtivo = double.Parse(Console.ReadLine());

        lista.Add(novo);
        Console.WriteLine("Eletrodoméstico adicionado com sucesso!\n");
    }

    static void ListarEletrodomesticos(List<Eletrodomestico> lista)
    {
        Console.WriteLine("*** Eletrodomésticos Cadastrados ***");
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum eletrodoméstico cadastrado.");
        }
        else
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"*** Eletrodoméstico {i + 1} ***");
                Console.WriteLine($"Nome: {lista[i].Nome}");
                Console.WriteLine($"Potência: {lista[i].Potencia} kW");
                Console.WriteLine($"Tempo Ativo: {lista[i].TempoAtivo} horas");
                Console.WriteLine("------------------------------");
            }
        }
    }

    static void BuscarPorNome(List<Eletrodomestico> lista)
    {
        Console.Write("Informe o nome do eletrodoméstico que deseja buscar: ");
        string nomeBusca = Console.ReadLine();
        bool encontrado = false;

        foreach (var item in lista)
        {
            if (item.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("*** Eletrodoméstico Encontrado ***");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Potência: {item.Potencia} kW");
                Console.WriteLine($"Tempo Ativo: {item.TempoAtivo} horas");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Eletrodoméstico não encontrado.");
        }
    }

    static void BuscarPorConsumo(List<Eletrodomestico> lista)
    {
        Console.Write("Informe o valor de consumo (kW/dia) para filtrar: ");
        double consumoFiltro = double.Parse(Console.ReadLine());
        bool encontrado = false;

        Console.WriteLine("*** Eletrodomésticos que Consomem Mais que {0} kW/dia ***", consumoFiltro);
        foreach (var item in lista)
        {
            double consumoDiario = item.Potencia * item.TempoAtivo;
            if (consumoDiario > consumoFiltro)
            {
                Console.WriteLine($"Nome: {item.Nome}, Consumo Diário: {consumoDiario} kW");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Nenhum eletrodoméstico encontrado com consumo superior ao especificado.");
        }
    }

    static void CalcularConsumoTotal(List<Eletrodomestico> lista)
    {
        Console.Write("Informe o valor do kW/h em R$: ");
        double valorKwHora = double.Parse(Console.ReadLine());

        double consumoDiarioTotal = 0;
        foreach (var item in lista)
        {
            consumoDiarioTotal += item.Potencia * item.TempoAtivo;
        }

        double consumoMensalTotal = consumoDiarioTotal * 30; // considerando 30 dias no mês
        double custoMensal = consumoMensalTotal * valorKwHora;

        Console.WriteLine("*** Consumo Total ***");
        Console.WriteLine($"Consumo Diário: {consumoDiarioTotal} kW");
        Console.WriteLine($"Consumo Mensal: {consumoMensalTotal} kW");
        Console.WriteLine($"Custo Mensal: R$ {custoMensal:F2}");
    }

    static void SalvarDados(List<Eletrodomestico> lista, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (var item in lista)
            {
                writer.WriteLine($"{item.Nome},{item.Potencia},{item.TempoAtivo}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void CarregarDados(List<Eletrodomestico> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (var linha in linhas)
            {
                string[] campos = linha.Split(',');
                Eletrodomestico eletro = new Eletrodomestico
                {
                    Nome = campos[0],
                    Potencia = double.Parse(campos[1]),
                    TempoAtivo = double.Parse(campos[2])
                };
                lista.Add(eletro);
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
        Console.WriteLine("*** Sistema de Controle de Consumo ***");
        Console.WriteLine("1 - Adicionar Eletrodoméstico");
        Console.WriteLine("2 - Listar Eletrodomésticos");
        Console.WriteLine("3 - Buscar por Nome");
        Console.WriteLine("4 - Buscar por Consumo Diário");
        Console.WriteLine("5 - Calcular Consumo Total");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void Main()
    {
        List<Eletrodomestico> lista = new List<Eletrodomestico>();
        string nomeArquivo = "eletrodomesticos.txt";

        CarregarDados(lista, nomeArquivo);

        int opcao;
        do
        {
            opcao = Menu();
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    AdicionarEletrodomestico(lista);
                    break;
                case 2:
                    ListarEletrodomesticos(lista);
                    break;
                case 3:
                    BuscarPorNome(lista);
                    break;
                case 4:
                    BuscarPorConsumo(lista);
                    break;
                case 5:
                    CalcularConsumoTotal(lista);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    SalvarDados(lista, nomeArquivo);
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
