using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class PlayerLogic
    {
        //IRepository<Club> clubRepo;
        IRepository<Player> playerRepo;
        //IRepository<Manager> managerRepo;

        public PlayerLogic(/*IRepository<Club> clubRepo,*/ IRepository<Player> playerRepo/*, IRepository<Manager> managerRepo*/)
        {
            //this.clubRepo = clubRepo;
            this.playerRepo = playerRepo;
            //this.managerRepo = managerRepo;
        }

        public void AddPlayer(Player item)
        {
            this.playerRepo.Add(item);
        }
        public void DeletePlayer(string id)
        {
            this.playerRepo.Delete(id);
        }
        public IQueryable<Player> GetAllPlayer()
        {
            return playerRepo.Read();
        }
        public Player GetPlayer(string id)
        {
            return playerRepo.Read(id);
        }
        public void UpdatePlayer(string oldid, Player newitem)
        {
            this.playerRepo.Update(oldid, newitem);
        }
        public IQueryable<Player> AllPlayerFromClub(string clubid)
        {
            return GetAllPlayer().Where(x => x.ClubID == clubid);
        }
        public double ClubsValue()
        {
            return Math.Round(GetAllPlayer().Sum(x => x.PlayerValue), 2);
        }
        public int AverageAge()
        {
            return (int)GetAllPlayer().Average(x => DateTime.Now.Year - x.PlayerBirthDate.Year);
        }
        public double AveragePlayerValue()
        {
            return Math.Round(GetAllPlayer().Average(x => x.PlayerValue), 2);
        }
        public double AverageClubValue()
        {
            var players = GetAllPlayer();
            var q = (from x in players
                     group x by x.Club.ClubID into g
                     select new
                     {
                         ClubID = g.Key,
                         Value = g.Sum(x => x.PlayerValue)
                     }).Average(x => x.Value);
            return Math.Round(q, 2);
        }
        public List<string> Nationality()
        {
            List<string> nationalities = new List<string>();
            var players = GetAllPlayer();
            var q = from x in players
                    group x by x.PlayerNationality into g
                    select new
                    {
                        Nationality = g.Key,
                        Count = g.Count()
                    };
            foreach (var item in q)
            {
                nationalities.Add($"{item.Nationality}: {item.Count.ToString()}");
            }
            return nationalities;
        }
        public List<string> Position()
        {
            List<string> positions = new List<string>();
            var players = GetAllPlayer();
            var q = (from x in players
                     group x by x.PlayerPosition into g
                     select new
                     {
                         Position = g.Key,
                         Count = g.Count()
                     }).OrderBy(x => x.Position);
            foreach (var item in q)
            {
                positions.Add($"{item.Position}: {item.Count.ToString()}");
            }
            return positions;
        }
    }
}