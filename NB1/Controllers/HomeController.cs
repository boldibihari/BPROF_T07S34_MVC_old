using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
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
            return View(clubLogic.GetAllClub().OrderBy(x => x.ClubName));
        }
        public IActionResult Players()
        {
            return View(playerLogic.GetAllPlayer().OrderBy(x => x.PlayerName));
        }
        public IActionResult Managers()
        {
            return View(managerLogic.GetAllManager().OrderBy(x => x.ManagerName));
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
        [HttpGet]
        public IActionResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClub(Club club)
        {
            club.ClubID = Guid.NewGuid().ToString();
            clubLogic.AddClub(club);
            return RedirectToAction(nameof(Clubs));
        }
        [HttpGet]
        public IActionResult AddPlayer(string clubid)
        {
            return View(nameof(AddPlayer), clubid);
        }
        [HttpPost]
        public IActionResult AddPlayer(Player player, string clubid)
        {
            player.PlayerID = Guid.NewGuid().ToString();
            clubLogic.AddPlayerToClub(player, clubid);
            return RedirectToAction(nameof(AllPlayerFromClub), new { clubid = clubid });
        }
        [HttpGet]
        public IActionResult AddManager(string clubid)
        {
            return View(nameof(AddManager), clubid);
        }
        [HttpPost]
        public IActionResult AddManager(Manager manager, string clubid)
        {
            manager.ManagerID = Guid.NewGuid().ToString();
            clubLogic.AddManagerToClub(manager, clubid);
            return RedirectToAction(nameof(Club), new { clubid = clubid });
        }
        public IActionResult DeleteClub(string clubid)
        {
            var players = clubLogic.GetClub(clubid).Players.ToArray();
            for (int i = 0; i < players.Length; i++)
            {
                var player = players[i];
                clubLogic.DeletePlayerFromClub(player, clubid);
                playerLogic.DeletePlayer(player.PlayerID);
            }
            var manager = clubLogic.GetClub(clubid).Manager;
            clubLogic.DeleteManagerFromClub(manager, clubid);
            managerLogic.DeleteManager(manager.ManagerID);
            clubLogic.DeleteClub(clubid);
            return RedirectToAction(nameof(Clubs));
        }
        public IActionResult DeletePlayer(string playerid)
        {
            var playerdelete = playerLogic.GetPlayer(playerid);
            string clubid = playerdelete.ClubID;
            clubLogic.DeletePlayerFromClub(playerdelete, clubid);
            playerLogic.DeletePlayer(playerid);
            return RedirectToAction(nameof(AllPlayerFromClub), new { clubid = clubid });
        }
        public IActionResult DeleteManager(string managerid)
        {
            var managerdelete = managerLogic.GetManager(managerid);
            string clubid = managerdelete.ClubID;
            clubLogic.DeleteManagerFromClub(managerdelete, clubid);
            managerLogic.DeleteManager(managerid);
            return RedirectToAction(nameof(Club), new { clubid = clubid });
        }
        [HttpGet]
        public IActionResult UpdateClub(string clubid)
        {
            return View(clubLogic.GetClub(clubid));
        }
        [HttpPost]
        public IActionResult UpdateClub(string oldid, Club club)
        {
            clubLogic.UpdateClub(oldid, club);
            return RedirectToAction(nameof(Club), new { clubid = oldid });
        }
        [HttpGet]
        public IActionResult UpdatePlayer(string playerid)
        {
            return View(playerLogic.GetPlayer(playerid));
        }
        [HttpPost]
        public IActionResult UpdatePlayer(Player player)
        {
            playerLogic.UpdatePlayer(player.PlayerID, player);
            return RedirectToAction(nameof(AllPlayerFromClub), new { clubid = player.ClubID });
        }
        [HttpGet]
        public IActionResult UpdateManager(string managerid)
        {
            return View(managerLogic.GetManager(managerid));
        }
        [HttpPost]
        public IActionResult UpdateManager(Manager manager)
        {
            managerLogic.UpdateManager(manager.ManagerID, manager);
            return RedirectToAction(nameof(Manager), new { managerid = manager.ManagerID });
        }
    }
}