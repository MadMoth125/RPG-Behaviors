
namespace RPG_Characters.Interfaces
{
	public interface IDefend
	{
		/// <summary>
		/// Interface for defending against an attack.
		/// Carries data about the instigator initiating the attack and the damage it is dealing.
		/// </summary>
		/// <param name="instigator">The instigator initiating the attack.</param>
		/// <param name="damage">The damage value being dealt.</param>
		public void Defend(object instigator, int damage);
	}
}
