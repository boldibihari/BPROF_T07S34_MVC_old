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
        IRepository<Club> clubRepo;
        IRepository<Player> playerRepo;
        IRepository<Manager> managerRepo;

        public PlayerLogic(IRepository<Club> clubRepo, IRepository<Player> playerRepo, IRepository<Manager> managerRepo)
        {
            this.clubRepo = clubRepo;
            this.playerRepo = playerRepo;
            this.managerRepo = managerRepo;
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
    }
}