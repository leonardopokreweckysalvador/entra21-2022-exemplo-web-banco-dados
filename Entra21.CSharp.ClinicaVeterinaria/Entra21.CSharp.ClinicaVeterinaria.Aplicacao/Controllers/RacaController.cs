using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {

        private readonly RacaServico _RacaService;
        
        // Contrutor: objetivo contruir o objeto de RacaController,
        //com o minimo necessario para o funcionamenro correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _RacaService = new RacaServico(contexto);

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
            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("/raca/registrar")]
        [HttpGet]

        public IActionResult Registrar(
            [FromQuery]string nome,
            [FromQuery] string especie)
        {
            _RacaService.Cadastrar(nome, especie);
            
            return RedirectToAction("Index");
        }

    }
}
