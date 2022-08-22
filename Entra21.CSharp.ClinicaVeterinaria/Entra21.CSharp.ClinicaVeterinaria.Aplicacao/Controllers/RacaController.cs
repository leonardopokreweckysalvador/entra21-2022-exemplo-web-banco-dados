using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enum;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {

        private readonly IRacaServico _racaService;


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
        //[Route("/raca")]
        [HttpGet("/raca")]
        /// Endpoist que  permite listar todas as raças
        /// <returns> Retorna a página hyml com as raças </returns>>
        public IActionResult ObterTodos()
        {
            var racas = _racaService.ObterTodos();

            // Passar informacao do c# para o HTML
            return View("Index", racas);
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>().OrderBy(x => x).ToList();
        }

        //[Route("/raca/cadastrar")]
        [HttpGet("/raca/cadastrar")]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();
            ViewBag.Especies = especies;

            var racaCadastrarViewModel = new RacaCadastrarViewModel();

            return View(racaCadastrarViewModel);
        }

        //[Route("/raca/cadastrar")]
        [HttpPost("/raca/cadastrar")]

        // TODO ModelState
        public IActionResult Cadastrar(
            [FromForm]RacaCadastrarViewModel racaCadastrarViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();

                return View(racaCadastrarViewModel);
            }
            
            _racaService.Cadastrar(racaCadastrarViewModel);

            return RedirectToAction("Index");
        }

        //[Route("/raca/apagar")]
        [HttpGet("/raca/apagar")]

        public IActionResult Apagar([FromQuery] int id)
        {
            _racaService.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/editar")]
        //[Route("/raca/editar")]

        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaService.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especie = especies;

            return View("Editar");
        }

        [HttpPost("/raca/editar")]
        //[Route("/raca/editar")]
        public IActionResult Editar(
            [FromForm] RacaEditarViewModel racaEditarViewModel)
        {
            _racaService.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }

    }
}
