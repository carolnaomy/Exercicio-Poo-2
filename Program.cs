namespace ExercicioPoo2
{
    internal class Program
    {
        static List<Pessoa> hospedes = new();
        static List<Suite> suites = new();
        static List<Reserva> reservas = new();
        static void Main()
        {

            bool sair = false;

            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Cadastro");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Sair");
                Console.WriteLine("Escolha uma opção");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Cadastro();
                        break;
                    case "2":
                        Consultar();
                        break;
                    case "3":
                        Listar();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            }
            while (!sair);

        }


        static void Cadastro()
        {
            Console.WriteLine("MENU - CADASTRO");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suite");
            Console.WriteLine("3. Reserva");
            Console.WriteLine("Escolha uma opção");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarHospede();
                    break;
                case "2":
                    CadastrarSuite();
                    break;
                case "3":
                    CadastrarReserva();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        static void Consultar()
        {
            Console.WriteLine("MENU - CONSULTA");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suite");
            Console.WriteLine("3. Reserva");
            Console.WriteLine("Escolha uma opção");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ConsultarHospede();
                    break;
                case "2":
                    ConsultarSuite();
                    break;
                case "3":
                    ConsultarReserva();
                    break;
                default:
                    Console.WriteLine("Opção Inválida. Tente novamente");
                    break;
            }
        }

        static void Listar()
        {
            Console.WriteLine("MENU - LISTAR");
            Console.WriteLine("1. Hospedes");
            Console.WriteLine("2. Suites");
            Console.WriteLine("3. Reservas");
            Console.WriteLine("Escolha uma opção:");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarHospedes();
                    break;
                case "2":
                    ListarSuites();
                    break;
                case "3":
                    ListarReservas();
                    break;
                default:
                    Console.WriteLine("Opção inválida . Tente novamente.");
                    break;
            }
        }

        static void CadastrarHospede()
        {
            Console.WriteLine("CADASTRO DE HOSPEDE");
            Pessoa hospede = new Pessoa();

            Console.Write("Nome: ");
            hospede.Nome = Console.ReadLine();

            Console.Write("Idade: ");
            hospede.Idade = int.Parse(Console.ReadLine());

            Console.Write("Gênero: ");
            hospede.Genero = Console.ReadLine();

            Console.Write("Profissão: ");
            hospede.Profissao = Console.ReadLine();

            hospedes.Add(hospede);
            Console.WriteLine("Hospede cadastrado com sucesso!");
        }

        static void CadastrarSuite()
        {
            Console.WriteLine("CADASTRO DE SUITE");
            Suite suite = new Suite();

            Console.Write("Capacidade: ");
            suite.Capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor da Diária: ");
            suite.ValorDiaria = decimal.Parse(Console.ReadLine());

            suites.Add(suite);
            Console.WriteLine("Suite cadastrada com sucesso!");

        }

        static void CadastrarReserva()
        {
            Console.WriteLine("CADASTRO DE RESERVA");
            Reserva reserva = new Reserva();

            Console.WriteLine("Hospedes disponíveis:");
            for (int i = 0; i < hospedes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hospedes[i].Nome}");
            }

            Console.Write("Escolha o hospede pelo número: ");
            int indiceHospede = int.Parse(Console.ReadLine()) - 1;
            reserva.Hospede = hospedes[indiceHospede];

            Console.WriteLine("Suites disponíveis:");
            for (int i = 0; i < suites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Capacidade: {suites[i].Capacidade}, Diária: {suites[i].ValorDiaria}");
            }

            Console.Write("Escolha a suíte pelo número: ");
            int indiceSuite = int.Parse(Console.ReadLine()) - 1;
            reserva.Suite = suites[indiceSuite];

            Console.Write("Data Inicio da Reserva (DD/MM/AAAA): ");
            reserva.DataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Data Fim da Reserva (DD/MM/AAAA): ");
            reserva.DataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            reservas.Add(reserva);
            Console.WriteLine("Reserva cadastrada com sucesso!");

        }

        static void ConsultarHospede()
        {
            Console.WriteLine("CONSULTA DE HOSPEDE");
            Console.Write("Digite o nome do hospede: ");
            string nome = Console.ReadLine();

            Pessoa hospede = hospedes.Find(h => h.Nome == nome);
            if (hospede != null)
            {
                Console.WriteLine($"Nome: {hospede.Nome}, Idade: {hospede.Idade}, Gênero: {hospede.Genero}, Profissão: {hospede.Profissao}");
            }
            else
            {
                Console.WriteLine("Hospede não encontrado.");
            }





        }

        static void ConsultarSuite()
        {
            Console.WriteLine("CONSULTA DE SUITE");
            Console.Write("Digite a capacidade da suite: ");
            int capacidade = int.Parse(Console.ReadLine());

            Suite suite = suites.Find(s => s.Capacidade == capacidade);
            if (suite != null)
            {
                Console.WriteLine($"Capacidade: {suite.Capacidade}, Diária: {suite.ValorDiaria}");
            }
            else
            {
                Console.WriteLine("Suite não encontrada.");
            }
        }
        static void ConsultarReserva()
        {
            Console.WriteLine("CONSULTA DE RESERVA");
            Console.Write("Digite o nome do hospede: ");
            string nome = Console.ReadLine();

            Reserva reserva = reservas.Find(r => r.Hospede.Nome == nome);
            if (reserva != null)
            {
                Console.WriteLine($"Hospede: {reserva.Hospede.Nome}, Suíte: Capacidade {reserva.Suite.Capacidade}, Diária: {reserva.Suite.ValorDiaria}, Data Início: {reserva.DataInicio}, Data Fim: {reserva.DataFim}, Valor Total: {reserva.CalcularValorTotal()}");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }
        }
        static void ListarHospedes()
        {
            Console.WriteLine("LISTA DE HOSPEDES");
            foreach (var hospede in hospedes)
            {
                Console.WriteLine($"Nome: {hospede.Nome}, Idade: {hospede.Idade}, Gênero: {hospede.Genero}, Profissão: {hospede.Profissao}");
            }
        }
        static void ListarSuites()
        {
            Console.WriteLine("LISTA DE SUITES");
            foreach (var suite in suites)
            {
                Console.WriteLine($"Capacidade: {suite.Capacidade}, Diária: {suite.ValorDiaria}");
            }
        }
        static void ListarReservas()
        {
            Console.WriteLine("LISTA DE RESERVAS");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"Hospede: {reserva.Hospede.Nome}, Suíte: Capacidade {reserva.Suite.Capacidade}, Diária: {reserva.Suite.ValorDiaria}, Data Início: {reserva.DataInicio}, Data Fim: {reserva.DataFim}, Valor Total: {reserva.CalcularValorTotal()}");
            }
        }








    }

}

