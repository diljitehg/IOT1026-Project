namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a snake chamber, which contains a snake :( .
    /// </summary>

    public class SnakeChamber : Room
    {
        static SnakeChamber()
        {
            RoomFactory.Instance.Register(RoomType.SnakeChamber, () => new SnakeChamber());
        }

        public override RoomType Type { get; } = RoomType.SnakeChamber;

        public override bool IsActive { get; protected set; } = true;

        public override void Activate(Hero hero, Map map)
        {
               if (IsActive)
            {
                ConsoleHelper.WriteLine("You walk into the room and the floor gives way revealing a venomenous snake!", ConsoleColor.Red);
                // Could update these probabilities to be based off the hero attributes
                double chanceOfSuccess = hero.HasSword ? 0.25 : 0.75;

                if (hero.HasSword)
                {
                    ConsoleHelper.WriteLine("The snakes attacks you.", ConsoleColor.DarkMagenta);
                    hero.HasSword = true;
                }
                else
                {
                    ConsoleHelper.WriteLine("You try to defend the attack of snake but dye.", ConsoleColor.DarkMagenta);
                }

                if (RandomNumberGenerator.NextDouble() < chanceOfSuccess)
                {
                    IsActive = false;
                    ConsoleHelper.WriteLine("You manage to defeat the snake and kill it.", ConsoleColor.Green);
                    ConsoleHelper.WriteLine("Looking around, This room is now safe.", ConsoleColor.Green);
                }
                else
                {
                    ConsoleHelper.WriteLine("The snake bites you.", ConsoleColor.DarkRed);
                    hero.Kill("You have fallen and died.");
                }
            }
        }

        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Red)
                            : base.Display();
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You shudder as you recall your near death experience with the now defunct snake in this room.", ConsoleColor.DarkGray);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You feel a draft. There is a snake in a nearby room!" : "Your intuition tells you that something dangerous is nearby", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
    }
}



