using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        NB1Context context = new NB1Context();

        public void Add(Player item)
        {
            context.Players.Add(item);
            context.SaveChanges();
        }

        public void Delete(Player item)
        {
            context.Players.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            Delete(Read(id));
        }

        public Player Read(string id)
        {
            return context.Players.FirstOrDefault(x => x.PlayerID == id);
        }

        public IQueryable<Player> Read()
        {
            return context.Players.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldid, Player newitem)
        {
            var olditem = Read(oldid);
            olditem.PlayerName = newitem.PlayerName;
            olditem.PlayerNationality = newitem.PlayerNationality;
            olditem.PlayerBirthDate = newitem.PlayerBirthDate;
            olditem.PlayerPosition = newitem.PlayerPosition;
            olditem.PlayerValue = newitem.PlayerValue;
            context.SaveChanges();
        }
    }
}