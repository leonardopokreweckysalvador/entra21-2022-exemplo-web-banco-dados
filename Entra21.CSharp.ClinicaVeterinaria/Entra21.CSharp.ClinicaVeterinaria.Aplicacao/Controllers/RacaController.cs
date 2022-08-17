using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enum;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {

        private readonly RacaServico _racaService;


        // Contrutor: objetivo contruir o objeto de RacaController,
        //com o minimo necessario para o funcionamenro correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaService = new RacaServico(contexto);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("/raca")]
        [HttpGet]
        /// Endpoist que  permite listar todas as raças
        /// <returns> Retorna a página hyml com as raças </returns>>
        public IActionResult ObterTodos()
        {
            var racas = _racaService.ObterTodos();

            ViewBag.Racas = racas;

            // Passar informacao do c# para o HTML
            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();
            ViewBag.Especies = especies;
            
            return View();
        }

        [Route("/raca/registrar")]
        [HttpGet]

        public IActionResult Registrar(
            [FromQuery]string nome,
            [FromQuery] string especie)
        {
            _racaService.Cadastrar(nome, especie);
            
            return RedirectToAction("Index");
        }

        [Route("/raca/apagar")]
        [HttpGet]

        public IActionResult Apagar([FromQuery] int id)
        {
            _racaService.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/raca/editar")]

        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaService.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especie = especies;

            return View("Editar");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>().OrderBy(x => x).ToList();
        }

        public IActionResult Alterar(
            [FromQuery] int id, 
            [FromQuery] string nome, 
            [FromQuery] string especie)
        {
            _racaService.Alterar(id, nome, especie);
            
            return RedirectToAction("Index");
        }
    }
}
