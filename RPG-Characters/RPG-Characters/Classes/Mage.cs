namespace RPG_Characters.Classes
{
	public class Mage : Character
	{
		public Mage(string name, int health, int magicDamage) : base(name, health)
		{
			MagicDamage = magicDamage;
		}

		public int MagicDamage { get; private set; }

		public override void Attack(object target)
		{
			if (target is Character character)
			{
				if (character.Health <= 0)
				{
					Console.WriteLine($"{Name} tried spell-casting a dead body, but they had more dignity than to waste their mana on the dead.");
					return;
				}
				
				character.Defend(this, MagicDamage);
				Console.WriteLine($"{Name} casted {character.Name} for {MagicDamage} damage!");
			}
			else
			{
				Console.WriteLine($"{Name} casted a spell at an inanimate object!");
			}
		}

		public override void Defend(object instigator, int damage)
		{
			if (classRandom.Next(1, 101) > damage)
			{
				Console.WriteLine($"{Name} magically shielded the attack!");
				return;
			}
			
			Health -= damage;
			Console.WriteLine($"{Name} took {damage} damage!");
		}
	}
}