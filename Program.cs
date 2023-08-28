// See https://aka.ms/new-console-template for more information
using PackingInventory;
using System.Reflection.Metadata.Ecma335;

Console.Title = "Packing Inventory";
Pack bag = BagMenu();

//Show User their Pack Size
Console.Clear();
Console.WriteLine("----------");
Console.WriteLine($"Item Capactiy: {bag.MaxItems}");
Console.WriteLine($"Max Weight: {bag.MaxWeight}");
Console.WriteLine($"Max Volume: {bag.MaxVolume}");
Console.WriteLine("----------");

//Main loop to add items or view bag contents
while (true)
{
	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine("What would you like to do next?");
	Console.WriteLine("""
	[1] Add Item
	[2] View Bag Contents
	""");
	Console.ResetColor();
	int menuOption = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
	switch (menuOption)
	{
		case 1:
			AddItem();
			break;

		case 2:
			ViewBag();
			break;
	}	
}

//Ask the user which size bag they want to create
Pack BagMenu()
{
	Console.Clear();
	Console.WriteLine("""
	Select your bag size from the Menu:

	[1] Small
	[2] Medium
	[3] Large
	""");

	return Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString()) switch
	{
		1 => Pack.CreateSmallPack(),
		2 => Pack.CreateMediumPack(),
		3 => Pack.CreateLargePack(),
		_ => BagMenu()
	};
}

//Ask the user what item to add and attempt to add their choice to the bag
bool AddItem()
{
	Console.Clear();
	ViewItems();

	Console.WriteLine("""
		Which Item would you like to add to your bag?: 

		[1] Arrow
		[2] Bow
		[3] Rope
		[4] Water
		[5] Food Rations
		[6] Sword
		""");

	int userChoice = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
	Console.Clear();
	return userChoice switch
	{
		1 => bag.Add(new Arrow()),
		2 => bag.Add(new Bow()),
		3 => bag.Add(new Rope()),
		4 => bag.Add(new Water()),
		5 => bag.Add(new FoodRations()),
		6 => bag.Add(new Sword()),
		_ => false
	};
}

//Show total contents including item stats and current/max values
void ViewBag()
{
	Console.Clear();
	Console.WriteLine("Items:");
	Console.WriteLine();
	foreach (var item in bag.Items)
	{
		if (item is null)
		{
			continue;
		}
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(item.ToString());
		Console.ResetColor();
		Console.WriteLine($"Volume: {item.Volume}");
		Console.WriteLine($"Weight: {item.Weight}");
		Console.WriteLine("--------------");
	}

	Console.WriteLine($"Current / Max Weight: {bag.CurrentWeight} / {bag.MaxWeight}");
	Console.WriteLine($"Current / Max Volume: {bag.CurrentVolume} / {bag.MaxVolume}");
	Console.WriteLine($"Item Count: {bag.ItemCount}");
}


//Show only item names within the users bag
void ViewItems()
{	
	Console.WriteLine("Current contents:");
	Console.WriteLine("--------------");
	foreach (var item in bag.Items)
	{		
		if (item is null)
		{
			continue;
		}
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(item.ToString());
		Console.ResetColor();
		Console.WriteLine("--------------");
	}
}