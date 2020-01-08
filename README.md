Requirements:

Create a generic PriorityQueue class, which stores its QueueItem items in a private list. The PriorityQueue has two methods: Add and Next.

The Add method adds a QueueItem to the end of its private list.

The Next method returns with the value of the highest priority item from the start of the list. It removes the returned item from the list. If it finds an item with a 0 priority, it removes the item, and jumps to the next one. If there are no more items in the list, it returns with a null value.

The PriorityQueue class can be iterated through with foreach.
In this case, it does not remove its returned elements. 
The foreach loop returns items in the same order as the Next method, 
jumping through 0 priority items, but not removing them 
(e.g. [A(0), B(1), C(2), D(0), E(1)] -> C, B, E). 
Unlike the Next method, a foreach returns QueueItems, not their stored values.

The QueueItem stores a generic value and an integer priority.

 

Test cases:

1. Create a string and an int type PriorityQueue class. Add an item to both of the classes. Check if the class works as generic.

2. Create a PriorityQueue class. Add 3 items to it, with priorities 1, 0, and 2. Check if the return order of the items is correct by calling the Next method. Check if the class is empty after it returned its last item.

3. Create a PriorityQueue class. Add 5 items to it with different values and different priorities. 2 of the 5 items must have 0 priority. Using a foreach loop, check if the order of the returned elements are correct. After the iteration, check if the class still has the elements.
