using RPG_Characters.Classes;

namespace RPG_Characters
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Warrior warrior1 = new Warrior("Caleb the Brute", 300, 45);
			Mage mage1 = new Mage("Ron the Grey", 150, 75);
			
			await SimulateBattle(warrior1, mage1, ConvertToMilliseconds(3));
		}
		
		/// <summary>
		/// Simulates a battle between two characters.
		/// The battling characters will attack each other until one of them dies.
		/// Waits for a specified amount of time between each turn.
		/// </summary>
		/// <param name="character1">The first character in the match-up.</param>
		/// <param name="character2">The second character in the match-up.</param>
		/// <param name="turnDuration">How long to wait between each turn.</param>
		public static async Task SimulateBattle(Character character1, Character character2, int turnDuration = 1000)
		{
			while (character1.Health > 0 && character2.Health > 0)
			{
				character1.Attack(character2);
				
				Console.WriteLine();
				
				await Task.Delay(turnDuration);
				
				character2.Attack(character1);
				
				Console.WriteLine();
				
				await Task.Delay(turnDuration);
			}

			Console.ReadKey();
		}
		
		private static int ConvertToMilliseconds(int seconds) => seconds * 1000;
	}
}