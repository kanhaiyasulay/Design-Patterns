using System;

namespace GameDevelopment
{
    // Step 1: Define the Base Component
    public interface IPlayer
    {
        string GetAbilities();
        int GetPower();
    }

    // Step 2: Create a Concrete Component (Base Player)
    public class BasePlayer : IPlayer
    {
        public string GetAbilities()
        {
            return "Basic Attack";
        }

        public int GetPower()
        {
            return 10;
        }
    }

    // Step 3: Create an Abstract Decorator
    public abstract class PlayerDecorator : IPlayer
    {
        protected IPlayer _player;

        public PlayerDecorator(IPlayer player)
        {
            _player = player;
        }

        public virtual string GetAbilities()
        {
            return _player.GetAbilities();
        }

        public virtual int GetPower()
        {
            return _player.GetPower();
        }
    }

    // Step 4: Add Concrete Decorators (Power-ups)
    public class ShieldDecorator : PlayerDecorator
    {
        public ShieldDecorator(IPlayer player) : base(player) { }

        public override string GetAbilities()
        {
            return _player.GetAbilities() + ", Shield";
        }

        public override int GetPower()
        {
            return _player.GetPower() + 20;
        }
    }

    public class FireSwordDecorator : PlayerDecorator
    {
        public FireSwordDecorator(IPlayer player) : base(player) { }

        public override string GetAbilities()
        {
            return _player.GetAbilities() + ", Fire Sword";
        }

        public override int GetPower()
        {
            return _player.GetPower() + 30;
        }
    }

    // Step 5: Use the Decorator Pattern
    public class Game
    {
        public static void Main(string[] args)
        {
            // Base player
            IPlayer player = new BasePlayer();
            Console.WriteLine($"Abilities: {player.GetAbilities()}, Power: {player.GetPower()}");

            // Add shield
            player = new ShieldDecorator(player);
            Console.WriteLine($"Abilities: {player.GetAbilities()}, Power: {player.GetPower()}");

            // Add fire sword
            player = new FireSwordDecorator(player);
            Console.WriteLine($"Abilities: {player.GetAbilities()}, Power: {player.GetPower()}");
        }
    }
}
