
namespace RPG_Characters.Interfaces
{
	/// <summary>
	/// Interface for attacking a target.
	/// </summary>
	public interface IAttack
	{
		/// <summary>
		/// Logic for the attack is handled in the class implementing this interface.
		/// </summary>
		/// <param name="target">The target being attacked.</param>
		public void Attack(object target);
	}
}
