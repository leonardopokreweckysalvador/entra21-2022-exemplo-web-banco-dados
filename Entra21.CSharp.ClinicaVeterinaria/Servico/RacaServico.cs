using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    //A classe RacaServico ira implementar a interface IracaService.
    // Ou seja, dovera honrar as clausulas definidos na interface(Contrato)
    public class RacaServico : IRacaServico
    {
        private readonly IRacaRepositorio _racaRepositorio;

        public RacaServico()
        {
        }

        //Construtor: construir o objeto de RacaServico com o minimo para a correta execucao
        public RacaServico(ClinicaVeterinariaContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }

        public void Cadastrar(RacaCadastrarViewModel racaCadastrarViewModel)
        {
            var raca = new Raca();
            raca.Nome = racaCadastrarViewModel.Nome;
            raca.Especie = racaCadastrarViewModel.Especie;
  
            _racaRepositorio.Cadastrar(raca);
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }

        public void Editar(RacaEditarViewModel racaEditarViewModel)
        {
            var raca = new Raca();
            raca.Id = racaEditarViewModel.Id;
            raca.Nome = racaEditarViewModel.Nome.Trim();
            raca.Especie = racaEditarViewModel.Especie;

            _racaRepositorio.Atualizar(raca) ;
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

