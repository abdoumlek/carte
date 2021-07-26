using carte.Services;
using MapStates.TreasureMapDomain;
using MapStates.GameManagerDomain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace carte.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MapStatesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHost = null;
        private readonly IFileHandler _fileHandler = null;
        public MapStatesController(IWebHostEnvironment webHostEnvironement)
        {
            _webHost = webHostEnvironement;
            _fileHandler = new FileHandler(webHostEnvironement);
        }
        #region public methods
        /// <summary>
        /// méthode qui acccepte un fichier contenant la carte retourne un fichier contenant le résultat 
        /// </summary>
        /// <returns>un fichier symbolisant le résultat</returns>
        [HttpPost]
        public async Task<IActionResult> RunGameSimulation(IFormFile file)
        {
            //on peut ajouter les nom de dossier dans la config
            //on peut ajouter les symbol C T M A G D dans la config aussi
            string mapsPath = Path.Combine(_webHost.ContentRootPath, "UploadFolder");
            string resultPath = Path.Combine(_webHost.ContentRootPath, "DownloadFolder");
            //l'enregistrement n'est pas nécessaire on peut directement accéder au données
            var lines = await _fileHandler.SaveFile(file, mapsPath);
            //si on veut une lecture du disque directement
            //var lines = _fileHandler.ReadFile(Path.Combine(mapsPath,"map.txt"));
            var gameManager = new GameManager();
            var resultLines = gameManager.RunGame(lines);
            await _fileHandler.WriteToFile(resultLines, resultPath, "map.txt");
            return File(System.IO.File.ReadAllBytes(Path.Combine(resultPath,"map.txt")), MediaTypeNames.Text.Plain, "map.txt") ;
        }

        [Route("map_states")]
        [HttpPost]
        public async Task<IActionResult> GetMapSteps(IFormFile file)
        {
            string mapsPath = Path.Combine(_webHost.ContentRootPath, "UploadFolder");
            //l'enregistrement n'est pas nécessaire on peut directement accéder au données
            var lines = await _fileHandler.SaveFile(file, mapsPath);
            //si on veut une lecture du disque directement
            //var lines = _fileHandler.ReadFile(Path.Combine(mapsPath,"map.txt"));
            var gameManager = new GameManager();
            var history = gameManager.RunStepByStep(lines);

            var tiles = history.History.Select(mapstate => mapstate.Tiles.Select(kvp=> kvp.Value)).ToList();
            var tilePositions = history.History.Select(mapstate => mapstate.Tiles.Select(kvp => kvp.Key)).ToList();
            var adventurers = history.History.Select(mapstate => mapstate.Adventurers);
            var response = new
            {
                tiles,
                adventurers,
                tilePositions

            };
            return Ok(response);
        }

        #endregion
    }
}
