using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NB1.Controllers
{
    public class HomeController : Controller
    {
        ClubLogic clubLogic;
        PlayerLogic playerLogic;
        ManagerLogic managerLogic;

        public HomeController(ClubLogic clubLogic, PlayerLogic playerLogic, ManagerLogic managerLogic)
        {
            this.clubLogic = clubLogic;
            this.playerLogic = playerLogic;
            this.managerLogic = managerLogic;
        }

        public IActionResult Init()
        {
            clubLogic.FillDbWithSamples();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Clubs()
        {
            return View(clubLogic.GetAllClub());
        }
        public IActionResult Players()
        {
            return View(playerLogic.GetAllPlayer());
        }
        public IActionResult Managers()
        {
            return View(managerLogic.GetAllManager());
        }
        public IActionResult Club(string clubid)
        {
            return View(clubLogic.GetClub(clubid));
        }
        public IActionResult Player(string playerid)
        {
            return View(playerLogic.GetPlayer(playerid));
        }
        public IActionResult Manager(string managerid)
        {
            return View(managerLogic.GetManager(managerid));
        }
        public IActionResult AllPlayerFromClub(string clubid)
        {
            return View(playerLogic.AllPlayerFromClub(clubid).OrderBy(x => x.PlayerPosition));
        }
    }
}