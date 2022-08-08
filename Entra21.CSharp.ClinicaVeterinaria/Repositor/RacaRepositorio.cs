using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio
{
    public class RacaRepositorio : IRacaRepositorio
    {
        public void Cadastrar(Raca raca)
        {
            Console.WriteLine($"Nome: {raca.Nome} especie: {raca.Especie}");
        }
    }
}
