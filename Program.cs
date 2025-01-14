﻿using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado e volte sempre!");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da Filme/Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da Filme/Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Filme/Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite 1 para Série ou 2 para Filme: ");
			int entradatipo = int.Parse(Console.ReadLine());

			Console.Write("Informe o Ano de Início da Filme/Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Informe o Ator principal: ");
			string entradaAtor = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										tipo: entradatipo,
										ano: entradaAno,
										ator: entradaAtor);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar Filme/Série");
			Console.WriteLine("");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Filme/Série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} (Formato: {2}) {3}", serie.retornaId(), serie.retornaTitulo(), serie.retornaTipo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova Filme/Série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Filme/Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite 1 para Série ou 2 para Filme: ");
			int entradatipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Ano de Início da Filme/Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Informe o ator principal: ");
			string entradaAtor = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										tipo:entradatipo, 
										ano: entradaAno,
										ator: entradaAtor);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Filmes/Séries para todos os gostos!");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();
			Console.WriteLine("1- Listar Séries/Filmes");
			Console.WriteLine("2- Inserir nova Filme/Série");
			Console.WriteLine("3- Atualizar Filme/Série");
			Console.WriteLine("4- Excluir Filme/Série");
			Console.WriteLine("5- Visualizar Filme/Série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

