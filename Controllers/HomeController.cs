using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Curso_ASP_Rotas.Models;

namespace Curso_ASP_Rotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }
    
        public IActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3); 
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList(); 

            ViewBag.Categorias = todasAsCategorias;

            return View(ultimasNoticias);
        }

        public IActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias); 
        }

        public IActionResult MostrarNoticia(int noticiaId, string titulo, string Categoria)
        {
            return View(todasAsNoticias.FirstOrDefault(x=> x.NoticiaId == noticiaId)); 
        }

        public IActionResult MostraCategoria(string categoria)
        {
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria; 
            return View(categoriaEspecifica);
        }
       
    }
}
