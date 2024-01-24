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
			// check if the target is a character
			if (target is Character character)
			{
				// check if the character is dead
				// (doesn't execute currently because of how project setup)
				if (character.Health <= 0)
				{
					Console.WriteLine($"{Name} tried spell-casting a dead body, but they had more dignity than to waste their mana on the dead.");
					return;
				}
				
				// announce the attack
				Console.WriteLine($"{Name} casted {character.Name} for {MagicDamage} damage!");
				
				// call the target's defend method
				// (acts as attacking the target)
				character.Defend(this, MagicDamage);
			}
			else
			{
				// if we get here, the target is not a character, thus we should not be able to attack it
				Console.WriteLine($"{Name} casted a spell at an inanimate object!");
			}
		}

		public override void Defend(object instigator, int damage)
		{
			// check if the damage is greater than the random number
			if (classRandom.Next(1, 101) > damage)
			{
				// announce the block
				Console.WriteLine($"{Name} magically shielded the attack!");
				return;
			}
			
			// announce the damage taken
			Console.WriteLine($"{Name} took {damage} damage!");
			
			// subtract the damage from the health
			Health -= damage;
			
			// check if the health is less than or equal to 0
			// if so, call the "Die" method to announce the death of the character
			if (Health <= 0) Die();
		}
	}
}