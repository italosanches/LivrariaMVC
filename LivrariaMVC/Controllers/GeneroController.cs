using LivrariaMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaMVC.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroRepository _generoRepository;

		public GeneroController(IGeneroRepository generoRepository)
		{
			_generoRepository = generoRepository;
		}

		public IActionResult Index()
        {
            return View(_generoRepository.Generos);
        }
    }
}
