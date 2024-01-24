namespace RPG_Characters.Classes
{
	public class Mage : Character
	{
		public Mage(string name, int health, int magicDamage) : base(name, health)
		{
			MagicDamage = magicDamage;
		}

		public int MagicDamage
		{
			get => _magicDamage;
			private set => _magicDamage = Math.Max(0, value);
		}

		private int _magicDamage;
		
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
				
				// generate a random number to determine the damage modifier
				int rdmMagicModifier = classRandom.Next(-8, 16);
					
				// announce the attack and cast the spell
				if (classRandom.Next(1, 51) > 25)
				{
					CastFireball(character, rdmMagicModifier);
				}
				else
				{
					CastLightningBolt(character, rdmMagicModifier);
				}
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
			if (Health <= 0)
			{
				Die();
			}
			else if (classRandom.Next(1, 101) > 75)
			{
				// 25%-ish chance to heal self after taking damage
				CastHeal(this);
			}
		}

		/// <summary>
		/// Function for casting the "Fireball" spell.
		/// Announces the spell and the damage dealt.
		/// </summary>
		/// <param name="target">The target to cast towards.</param>
		/// <param name="damageModifier">The damage modifier to add to the damage.</param>
		private void CastFireball(Character target, int damageModifier = 0)
		{
			if (Health <= 0) return;
			
			Console.WriteLine($"{Name} casted \"Fireball\" towards {target.Name}!");
			target.Defend(this, MagicDamage + damageModifier);
		}
		
		/// <summary>
		/// Function for casting the "Lightning-Bolt" spell.
		/// Announces the spell and the damage dealt.
		/// </summary>
		/// <param name="target">The target to cast towards.</param>
		/// <param name="damageModifier">The damage modifier to add to the damage.</param>
		private void CastLightningBolt(Character target, int damageModifier = 0)
		{
			if (Health <= 0) return;
			
			Console.WriteLine($"{Name} casted \"Lightning-Bolt\" upon {target.Name}!");
			target.Defend(this, MagicDamage + damageModifier);
		}
		
		/// <summary>
		/// Function for casting the "Heal" spell.
		/// Announces the spell and the health healed.
		/// Cannot heal other characters.
		/// </summary>
		/// <param name="target">The target to heal.</param>
		private void CastHeal(Character target)
		{
			if (Health <= 0) return;
			
			if (target == this)
			{
				Console.WriteLine("The mage healed themselves for 10 health points!");
				Health += 10;
			}
			else
			{
				Console.WriteLine($"{Name} cannot heal {target.Name}!");
			}
		}
	}
}