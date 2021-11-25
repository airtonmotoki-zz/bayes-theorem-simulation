using System;

namespace bayes_theorem_simulation
{
	class Program
	{

		static void Main(string[] args)
		{
			var totalDoors = 3;

			Random random = new();

			var sampleSize = 10000;
			var notSwitchingSucessCount = 0;
			var switchingSucessCount = 0;

			for (var sampleIndex = 0; sampleIndex < sampleSize; sampleIndex++)
			{
				var doors = new bool[totalDoors];

				// Put the prize behind the door
				var prizeLocation = random.Next(0, totalDoors);
				doors[prizeLocation] = true;

				// Player select door
				var playerDoor = random.Next(0, totalDoors);

				// Manager reveal one door (not selected by player and not contain the prize)
				var revealDoor = RevealDoor(doors, prizeLocation, playerDoor);

				// Player switch selected door
				var switchDoor = SwitchDoor(doors, revealDoor, playerDoor);

				if (doors[playerDoor])
				{
					notSwitchingSucessCount++;
				}
				if (doors[switchDoor])
				{
					switchingSucessCount++;
				}
			}

			Console.WriteLine($"{nameof(notSwitchingSucessCount)}: {notSwitchingSucessCount}");
			Console.WriteLine($"{nameof(switchingSucessCount)}: {switchingSucessCount}");
		}

		public static int RevealDoor(bool[] doors, int prizeLocation, int playerDoor)
		{
			var revealDoor = 0;
			for (var doorIndex = 0; doorIndex < doors.Length; doorIndex++)
			{
				if (doorIndex != prizeLocation && doorIndex != playerDoor)
				{
					revealDoor = doorIndex;
					break;
				}
			}
			return revealDoor;
		}

		public static int SwitchDoor(bool[] doors, int revealDoor, int playerDoor)
		{
			var switchDoor = 0;
			for (var doorIndex = 0; doorIndex < doors.Length; doorIndex++)
			{
				if (doorIndex != revealDoor && doorIndex != playerDoor)
				{
					switchDoor = doorIndex;
					break;
				}
			}
			return switchDoor;
		}
	}
}
