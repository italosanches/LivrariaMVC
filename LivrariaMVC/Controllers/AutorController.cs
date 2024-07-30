using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var listAutores = _autorRepository.Autores.ToList();
            return View(listAutores);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("AutorName")] Autor autor, IFormFile? ImageFile)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    string? imageUrl = null;
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var filePath = Path.Combine("wwwroot/Uploads", Path.GetFileName(ImageFile.FileName));
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }
                        imageUrl = "/uploads/" + Path.GetFileName(ImageFile.FileName);
                        autor.AutorImgUrl = imageUrl;
                    }
                    else
                    {
						autor.AutorImgUrl = Path.Combine("/images/default_img.svg");
					}
                    
                    TempData["SucessMessage"] = "Autor criado";
                    await _autorRepository.CreateAsync(autor);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", $"Erro ao inserir autor {ex.Message}");
                }
               

            }
           
            return RedirectToAction("Index");           
        }
    }
}
