using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingInventory
{
	//Base Class
	internal class InventoryItem
	{
		//We need to see these values but they shouldn't changed once initialised.
		public float Weight { get; init; }
		public float Volume { get; init; }

		public InventoryItem(float weight, float volume) 
		{
			Weight = weight;
			Volume = volume;
		}
	}

	//Child Classes
	internal class Arrow : InventoryItem
	{
		//Static & readonly as this is a set value for all instances and will never change.
		private static readonly float _weight = 0.1f;
		private static readonly float _volume = 0.05f;

		public Arrow() : base(_weight, _volume) { }
		public override string ToString() => "Arrow";
	}

	internal class Bow : InventoryItem
	{
		private static readonly float _weight = 1f;
		private static readonly float _volume = 4f;

		public Bow() : base(_weight, _volume) { }
		public override string ToString() => "Bow";
	}

	internal class Rope : InventoryItem
	{
		private static readonly float _weight = 1f;
		private static readonly float _volume = 1.5f;

		public Rope() : base(_weight, _volume) { }
		public override string ToString() => "Rope";
	}

	internal class Water : InventoryItem
	{
		private static readonly float _weight = 2f;
		private static readonly float _volume = 3f;

		public Water() : base(_weight, _volume) { }
		public override string ToString() => "Water";
	}

	internal class FoodRations : InventoryItem
	{
		private static readonly float _weight = 1f;
		private static readonly float _volume = 0.5f;

		public FoodRations() : base(_weight, _volume) { }
		public override string ToString() => "Food Rations";
	}

	internal class Sword : InventoryItem
	{
		private static readonly float _weight = 5f;
		private static readonly float _volume = 3f;

		public Sword() : base(_weight, _volume) { }
		public override string ToString() => "Sword";
	}
}
