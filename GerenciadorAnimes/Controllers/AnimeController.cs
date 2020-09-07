using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GerenciadorAnimes.ExtensionMethods;

namespace GerenciadorAnimes.Controllers
{
    public class AnimeController : Controller
    {
        public ActionResult Index()
        {
            var animes = new List<Model.Animes>();

            try
            {
                animes = new Business.AnimesBUS().ListarAnimes();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View(animes);
        }

        public ActionResult ModalAdicionarAnime()
        {
            try
            {
                return PartialView();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalAdicionarAnime(FormCollection form)
        {
            Model.Animes anime = new Model.Animes();

            try
            {
                anime.Nome = form["nome"];
                anime.Genero = form["genero"];
                anime.Visualizado = (form["visualizado"] == "on" ? 1 : 0).ToBoolean();
                anime.Recomendavel = (form["recomendavel"] == "on" ? 1 : 0).ToBoolean();
                anime.Nota = form["nota"].ToInt();

                new GerenciadorAnimes.Business.AnimesBUS().InserirAnime(anime);

                return Json(new { success = true, sucesso = "Anime inserido com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, erro = ex.Message });
            }            
        }

        public ActionResult ModalEditarAnime(int id)
        {
            try
            {
                var carregaAnime = new Business.AnimesBUS().CarregarAnime(id);

                return PartialView(carregaAnime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalEditarAnime(FormCollection form)
        {
            Model.Animes anime = new Model.Animes();

            try
            {
                var teste = form["visualizado"].Split(',')[0];
                var teste1 = form["recomendavel"].Split(',')[0];

                anime.ID = form["ID"];
                anime.Nome = form["nome"];
                anime.Genero = form["genero"];
                anime.Visualizado = (form["visualizado"].Split(',')[0] == "true");
                anime.Recomendavel = (form["recomendavel"].Split(',')[0] == "true");
                anime.Nota = form["nota"].ToInt();

                new GerenciadorAnimes.Business.AnimesBUS().AtualizarAnime(anime);

                return Json(new { success = true, sucesso = "Anime atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, erro = ex.Message });
            }
        }
    }
}