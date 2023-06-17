using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class CustomMonsterTests
    {
        [TestMethod]
        public void Activate_sword()
        {
            Location heroLocation = new Location(0, 0); // Provide the desired location for the hero
            Hero hero = new Hero(heroLocation);
            hero.HasSword = true;
            Map map = new Map(10, 10);
            CustomMonster customMonster = new CustomMonster();

            // Act
            customMonster.Activate(hero, map);

            // Assert
            Assert.IsFalse(hero.HasSword);
        }

        [TestMethod]
        public void Activate_location()
        {
            // Arrange
            Location heroLocation = new Location(0, 0); // Provide the desired location for the hero
            Hero hero = new Hero(heroLocation);;
            hero.Location = new Location(5, 5);
            Map map = new Map(10, 10);
            CustomMonster customMonster = new CustomMonster();

            // Act
            customMonster.Activate(hero, map);

            // Assert
            Assert.AreNotEqual(new Location(5, 5), hero.Location);
            Assert.AreEqual(RoomType.Room, map.GetRoomAtLocation(hero.Location).Type);
        }

        [TestMethod]
        public void Display_displaystuff()
        {
            // Arrange
            CustomMonster customMonster = new CustomMonster();

            // Act
            DisplayDetails displayDetails = customMonster.Display();

            // Assert
            Assert.AreEqual("Custom Monster", displayDetails.Text);
            Assert.AreEqual(ConsoleColor.Red, displayDetails.Color);
        }
    }
}
