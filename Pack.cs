using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PackingInventory;

namespace PackingInventory
{
	internal class Pack
	{
		public InventoryItem[] Items { get; private set; }
		public float MaxWeight { get; private set; }
		public float MaxVolume { get; private set; }
		public int MaxItems { get; private set; }
		private float _currentWeight;
		private float _currentVolume;
		private int _currentItems;

		//Examine array and get total weight
		public float CurrentWeight
		{
			get
			{				
				_currentWeight = 0f;
				foreach (var item in Items)
				{
					if (item is null) continue;

					_currentWeight += item.Weight;
				}
				return _currentWeight;
			}
			private set { }
		}
		
		//Examine array and get total volume		
		public float CurrentVolume
		{
			get 
			{ 
				_currentVolume = 0f;
				foreach (var item in Items)
				{
					if (item is null) continue;

					_currentVolume += item.Volume;
				}
				return _currentVolume;
			}
			private set { }
		}

		//Examine array and get total items	
		public float ItemCount
		{
			get
			{
				_currentItems = 0;
				foreach (var item in Items)
				{
					if (item is null) continue;

					++_currentItems;
				}
				return _currentItems;
			}

			private set { }
		}

		public Pack(int maxItems, float maxWeight, float maxVolume) 
		{
			Items = new InventoryItem[maxItems];
			MaxItems = maxItems;
			MaxWeight = maxWeight;
			MaxVolume = maxVolume;
		}

		//Set Pack Sizes
		public static Pack CreateSmallPack() => new(5, 3f, 3f);
		public static Pack CreateMediumPack() => new(7, 9f, 10f); 
		public static Pack CreateLargePack() => new(10, 15f, 20f);

		//Add a new items if there is space.
		public bool Add(InventoryItem item)
		{			
			for (int i = 0; i <= Items.Length-1; i++)
			{
				if (Items[i] is null && !IsFull())
				{
					if (CurrentVolume + item.Volume > MaxVolume)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"Unable to add {item} - Insufficient Volume");
						Console.ResetColor();
						return false;
					}
					if (CurrentWeight + item.Weight > MaxWeight)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"Unable to add {item} - Too Heavy");
						Console.ResetColor();
						return false;
					}
					Items[i] = item;
					Console.ForegroundColor= ConsoleColor.DarkGreen;
					Console.WriteLine($"{item} Added to bag");
					Console.ResetColor();
					return true;
				}				
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Unable to add {item} - Bag is Full");
			Console.ResetColor();
			return false;
		}

		//Is the Pack full on any of our limits
		public bool IsFull() => IsMaxItems() || IsMaxWeight() || IsMaxVolume();
		public bool IsMaxItems() => ItemCount >= MaxItems;
		public bool IsMaxWeight() => CurrentWeight >= MaxWeight;
		public bool IsMaxVolume() => CurrentVolume >= MaxVolume;

	}
}
