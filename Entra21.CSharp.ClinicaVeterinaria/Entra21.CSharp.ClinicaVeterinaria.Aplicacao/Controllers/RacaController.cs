using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {
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
            return RedirectToAction("Index");
        }

    }
}
