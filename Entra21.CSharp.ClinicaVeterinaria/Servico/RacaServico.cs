using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    //A classe RacaServico ira implementar a interface IracaService.
    // Ou seja, dovera honrar as clausulas definidos na interface(Contrato)
    public class RacaServico : IRacaServico
    {
        private RacaRepositorio racaRepositorio;

        //Construtor: construir o objeto de RacaServico com o minimo para a correta execucao
        public RacaServico(ClinicaVeterinariaContexto contexto)
        {
            racaRepositorio = new RacaRepositorio(contexto);
        }
        public void Cadastrar(string nome, string espece)
        {
            var raca = new Raca();
            raca.Nome = nome;
            raca.Especie = espece;
            racaRepositorio.Cadastrar(raca);
            Console.WriteLine($"Nome: {nome} especie: {espece}");
        }
    }
}
