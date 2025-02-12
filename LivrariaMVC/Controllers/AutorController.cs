﻿using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LivrariaMVC.Helpers;

using Canducci.Pagination;

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
       
		public async Task<IActionResult> Index(int? current)
		{
			
            var autores = _autorRepository.Autores.ToPaginated(current ?? 1,8); // Carregue a lista de dados
			

			return View(autores);
		}

		public async Task<IActionResult> Create()
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



        //[HttpGet]

        //public async Task<IActionResult> Edit(int id)
        //{

        //}


        //[HttpPost]
        //public async Task<IActionResult> Edit([Bind("AutorName,AutorId")] Autor autor, IFormFile? imageFile)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(autor.AutorName))
        //        {
        //            var verificarAutor = await _autorRepository.GetByNameAsync(autor.AutorName);
        //            if (verificarAutor != null && verificarAutor.AutorId == autor.AutorId)
        //            {
        //                ModelState.AddModelError("", $"Nao foi possivel alterar o autor, nome ja existe");
        //                return View(autor);
        //            }
                   
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            var file = new FileInfo(autor.AutorImgUrl);
        //            if (file.Exists)
        //            {
        //                file.Delete();
        //            }
        //            //tratamento do arquivo
        //            autor.AutorImgUrl = await FileHelper.ProcessarImgUploadAsync(imageFile, UploadFolderPath) ?? DefaultImgPath;
        //            await _autorRepository.CreateAsync(autor);
        //            TempData["SucessMessage"] = "Autor criado";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", $"Nao foi possivel inserir o autor,verifique.");
        //            return View(autor);
        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ModelState.AddModelError("", $"Erro ao inserir autor {ex.Message}");
        //        return View(autor);
        //    }
        //}

    }
}
