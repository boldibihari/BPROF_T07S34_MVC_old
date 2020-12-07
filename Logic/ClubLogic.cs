using Models;
using Repository;
using System;
using System.Linq;

namespace Logic
{
    public class ClubLogic
    {
        IRepository<Club> clubRepo;
        IRepository<Player> playerRepo;
        IRepository<Manager> managerRepo;

        public ClubLogic(IRepository<Club> clubRepo, IRepository<Player> playerRepo, IRepository<Manager> managerRepo)
        {
            this.clubRepo = clubRepo;
            this.playerRepo = playerRepo;
            this.managerRepo = managerRepo;
        }

        public void AddClub(Club item)
        {
            this.clubRepo.Add(item);
        }
        public void DeleteClub(string id)
        {
            this.clubRepo.Delete(id);
        }
        public IQueryable<Club> GetAllClub()
        {
            return clubRepo.Read();
        }
        public Club GetClub(string id)
        {
            return clubRepo.Read(id);
        }
        public void UpdateClub(string oldid, Club newitem)
        {
            this.clubRepo.Update(oldid, newitem);
        }
        public void AddPlayerToClub(Player player, string clubid)
        {
            GetClub(clubid).Players.Add(player);
            clubRepo.Save();
        }
        public void DeletePlayerFromClub(Player player, string clubid)
        {
            GetClub(clubid).Players.Remove(player);
            clubRepo.Save();
        }
        public void AddManagerToClub(Manager manager, string clubid)
        {
            GetClub(clubid).Manager = manager;
            clubRepo.Save();
        }
        public void DeleteManagerFromClub(Manager manager, string clubid)
        {
            GetClub(clubid).Manager = null;
            clubRepo.Save();
        }
    }
}