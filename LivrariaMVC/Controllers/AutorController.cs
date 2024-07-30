using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaMVC.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autorRepository;
        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("AutorName")] Autor autor, IFormFile ImageFile)
        {
           if(ModelState.IsValid)
            {
                string? imageUrl = null;
                if (ImageFile != null && ImageFile.Length > 0) 
                { 
                    var filePath = Path.Combine("wwwroot/Uploads",Path.GetFileName(ImageFile.FileName));
                    using(var stream = new FileStream(filePath,FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                    imageUrl = "/uploads/"+  Path.GetFileName(ImageFile.FileName);
                    autor.AutorImgUrl = imageUrl;
                }
                await _autorRepository.CreateAsync(autor);

            }
           
            return View();           
        }
    }
}
