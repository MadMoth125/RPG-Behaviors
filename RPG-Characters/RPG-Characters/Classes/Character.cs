using RPG_Characters.Interfaces;

namespace RPG_Characters.Classes
{
	/// <summary>
	/// An abstract base class for a character type (Warrior, Mage, Archer, etc...)
	/// Basic implementation of the Name and Health properties.
	/// Basic implementation of the IAttack and IDefend interfaces.
	/// </summary>
	public abstract class Character : IAttack, IDefend
	{
		public Character(string name, int health)
		{
			Name = name;
			Health = health;
		}

		/// <summary>
		/// Public name of the character.
		/// Used for custom identification.
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// Public health of the character.
		/// Determines if the character is alive if greater than 0.
		/// </summary>
		public int Health
		{
			get => _health;
			protected set => _health = Math.Max(0, value);
		}

		/// <summary>
		/// Random number generator for the class (and all subclasses).
		/// </summary>
		protected readonly Random classRandom = new Random();

		private int _health;

		public virtual void Attack(object target) => Console.WriteLine($"{Name} attacked!");

		public virtual void Defend(object instigator, int dmg) => Console.WriteLine($"{Name} defended against {dmg} damage!");

		protected virtual void Die() => Console.WriteLine($"\n{Name} died a horrible death!");
	}
}