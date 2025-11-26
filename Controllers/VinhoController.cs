using Fiap.Agnello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Agnello.Controllers
{

    public class VinhoController : Controller
    {
        // Lista para armazenar os vinhos
        public IList<VinhoModel> vinhos { get; set; }

        // Lista de tipos declarada no controller para uso nas Views
        private static readonly List<string> TiposVinho = new()
        {
            "Rosé",
            "Suave",
            "Seco",
            "Tinto",
            "Branco"
        };

        public VinhoController()
        {
            // Simula a busca de vinhos no banco de dados
            vinhos = GerarVinhosMocados();
        }
        public IActionResult Index()
        {
            // Evitando valores null 
            if (vinhos == null)
            {
                vinhos = new List<VinhoModel>();
            }
            return View(vinhos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vinhoConsultado =
                vinhos.Where(v => v.VinhoId == id).FirstOrDefault();

            // garante que a lista aparece na view e marca o tipo atual como selecionado
            ViewBag.Tipos = new SelectList(TiposVinho, vinhoConsultado?.Tipo);

            return View(vinhoConsultado);
        }

        [HttpPost]
        public IActionResult Edit(VinhoModel vinhoModel)
        {
            // Simula a edição do vinho (em um banco de dados, por exemplo)
            TempData["MensagemSucesso"] = $"Os dados do Vinho {vinhoModel.Nome} foram alterados com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            // disponibiliza a lista para a View (asp-items aceita SelectList/IEnumerable<SelectListItem>)
            ViewBag.Tipos = new SelectList(TiposVinho);
            return View();
        }

        [HttpPost]
        public IActionResult Create(VinhoModel vinhoModel)
        {
            // exemplo de validação: se inválido, reexibe a view e precisa repopular a lista
            if (!ModelState.IsValid)
            {
                ViewBag.Tipos = new SelectList(TiposVinho);
                return View(vinhoModel);
            }
            // Simula o cadastro do vinho (em um banco de dados, por exemplo)
            TempData["MensagemSucesso"] = "Vinho cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        /**
         * Este método estático GerarVinhosMocados 
         * cria uma lista de 5 vinhos com dados fictícios
         */
        public static List<VinhoModel> GerarVinhosMocados()
        {
            var vinhos = new List<VinhoModel>();
            for (int i = 1; i <= 5; i++)
            {
                var vinho = new VinhoModel
                {
                    VinhoId = i,
                    Nome = "NomeVinho" + i,
                    Tipo = TiposVinho[(i - 1) % TiposVinho.Count],
                    Preco = 10.0 + i
                };
                vinhos.Add(vinho);
            }
            return vinhos;
        }
    }
}
