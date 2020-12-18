using Logic;
using Models;
using Moq;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NB1Tests
{
    [TestFixture]
    public class NB1Test
    {
        public Mock<IRepository<Club>> clubRepo;
        public Mock<IRepository<Player>> playerRepo;
        public Mock<IRepository<Manager>> managerRepo;
        public double expectedvalue;

        [SetUp]
        public void Setup()
        {
            clubRepo = new Mock<IRepository<Club>>();
            playerRepo = new Mock<IRepository<Player>>();
            managerRepo = new Mock<IRepository<Manager>>();

            List<Club> clubs = new List<Club>()
            {
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Ferencvárosi TC",
                  ClubCity = "Budapest",
                  ClubColour = "green-white",
                  ClubFounded = 1899,
                  Stadium = "Groupama Aréna"
                },
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "MOL Fehérvár",
                  ClubCity = "Székesfehérvár",
                  ClubColour = "red-blue",
                  ClubFounded = 1914,
                  Stadium = "MOL Aréna Sóstó"
                }
            };

            List<Player> players = new List<Player>()
            {
                new Player()
                {
                  PlayerID = Guid.NewGuid().ToString(),
                  PlayerName = "Dénes Dibusz",
                  PlayerNationality = "Hungarian",
                  PlayerBirthDate = new DateTime(1990, 11, 16),
                  PlayerPosition = PlayerPosition.Goalkeeper,
                  PlayerValue = 2.00
                },
                new Player()
                {
                  PlayerID = Guid.NewGuid().ToString(),
                  PlayerName = "Miha Blazic",
                  PlayerNationality = "Slovenian",
                  PlayerBirthDate = new DateTime(1993, 05, 08),
                  PlayerPosition = PlayerPosition.Defender,
                  PlayerValue = 2.00
                },
                new Player()
                {
                  PlayerID = Guid.NewGuid().ToString(),
                  PlayerName = "Igor Kharatin",
                  PlayerNationality = "Ukrainian",
                  PlayerBirthDate = new DateTime(1995, 02, 02),
                  PlayerPosition = PlayerPosition.Midfielder,
                  PlayerValue = 1.80
                },
                new Player()
                {
                  PlayerID = Guid.NewGuid().ToString(),
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.50
                }
            };

            clubRepo.Setup(repo => repo.Read()).Returns(clubs.AsQueryable());
            playerRepo.Setup(repo => repo.Read()).Returns(players.AsQueryable());
        }

        // CRUD
        [Test]
        public void AddNewClubTest()
        {
            ClubLogic clubLogic = new ClubLogic(this.clubRepo.Object);

            Club newclub = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna"
            };

            clubRepo.Setup(x => x.Add(It.IsAny<Club>()));
            clubLogic.AddClub(newclub);
            clubRepo.Verify(x => x.Add(newclub), Times.Once);
        }

        [Test]
        public void DeleteClubTest()
        {
            ClubLogic clubLogic = new ClubLogic(this.clubRepo.Object);

            Club newclub = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna"
            };

            clubRepo.Setup(x => x.Delete(It.IsAny<Club>()));
            clubLogic.DeleteClub(newclub.ClubID);
            clubRepo.Verify(x => x.Delete(newclub.ClubID), Times.Once);
        }

        [Test]
        public void UpdateClubTest()
        {
            ClubLogic clubLogic = new ClubLogic(this.clubRepo.Object);

            Club newclub = new Club()
            {
                ClubID = Guid.NewGuid().ToString(),
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna"
            };

            clubRepo.Setup(x => x.Update(newclub.ClubID ,It.IsAny<Club>()));
            clubLogic.UpdateClub(newclub.ClubID, newclub);
            clubRepo.Verify(x => x.Update(newclub.ClubID, newclub), Times.Once);
        }

        [Test]
        public void GetAllClubTest()
        {
            ClubLogic clubLogic = new ClubLogic(this.clubRepo.Object);

            List<Club> clubs = new List<Club>()
            {
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Mezőkövesd Zsóry FC",
                  ClubCity = "Mezőkövesd",
                  ClubColour = "blue-yellow",
                  ClubFounded = 1975,
                  Stadium = "Mezőkövesdi Stadion"
                },
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Budapest Honvéd FC",
                  ClubCity = "Budapest",
                  ClubColour = "red-black",
                  ClubFounded = 1909,
                  Stadium = "Bozsik József Stadion"
                },
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Újpest FC",
                  ClubCity = "Budapest",
                  ClubColour = "purple-white",
                  ClubFounded = 1885,
                  Stadium = "Szusza Ferenc Stadion"
                }
            };

            List<Club> allclub = new List<Club>()
            {
                clubs[0], clubs[1], clubs[2]
            };

            clubRepo.Setup(x => x.Read()).Returns(clubs.AsQueryable());
            var output = clubLogic.GetAllClub();

            Assert.That(output, Is.EquivalentTo(allclub));
            Assert.That(output.Count, Is.EqualTo(allclub.Count));
        }

        [Test]
        public void GetClubTest()
        {
            ClubLogic clubLogic = new ClubLogic(this.clubRepo.Object);

            List<Club> clubs = new List<Club>()
            {
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Mezőkövesd Zsóry FC",
                  ClubCity = "Mezőkövesd",
                  ClubColour = "blue-yellow",
                  ClubFounded = 1975,
                  Stadium = "Mezőkövesdi Stadion"
                },
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Budapest Honvéd FC",
                  ClubCity = "Budapest",
                  ClubColour = "red-black",
                  ClubFounded = 1909,
                  Stadium = "Bozsik József Stadion"
                },
                new Club()
                {
                  ClubID = Guid.NewGuid().ToString(),
                  ClubName = "Újpest FC",
                  ClubCity = "Budapest",
                  ClubColour = "purple-white",
                  ClubFounded = 1885,
                  Stadium = "Szusza Ferenc Stadion"
                }
            };
            

            Club club = clubs[0];

            clubRepo.Setup(x => x.Read(clubs[0].ClubID)).Returns(clubs[0]);
            var output = clubLogic.GetClub(clubs[0].ClubID);

            Assert.That(output.ClubID, Is.EquivalentTo(club.ClubID));
        }
    }
}