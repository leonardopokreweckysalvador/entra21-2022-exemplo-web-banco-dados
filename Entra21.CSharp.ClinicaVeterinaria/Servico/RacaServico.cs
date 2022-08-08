using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    //A classe RacaServico ira implementar a interface IracaService.
    // Ou seja, dovera honrar as clausulas definidos na interface(Contrato)
    public class RacaServico : IRacaServico
    {
        private RacaRepositorio racaRepositorio;

        public RacaServico()
        {
            racaRepositorio = new RacaRepositorio();
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
