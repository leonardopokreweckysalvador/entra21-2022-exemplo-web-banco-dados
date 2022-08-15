using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    //A classe RacaServico ira implementar a interface IracaService.
    // Ou seja, dovera honrar as clausulas definidos na interface(Contrato)
    public class RacaServico : IRacaServico
    {
        private RacaRepositorio _racaRepositorio;

        public RacaServico()
        {
        }

        //Construtor: construir o objeto de RacaServico com o minimo para a correta execucao
        public RacaServico(ClinicaVeterinariaContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }

        public void Cadastrar(string nome, string espece)
        {
            var raca = new Raca();
            raca.Nome = nome;
            raca.Especie = espece;
            _racaRepositorio.Cadastrar(raca);
            Console.WriteLine($"Nome: {nome} especie: {espece}");
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }

        public void Alterar(int id, string nome, string especie)
        {
            var raca = new Raca();
            raca.Id = id;
            raca.Nome = nome.Trim();
            raca.Especie = especie;

            _racaRepositorio.Apagar(id);
        }

        public void Apagar(int id)
        {
            _racaRepositorio.Apagar(id);
        }

        public Raca ObterPorId(int id)
        {
            var raca = _racaRepositorio.ObterPorId(id);

            return raca;
        }
    }
}

