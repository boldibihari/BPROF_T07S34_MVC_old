using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
     public class ClubRepository : IRepository<Club>
    {
        NB1Context context = new NB1Context();

        public void Add(Club item)
        {
            context.Clubs.Add(item);
            context.SaveChanges();
        }

        public void Delete(Club item)
        {
            context.Clubs.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            Delete(Read(id));
        }

        public Club Read(string id)
        {
            return context.Clubs.FirstOrDefault(x => x.ClubID == id);
        }

        public IQueryable<Club> Read()
        {
            return context.Clubs.AsQueryable();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldid, Club newitem)
        {
            var olditem = Read(oldid);
            olditem.ClubName = newitem.ClubName;
            olditem.ClubColour = newitem.ClubColour;
            olditem.ClubCity = newitem.ClubCity;
            olditem.Stadium = newitem.Stadium;
            olditem.Players = newitem.Players;
            olditem.Manager = newitem.Manager;
            context.SaveChanges();
        }
    }
}
