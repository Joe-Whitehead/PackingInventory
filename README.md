# [C# Player's Guide] Packing Inventory

My Solution for the C# Player's Guide Challenge for "Packing Inventory" also includes "Labelling Inventory" followup changes.

**Objectives:**
<ul>
  <li>Create an InventoryItem class that represents any of the different item types. This class must
represent the item’s weight and volume, which it needs at creation time (constructor).</li>
<li>Create derived classes for each of the types of items above. Each class should pass the correct weight
and volume to the base class constructor but should be creatable themselves with a parameterless
constructor (for example, new Rope() or new Sword()).</li>
<li>Build a Pack class that can store an array of items. The total number of items, the maximum weight,
and the maximum volume are provided at creation time and cannot change afterward.</li>
<li>Make a public bool Add(InventoryItem item) method to Pack that allows you to add items
of any type to the pack’s contents. This method should fail (return false and not modify the pack’s
fields) if adding the item would cause it to exceed the pack’s item, weight, or volume limit.</li>
<li>Add properties to Pack that allow it to report the current item count, weight, and volume, and the
limits of each.</li>
<li>Create a program that creates a new pack and then allow the user to add (or attempt to add) items
chosen from a menu.</li>
</ul>

**Labelling Inventory additions:**
<ul>
  <li>Override the existing ToString method (from the object base class) on all of your inventory item
subclasses to give them a name. For example, new Rope().ToString() should return "Rope".</li>
<li>Override ToString on the Pack class to display the contents of the pack. If a pack contains water,
rope, and two arrows, then calling ToString on that Pack object could look like "Pack
containing Water Rope Arrow Arrow".</li>
<li>Before the user chooses the next item to add, display the pack’s current contents via its new
ToString method.</li>  
</ul>
