using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aChorder.Models;
using aChorder.Services;
using aChorder.ViewModels;
using Rotativa.AspNetCore;

namespace aChorder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChordRepository _chordRepository;
        private readonly IChordDetectorService _chordDetectorService;

        public HomeController(IChordRepository chordRepository, IChordDetectorService chordDetectorService)
        {
            _chordRepository = chordRepository;
            _chordDetectorService = chordDetectorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            model.detectedChords = _chordDetectorService.ExtractTopChords(model.song.SongText);

            if (ModelState.IsValid)
            {
                return new ViewAsPdf("Convert", model);
            }
            else
            {
                return View();
            }
        }

    }
}