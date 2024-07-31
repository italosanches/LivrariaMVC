using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LivrariaMVC.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LivrariaMVC.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autorRepository;
        private const string DefaultImgPath = "/images/default_img.svg";
        private const string UploadFolderPath = "wwwroot/Uploads";

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
        public async Task<IActionResult> Create([Bind("AutorName")] Autor autor, IFormFile? imageFile)
        {
            try
            {
                //Verifica se autor esta vazio
                if (!string.IsNullOrWhiteSpace(autor.AutorName))
                {   //verifica se existe algum autor pelo nome                                         
                    var verificarAutor = await _autorRepository.GetByNameAsync(autor.AutorName);
                    if (verificarAutor != null)
                    {
                        ModelState.AddModelError("", $"Nao foi possivel inserir o autor, nome ja existe");
                        return View(autor);
                    }
                }

                if (ModelState.IsValid)
                {                              //tratamento do arquivo
                    var pathResult = await FileHelper.ProcessarImgUploadAsync(imageFile, UploadFolderPath) ?? DefaultImgPath;
                    if (pathResult != "invalido")
                    {
                        autor.AutorImgUrl = pathResult;
                        await _autorRepository.CreateAsync(autor);
                        TempData["SucessMessage"] = "Autor criado";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Arquivo de imagem com formato invalido.");
                        return View(autor);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Nao foi possivel inserir o autor,verifique.");
                    return View(autor);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Erro ao inserir autor {ex.Message}");
                return View(autor);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("AutorName")] Autor autor, IFormFile? imageFile)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(autor.AutorName))
                {
                    var verificarAutor = await _autorRepository.GetByNameAsync(autor.AutorName);
                    if (verificarAutor != null && verificarAutor.AutorId == autor.AutorId)
                    {
                        ModelState.AddModelError("", $"Nao foi possivel inserir o autor, nome ja existe");
                        return View(autor);
                    }
                }

                if (ModelState.IsValid)
                {                              //tratamento do arquivo
                    autor.AutorImgUrl = await FileHelper.ProcessarImgUploadAsync(imageFile, UploadFolderPath) ?? DefaultImgPath;
                    await _autorRepository.CreateAsync(autor);
                    TempData["SucessMessage"] = "Autor criado";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", $"Nao foi possivel inserir o autor,verifique.");
                    return View(autor);
                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Erro ao inserir autor {ex.Message}");
                return View(autor);
            }
        }

    }
}
