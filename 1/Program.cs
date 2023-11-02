using System;
using System.IO;
class Program
{
    struct TipoBanda
    {
        public string nome;
        public string genero;
        public int integrantes;
        public int ranking;

    }// fim struct

    static void addBanda(List<TipoBanda> lista)
    {

        TipoBanda novaBanda = new TipoBanda();// declarando uma variavel do TipoBanda
        Console.Write("Nome da banda:");
        novaBanda.nome = Console.ReadLine();// ReadLine é o scanf
        Console.Write("Genero da banda:");// Console.Write é o printf
        novaBanda.genero = Console.ReadLine();
        Console.Write("Integrantes:");
        novaBanda.integrantes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ranking:");
        novaBanda.ranking = Convert.ToInt32(Console.ReadLine());
        lista.Add(novaBanda);
    }// fim funcao //List é um vetor

    static void removerBanda(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();// pegando quantos elementos eu tenho no meu vetor.
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Equals(nomeBusca.ToUpper()))// fazendo minha string ficar toda em maísculo, para a comparação não haver erros
            {// Contais, ou Equals, podemos usar os dois para comparar strings.
                Console.WriteLine($"Quer mesmo excluir {nomeBusca}? S/N");
                char resposta;
                resposta = Convert.ToChar(Console.ReadLine());

                if (resposta == 'S' || resposta == 's')
                {
                    lista.RemoveAt(i);
                    Console.WriteLine("Banda excluida com sucesso!");
                    break;
                }
                else
                {
                    Console.WriteLine("Operação Cancelada");
                }


            }// fim if
        }// fim for
    }// fim lista

    static void alterarBanda(List<TipoBanda> lista, string nomeBusca)//Alterar banda
    {
        int qtd = lista.Count();// pegando quantos elementos eu tenho no meu vetor.
        bool flag = false;

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Equals(nomeBusca.ToUpper()))// fazendo minha string ficar toda em maísculo, para a comparação não haver erros
            {// Contais, ou Equals, podemos usar os dois para comparar strings.

                flag = true;
                TipoBanda novaBanda = new TipoBanda();// declarando uma variavel do TipoBanda
                Console.Write("Novo Nome da banda:");
                novaBanda.nome = Console.ReadLine();// ReadLine é o scanf
                Console.Write("Novo Genero da banda:");// Console.Write é o printf
                novaBanda.genero = Console.ReadLine();
                Console.Write("Nova quantidade de Integrantes:");
                novaBanda.integrantes = Convert.ToInt32(Console.ReadLine());
                Console.Write("Novo Ranking:");
                novaBanda.ranking = Convert.ToInt32(Console.ReadLine());
                lista[i] = novaBanda;
            }// fim if
        }// fim for

        if (flag == false)
        {
            Console.WriteLine("Banda nao encontrada!");
        }

    }// fim lista

    static void listaBandas(List<TipoBanda> lista)
    {
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine("\t*** Dados da banda ***");
            Console.WriteLine("Nome:" + lista[i].nome);
            Console.WriteLine("Genero:" + lista[i].genero);
            Console.WriteLine("Integrantes:" + lista[i].integrantes);
            Console.WriteLine("Ranking:" + lista[i].ranking);
        }// fim for
    }// fim lista


    static void listarRanking(List<TipoBanda> lista, int idRanking)
    {
        int qtd = lista.Count();// pegando quantos elementos eu tenho no meu vetor.
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].ranking == idRanking)// pegando o ranking de lista e comparando com o parametro idRanking
            {
                Console.WriteLine("\t*** Dados da banda ***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrantes);
                Console.WriteLine("Ranking:" + lista[i].ranking);
            }// fim if
        }// fim for
    }// fim lista

    static void buscarNome(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();// pegando quantos elementos eu tenho no meu vetor.
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Contains(nomeBusca.ToUpper()))// fazendo minha string ficar toda em maísculo, para a comparação não haver erros
            {// Contais, ou Equals, podemos usar os dois para comparar strings.
                Console.WriteLine("\t*** Dados da banda ***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrantes);
                Console.WriteLine("Ranking:" + lista[i].ranking);
                //break;
            }// fim if
        }// fim for
    }// fim lista

    static void buscargenero(List<TipoBanda> lista, string nomeBusca)
    {
        int qtd = lista.Count();// pegando quantos elementos eu tenho no meu vetor.
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].genero.ToUpper().Contains(nomeBusca.ToUpper()))// fazendo minha string ficar toda em maísculo, para a comparação não haver erros
            {// Contais, ou Equals, podemos usar os dois para comparar strings.
                Console.WriteLine("\t*** Dados da banda ***");
                Console.WriteLine("Nome:" + lista[i].nome);
                Console.WriteLine("Genero:" + lista[i].genero);
                Console.WriteLine("Integrantes:" + lista[i].integrantes);
                Console.WriteLine("Ranking:" + lista[i].ranking);
                //break;
            }// fim if
        }// fim for
    }// fim lista


    static int somaintegrantes(List<TipoBanda> lista)
    {
        int soma = 0;
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            soma += lista[i].integrantes;
        }

        return soma;

    }
    static void salvarDados(List<TipoBanda> bandas, string nomeArquivo)
    {

        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (TipoBanda banda in bandas)
            {
                writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");


    }

    static void carregarDados(List<TipoBanda> bandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda
                {
                    nome = campos[0],
                    genero = campos[1],
                    integrantes = int.Parse(campos[2]),
                    ranking = int.Parse(campos[3])
                };

                bandas.Add(banda);
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

        Console.WriteLine("\n\tSistema de Cadastros");
        Console.WriteLine("1-Adicionar banda");
        Console.WriteLine("2-Listar");
        Console.WriteLine("3-Filtrar por Ranking");
        Console.WriteLine("4-Buscar por nome");
        Console.WriteLine("5-Buscar por genero");
        Console.WriteLine("6-Alterar banda");
        Console.WriteLine("7-Excluir banda");
        Console.WriteLine("0-Sair");
        Console.Write("\nInput:");
        int op = Convert.ToInt32(Console.ReadLine());
        return op;
    }
    static void Main() //Main
    {

        List<TipoBanda> listadeBandas = new List<TipoBanda>();

        int op;
        carregarDados(listadeBandas, "dados.txt");
        do
        {
            op = menu();
            switch (op)   // switch = caso o usuario digitou, 1, 2, 3...
            {
                case 1:
                    addBanda(listadeBandas);
                    break;
                case 2:
                    listaBandas(listadeBandas);
                    break;
                case 3:
                    Console.Write("Ranking para filtro: ");
                    int idRanking = Convert.ToInt32(Console.ReadLine());  // Convertendo string para inteiro
                    listarRanking(listadeBandas, idRanking);
                    break;
                case 4:
                    Console.Write("Nome para busca:");
                    string nomeBusca = Console.ReadLine();
                    buscarNome(listadeBandas, nomeBusca);
                    break;

                case 5:
                    Console.Write("Genero para busca:");
                    nomeBusca = Console.ReadLine();
                    buscargenero(listadeBandas, nomeBusca);
                    break;
                case 6:
                    Console.Write("Nome para alterar:");
                    nomeBusca = Console.ReadLine();
                    alterarBanda(listadeBandas, nomeBusca);

                    break;

                case 7:
                    Console.Write("Nome para excluir:");
                    nomeBusca = Console.ReadLine();
                    removerBanda(listadeBandas, nomeBusca);

                    break;


                case 0:
                    Console.WriteLine("Pressione Enter para continuar");
                    salvarDados(listadeBandas, "dados.txt");
                    break;
            }// fim switch
            Console.ReadKey();// pausa
            Console.Clear(); // limpa
        } while (op != 0);// fim while


        Console.ReadLine();//pause antes de fechar
    }

}// fim do programa
