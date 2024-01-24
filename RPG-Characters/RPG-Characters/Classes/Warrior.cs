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
			if (target is Character character)
			{
				if (character.Health <= 0)
				{
					Console.WriteLine($"{Name} tried attacking a dead body, but they had more dignity than to defile the dead.");
					return;
				}
				
				character.Defend(this, AttackDamage);
				Console.WriteLine($"{Name} viciously attacked {character.Name} for {AttackDamage} damage!");
			}
			else
			{
				Console.WriteLine($"{Name} attacked an inanimate object!");
			}
		}

		public override void Defend(object instigator, int damage)
		{
			if (classRandom.Next(1, 101) > damage)
			{
				Console.WriteLine($"{Name} blocked the attack!");
				return;
			}
			
			Health -= damage;
			if (Health <= 0)
			{
				Die();
				return;
			}
			
			Console.WriteLine($"{Name} took {damage} damage!");
		}

		protected override void Die()
		{
			base.Die();
		}
	}
}
