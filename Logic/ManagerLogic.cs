using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ManagerLogic
    {
        IRepository<Club> clubRepo;
        IRepository<Player> playerRepo;
        IRepository<Manager> managerRepo;

        public ManagerLogic(IRepository<Club> clubRepo, IRepository<Player> playerRepo, IRepository<Manager> managerRepo)
        {
            this.clubRepo = clubRepo;
            this.playerRepo = playerRepo;
            this.managerRepo = managerRepo;
        }

        public void AddManager(Manager item)
        {
            this.managerRepo.Add(item);
        }
        public void DeleteManager(string id)
        {
            this.managerRepo.Delete(id);
        }
        public IQueryable<Manager> GetAllManager()
        {
            return managerRepo.Read();
        }
        public Manager GetManager(string id)
        {
            return managerRepo.Read(id);
        }
        public void UpdateManager(string oldid, Manager newitem)
        {
            this.managerRepo.Update(oldid, newitem);
        }
    }
}