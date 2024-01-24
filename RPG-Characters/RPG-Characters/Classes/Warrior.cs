namespace RPG_Characters.Classes
{
	public class Warrior : Character
	{
		public Warrior(string name, int health, int attackDamage) : base(name, health)
		{
			AttackDamage = attackDamage;
		}

		public int AttackDamage { get; private set; }

		public override void Attack(object target)
		{
			// check if the target is a character
			if (target is Character character)
			{
				// check if the character is dead
				// (doesn't execute currently because of how project setup)
				if (character.Health <= 0)
				{
					Console.WriteLine($"{Name} tried attacking a dead body, but they had more dignity than to defile the dead.");
					return;
				}
				
				// announce the attack
				Console.WriteLine($"{Name} viciously attacked {character.Name} for {AttackDamage} damage!");
				
				// call the target's defend method
				// (acts as attacking the target)
				character.Defend(this, AttackDamage);
			}
			else
			{
				// if we get here, the target is not a character, thus we should not be able to attack it
				Console.WriteLine($"{Name} attacked an inanimate object!");
			}
		}

		public override void Defend(object instigator, int damage)
		{
			// check if the damage is greater than the random number
			if (classRandom.Next(1, 101) > damage)
			{
				// announce the block
				Console.WriteLine($"{Name} blocked the attack!");
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
