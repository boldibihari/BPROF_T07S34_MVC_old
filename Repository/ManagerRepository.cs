using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ManagerRepository : IRepository<Manager>
    {
        NB1Context context = new NB1Context();

        public void Add(Manager item)
        {
            context.Managers.Add(item);
            context.SaveChanges();
        }

        public void Delete(Manager item)
        {
            context.Managers.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            Delete(Read(id));
        }

        public Manager Read(string id)
        {
            return context.Managers.FirstOrDefault(x => x.ManagerID == id);
        }

        public IQueryable<Manager> Read()
        {
            return context.Managers.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldid, Manager newitem)
        {
            var olditem = Read(oldid);
            olditem.ManagerName = newitem.ManagerName;
            olditem.ManagerNationality = newitem.ManagerNationality;
            olditem.ManagerBirthDate = newitem.ManagerBirthDate;
            olditem.ManagerStartYear = newitem.ManagerStartYear;
            context.SaveChanges();
        }
    }
}