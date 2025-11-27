using Fiap.Agnello.Data;
using Fiap.Agnello.Migrations;
using Fiap.Agnello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Agnello.Controllers
{

    public class VinhoController : Controller
    {

        private readonly DatabaseContext _databasecontext;

        // Lista de tipos declarada no controller para uso nas Views
        private static readonly List<string> TiposVinho = new()
        {
            "Rosé",
            "Suave",
            "Seco",
            "Tinto",
            "Branco"
        };

        public VinhoController(DatabaseContext databaseContext)
        {
            _databasecontext = databaseContext;
        }
        public IActionResult Index()
        {
            var vinhos = _databasecontext.Vinhos.ToList();
            if (vinhos == null)
            {
                vinhos = new List<VinhoModel>();
            }

            return View(vinhos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Tipos = new SelectList(TiposVinho);
            return View();
        }

        [HttpPost]
        public IActionResult Create(VinhoModel vinhoModel)
        {
            _databasecontext.Vinhos.Add(vinhoModel);
            _databasecontext.SaveChanges();

            TempData["MensagemSucesso"] = $"Vinho {vinhoModel.Nome} cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vinhoConsultado =
                _databasecontext.Vinhos.Find(id);

            ViewBag.Tipos = new SelectList(TiposVinho, vinhoConsultado?.Tipo);

            return View(vinhoConsultado);
        }

        [HttpPost]
        public IActionResult Edit(VinhoModel vinhoModel)
        {
            _databasecontext.Vinhos.Update(vinhoModel);
            _databasecontext.SaveChanges();

            TempData["MensagemSucesso"] = $"Os dados do Vinho {vinhoModel.Nome} foi alterado com sucesso!";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vinho = _databasecontext.Vinhos.Find(id);
            if (vinho != null)
            {
                _databasecontext.Vinhos.Remove(vinho);
                _databasecontext.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do vinho {vinho.Nome} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "Vinho inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var vinho = _databasecontext.Vinhos
                            .FirstOrDefault(c => c.VinhoId == id); // Encontra o vinho pelo id
            if (vinho == null)
            {
                return NotFound(); // Retorna um erro 404 se o vinho não for encontrado
            }
            else
            {
                return View(vinho); // Retorna a view com os dados do vinho e seu representante
            }
        }

    }
}
