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
        # region FillDbWithSamples
        public void FillDbWithSamples()
        {
            Club c1 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Ferencvárosi TC",
                ClubCity = "Budapest",
                ClubColour = "green-white",
                ClubFounded = 1899,
                Stadium = "Groupama Aréna"
            };
            Club c2 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "MOL Fehérvár",
                ClubCity = "Székesfehérvár",
                ClubColour = "red-blue",
                ClubFounded = 1914,
                Stadium = "MOL Aréna Sóstó"
            };
            Club c3 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna"
            };
            Club c4 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Mezőkövesd Zsóry FC",
                ClubCity = "Mezőkövesd",
                ClubColour = "blue-yellow",
                ClubFounded = 1975,
                Stadium = "Mezőkövesdi Stadion"
            };
            Club c5 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Budapest Honvéd FC",
                ClubCity = "Budapest",
                ClubColour = "red-black",
                ClubFounded = 1909,
                Stadium = "Bozsik József Stadion"
            };
            Club c6 = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Újpest FC",
                ClubCity = "Budapest",
                ClubColour = "purple-white",
                ClubFounded = 1885,
                Stadium = "Szusza Ferenc Stadion"
            };

            Player p1 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dénes Dibusz",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 16),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 2.00
            };
            Player p2 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Ádám Bogdán",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 09, 27),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.350
            };
            Player p3 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Miha Blazic",
                PlayerNationality = "Slovenian",
                PlayerBirthDate = new DateTime(1993, 05, 08),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 2.00
            };
            Player p4 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Adnan Kovacevic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1993, 09, 09),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.20
            };
            Player p5 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Eldar Civic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1996, 05, 28),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.50
            };
            Player p6 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Endre Botka",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 08, 25),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.900
            };
            Player p7 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Gergő Lovrencsics C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 11, 01),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.800
            };
            Player p8 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Igor Kharatin",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1995, 02, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.80
            };
            Player p9 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Somália",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1988, 09, 28),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.30
            };
            Player p10 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dávid Sigér",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 30),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00
            };
            Player p11 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Isael",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1988, 05, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.50
            };
            Player p12 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Tokmac Nguen",
                PlayerNationality = "Norvegian",
                PlayerBirthDate = new DateTime(1993, 10, 20),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.50
            };
            Player p13 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Myrto Uzuni",
                PlayerNationality = "Albanian",
                PlayerBirthDate = new DateTime(1995, 05, 31),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.80
            };
            Player p14 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Oleksandr Zubkov",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1996, 08, 03),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.00
            };
            Player p15 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Franck Boli",
                PlayerNationality = "Ivorian",
                PlayerBirthDate = new DateTime(1993, 12, 07),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.00
            };
            Player p16 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Ádám Kovácsik",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 04, 04),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.900
            };
            Player p17 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Emil Rockov",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1995, 01, 27),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.900
            };
            Player p18 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Visar Musliu",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1994, 11, 13),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.00
            };
            Player p19 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Stopira",
                PlayerNationality = "Cape Verde",
                PlayerBirthDate = new DateTime(1988, 05, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.500
            };
            Player p20 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Hangya Szilveszter",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 01, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.450
            };
            Player p21 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Loic Nego",
                PlayerNationality = "French",
                PlayerBirthDate = new DateTime(1991, 01, 15),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.80
            };
            Player p22 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Bendegúz Bolla",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1999, 11, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p23 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Rúben Pinto",
                PlayerNationality = "Portuguese",
                PlayerBirthDate = new DateTime(1992, 04, 24),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00
            };
            Player p24 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Lyes Houri",
                PlayerNationality = "French",
                PlayerBirthDate = new DateTime(1996, 01, 19),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.10
            };
            Player p25 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Boban Nikolov",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1994, 07, 28),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.750
            };
            Player p26 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "István Kovács",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 03, 27),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.550
            };
            Player p27 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Ivan Petryak",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1994, 03, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.60
            };
            Player p28 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Evandro",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1997, 01, 14),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.20
            };
            Player p29 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Nemanja Nikolics C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 12, 31),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.50
            };
            Player p30 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Armin Hodzic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1994, 11, 17),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.00
            };
            Player p31 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Balázs Tóth",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1997, 09, 04),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.250
            };
            Player p32 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Ágoston Kiss",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(2001, 03, 14),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.100
            };
            Player p33 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Thomas Meißner",
                PlayerNationality = "German",
                PlayerBirthDate = new DateTime(1991, 03, 26),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.600
            };
            Player p34 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "João Nunes",
                PlayerNationality = "Portuguese",
                PlayerBirthDate = new DateTime(1995, 11, 19),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p35 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Kamen Hadzhiev",
                PlayerNationality = "Bulgarian",
                PlayerBirthDate = new DateTime(1991, 09, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p36 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Zsolt Nagy",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 05, 25),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300
            };
            Player p37 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Roland Szolnoki C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 01, 21),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300
            };
            Player p38 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Yoëll van Nieff",
                PlayerNationality = "Dutch",
                PlayerBirthDate = new DateTime(1993, 06, 17),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.600
            };
            Player p39 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Jakub Plsek",
                PlayerNationality = "Czech",
                PlayerBirthDate = new DateTime(1993, 12, 13),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500
            };
            Player p40 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Jozef Urblik",
                PlayerNationality = "Slovakian",
                PlayerBirthDate = new DateTime(1996, 08, 22),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400
            };
            Player p41 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Josip Knezevic",
                PlayerNationality = "Croatian",
                PlayerBirthDate = new DateTime(1988, 10, 03),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500
            };
            Player p42 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Tamás Kiss",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(2000, 11, 24),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400
            };
            Player p43 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Alexandru Baluta",
                PlayerNationality = "Romanian",
                PlayerBirthDate = new DateTime(1993, 09, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.00
            };
            Player p44 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Antonio Mance",
                PlayerNationality = "Croatian",
                PlayerBirthDate = new DateTime(1995, 08, 07),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.30
            };
            Player p45 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "David Vanecek",
                PlayerNationality = "Czech",
                PlayerBirthDate = new DateTime(1991, 03, 09),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.650
            };
            Player p46 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Péter Szappanos",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 14),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.350
            };
            Player p47 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Danylo Ryabenko",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1998, 10, 09),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.100
            };
            Player p48 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Andriy Nesterov",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1990, 07, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.350
            };
            Player p49 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Róbert Pillár",
                PlayerNationality = "Slovakian",
                PlayerBirthDate = new DateTime(1991, 05, 27),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300
            };
            Player p50 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Richárd Guzmics",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 04, 16),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.200
            };
            Player p51 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Luka Lakvekheliani",
                PlayerNationality = "Georgian",
                PlayerBirthDate = new DateTime(1998, 10, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.450
            };
            Player p52 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dániel Farkas",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 01, 13),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300
            };
            Player p53 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Aleksandr Karnitskiy",
                PlayerNationality = "Belarusian",
                PlayerBirthDate = new DateTime(1989, 02, 14),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400
            };
            Player p54 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Zsombor Berecz",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1995, 12, 13),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.550
            };
            Player p55 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dino Berisovic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1994, 01, 31),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400
            };
            Player p56 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Antonio Vutov",
                PlayerNationality = "Bulgarian",
                PlayerBirthDate = new DateTime(1996, 06, 06),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.600
            };
            Player p57 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Tamás Cseri C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 01, 15),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400
            };
            Player p58 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Serder Serderov",
                PlayerNationality = "Russian",
                PlayerBirthDate = new DateTime(1994, 03, 10),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.600
            };
            Player p59 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Andriy Boryachuk",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1996, 04, 23),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450
            };
            Player p60 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Marin Jurina",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1993, 11, 26),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.300
            };
            Player p61 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Tomas Tujvel",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1983, 09, 19),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.150
            };
            Player p62 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Oleksandr Nad",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1985, 09, 02),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.150
            };
            Player p63 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Botond Baráth",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 04, 21),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.500
            };
            Player p64 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Bence Batik",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 11, 08),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p65 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Djordje Kamber",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1983, 11, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.100
            };
            Player p66 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Krisztián Tamás",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1995, 04, 18),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p67 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Eke Uzoma",
                PlayerNationality = "Nigerian",
                PlayerBirthDate = new DateTime(1989, 08, 11),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300
            };
            Player p68 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Mohamed Mezghrani",
                PlayerNationality = "Algerian",
                PlayerBirthDate = new DateTime(1994, 06, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.350
            };
            Player p69 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Patrik Hidi C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 27),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500
            };
            Player p70 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dániel Gazdag",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 03, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00
            };
            Player p71 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Gergő Nagy",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 01, 07),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400
            };
            Player p72 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Donát Zsótér",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 01, 06),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.450
            };
            Player p73 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Márton Eppel",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 10, 26),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.40
            };
            Player p74 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Norbert Balogh",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 02, 21),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450
            };
            Player p75 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Roland Ugrai",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 11, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450
            };
            Player p76 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Filip Pajovic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1993, 07, 30),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.200
            };
            Player p77 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Dávid Banai",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 05, 09),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.250
            };
            Player p78 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Kire Ristevski",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1990, 10, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p79 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Georgios Koutroumpis",
                PlayerNationality = "Greek",
                PlayerBirthDate = new DateTime(1991, 02, 10),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400
            };
            Player p80 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Zsolt Máté",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1997, 09, 14),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.250
            };
            Player p81 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Nemanja Antonov",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1995, 05, 06),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.550
            };
            Player p82 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Branko Pauljevic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1989, 06, 12),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.200
            };
            Player p83 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Miroslav Bjelos",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1990, 10, 29),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.350
            };
            Player p84 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Vincent Onovo",
                PlayerNationality = "Nigerian",
                PlayerBirthDate = new DateTime(1995, 12, 10),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.350
            };
            Player p85 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Nikola Mitrovic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1987, 01, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.250
            };
            Player p86 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Barnabás Rázc",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 04, 26),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.200
            };
            Player p87 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Giorgi Beridze",
                PlayerNationality = "Georgian",
                PlayerBirthDate = new DateTime(1997, 05, 12),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400
            };
            Player p88 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Zoltán Stieber",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 10, 16),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400
            };
            Player p89 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Krisztián Simon C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 06, 10),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400
            };
            Player p90 = new Player()
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = "Junior Tallo",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1992, 12, 21),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.300
            };

            Manager m1 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Szerhij Rebrov",
                ManagerNationality = "Ukrainian",
                ManagerBirthDate = new DateTime(1974, 06, 03),
                ManagerStartYear = 2018,
            };
            Manager m2 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Gábor Márton",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1966, 10, 15),
                ManagerStartYear = 2020,
            };
            Manager m3 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Zsolt Hornyák",
                ManagerNationality = "Slovakian",
                ManagerBirthDate = new DateTime(1973, 05, 01),
                ManagerStartYear = 2019,
            };
            Manager m4 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Attila Kuttor",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1970, 05, 29),
                ManagerStartYear = 2017,
            };
            Manager m5 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Tamás Bódog",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1970, 09, 27),
                ManagerStartYear = 2020,
            };
            Manager m6 = new Manager()
            {
                ManagerID = Guid.NewGuid().ToString(),
                ManagerName = "Pedrag Rogan",
                ManagerNationality = "Serbian",
                ManagerBirthDate = new DateTime(1974, 08, 02),
                ManagerStartYear = 2020,
            };

            AddClub(c1);
            AddClub(c2);
            AddClub(c3);
            AddClub(c4);
            AddClub(c5);
            AddClub(c6);

            AddPlayerToClub(p1, c1.ClubID);
            AddPlayerToClub(p2, c1.ClubID);
            AddPlayerToClub(p3, c1.ClubID);
            AddPlayerToClub(p4, c1.ClubID);
            AddPlayerToClub(p5, c1.ClubID);
            AddPlayerToClub(p6, c1.ClubID);
            AddPlayerToClub(p7, c1.ClubID);
            AddPlayerToClub(p8, c1.ClubID);
            AddPlayerToClub(p9, c1.ClubID);
            AddPlayerToClub(p10, c1.ClubID);
            AddPlayerToClub(p11, c1.ClubID);
            AddPlayerToClub(p12, c1.ClubID);
            AddPlayerToClub(p13, c1.ClubID);
            AddPlayerToClub(p14, c1.ClubID);
            AddPlayerToClub(p15, c1.ClubID);
            AddPlayerToClub(p16, c2.ClubID);
            AddPlayerToClub(p17, c2.ClubID);
            AddPlayerToClub(p18, c2.ClubID);
            AddPlayerToClub(p19, c2.ClubID);
            AddPlayerToClub(p20, c2.ClubID);
            AddPlayerToClub(p21, c2.ClubID);
            AddPlayerToClub(p22, c2.ClubID);
            AddPlayerToClub(p23, c2.ClubID);
            AddPlayerToClub(p24, c2.ClubID);
            AddPlayerToClub(p25, c2.ClubID);
            AddPlayerToClub(p26, c2.ClubID);
            AddPlayerToClub(p27, c2.ClubID);
            AddPlayerToClub(p28, c2.ClubID);
            AddPlayerToClub(p29, c2.ClubID);
            AddPlayerToClub(p30, c2.ClubID);
            AddPlayerToClub(p31, c3.ClubID);
            AddPlayerToClub(p32, c3.ClubID);
            AddPlayerToClub(p33, c3.ClubID);
            AddPlayerToClub(p34, c3.ClubID);
            AddPlayerToClub(p35, c3.ClubID);
            AddPlayerToClub(p36, c3.ClubID);
            AddPlayerToClub(p37, c3.ClubID);
            AddPlayerToClub(p38, c3.ClubID);
            AddPlayerToClub(p39, c3.ClubID);
            AddPlayerToClub(p40, c3.ClubID);
            AddPlayerToClub(p41, c3.ClubID);
            AddPlayerToClub(p42, c3.ClubID);
            AddPlayerToClub(p43, c3.ClubID);
            AddPlayerToClub(p44, c3.ClubID);
            AddPlayerToClub(p45, c3.ClubID);
            AddPlayerToClub(p46, c4.ClubID);
            AddPlayerToClub(p47, c4.ClubID);
            AddPlayerToClub(p48, c4.ClubID);
            AddPlayerToClub(p49, c4.ClubID);
            AddPlayerToClub(p50, c4.ClubID);
            AddPlayerToClub(p51, c4.ClubID);
            AddPlayerToClub(p52, c4.ClubID);
            AddPlayerToClub(p53, c4.ClubID);
            AddPlayerToClub(p54, c4.ClubID);
            AddPlayerToClub(p55, c4.ClubID);
            AddPlayerToClub(p56, c4.ClubID);
            AddPlayerToClub(p57, c4.ClubID);
            AddPlayerToClub(p58, c4.ClubID);
            AddPlayerToClub(p59, c4.ClubID);
            AddPlayerToClub(p60, c4.ClubID);
            AddPlayerToClub(p61, c5.ClubID);
            AddPlayerToClub(p62, c5.ClubID);
            AddPlayerToClub(p63, c5.ClubID);
            AddPlayerToClub(p64, c5.ClubID);
            AddPlayerToClub(p65, c5.ClubID);
            AddPlayerToClub(p66, c5.ClubID);
            AddPlayerToClub(p67, c5.ClubID);
            AddPlayerToClub(p68, c5.ClubID);
            AddPlayerToClub(p69, c5.ClubID);
            AddPlayerToClub(p70, c5.ClubID);
            AddPlayerToClub(p71, c5.ClubID);
            AddPlayerToClub(p72, c5.ClubID);
            AddPlayerToClub(p73, c5.ClubID);
            AddPlayerToClub(p74, c5.ClubID);
            AddPlayerToClub(p75, c5.ClubID);
            AddPlayerToClub(p76, c6.ClubID);
            AddPlayerToClub(p77, c6.ClubID);
            AddPlayerToClub(p78, c6.ClubID);
            AddPlayerToClub(p79, c6.ClubID);
            AddPlayerToClub(p80, c6.ClubID);
            AddPlayerToClub(p81, c6.ClubID);
            AddPlayerToClub(p82, c6.ClubID);
            AddPlayerToClub(p83, c6.ClubID);
            AddPlayerToClub(p84, c6.ClubID);
            AddPlayerToClub(p85, c6.ClubID);
            AddPlayerToClub(p86, c6.ClubID);
            AddPlayerToClub(p87, c6.ClubID);
            AddPlayerToClub(p88, c6.ClubID);
            AddPlayerToClub(p89, c6.ClubID);
            AddPlayerToClub(p90, c6.ClubID);

            AddManagerToClub(m1, c1.ClubID);
            AddManagerToClub(m2, c2.ClubID);
            AddManagerToClub(m3, c3.ClubID);
            AddManagerToClub(m4, c4.ClubID);
            AddManagerToClub(m5, c5.ClubID);
            AddManagerToClub(m6, c6.ClubID);
        }
        #endregion
    }
}