using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure01
{




	class Program
	{
		static void Main(string[] args)
		{
			//CASE 1
			//Create a string and an int type PriorityQueue class. Add an item to both of the classes.
			//Check if the class works as generic. [And you can see it works perfect]

			//SOLUTION CASE 1

			//Create a string and an int type PriorityQueue class.
			var stringTypePriorityQueue = new PriorityQueue<string>();
			var intTypePriorityQueue = new PriorityQueue<int>();

			//Check if the class works as generic

			//Adding string as value works [THIS MAKES IT GENERIC]
			stringTypePriorityQueue.Add(new QueueItem<string> 
			{
				Value="Sharon",
				Priorty=0			
			});

			//Adding int as value works [THIS MAKES IT GENERIC]
			intTypePriorityQueue.Add(new QueueItem<int>
			{
				Value = 10,
				Priorty = 0
			});

			//CASE 2
			//2. Create a PriorityQueue class. Add 3 items to it, with priorities 1, 0, and 2.
			//Check if the return order of the items is correct by calling the Next method. Check if the class is empty after it returned its last item.
			
			//SOLUTION CASE 2
			var charTypePriorityQueue = new PriorityQueue<char>(); //Create a PriorityQueue class.

			//Add 3 items to it, with priorities 1, 0, and 2
			charTypePriorityQueue.Add(new QueueItem<char>
			{
				Priorty=1,
				Value = 'A',
			});
			charTypePriorityQueue.Add(new QueueItem<char>
			{
				Priorty = 0,
				Value = 'B',
			});
			charTypePriorityQueue.Add(new QueueItem<char>
			{
				Priorty = 2,
				Value = 'C',
			});

			//Check if the return order of the items is correct by calling the Next method.
			//This should return B,A,C
			Console.WriteLine(charTypePriorityQueue.Next());
			Console.WriteLine(charTypePriorityQueue.Next());
			Console.WriteLine(charTypePriorityQueue.Next());

			//Check if the class is empty after it returned its last item.
			//This should return nothing
			Console.WriteLine(charTypePriorityQueue.Next());


			//CASE 3
			//Create a PriorityQueue class. Add 5 items to it with different values and different priorities.
			//2 of the 5 items must have 0 priority.
			//Using a foreach loop, check if the order of the returned elements are correct.
			//After the iteration, check if the class still has the elements.


			//SOLUTION CASE 3

			//Create a PriorityQueue class.
			var decimalTypePriorityQueue = new PriorityQueue<decimal>();


			//Add 5 items to it with different values and different priorities.
			decimalTypePriorityQueue.Add(new QueueItem<decimal>
			{
				Priorty = 0,//2 of the 5 items must have 0 priority [1]
				Value = 23.323M
			});
			decimalTypePriorityQueue.Add(new QueueItem<decimal>
			{
				Priorty = 4,
				Value = 2213.1323M
			});
			decimalTypePriorityQueue.Add(new QueueItem<decimal>
			{
				Priorty = 2,
				Value = 13.343M
			});
			decimalTypePriorityQueue.Add(new QueueItem<decimal>
			{
				Priorty = 0,//2 of the 5 items must have 0 priority [2]
				Value = 323M
			});
			decimalTypePriorityQueue.Add(new QueueItem<decimal>
			{
				Priorty = 12,
				Value = 32
			});


			//Using a foreach loop,
			int totalItemsBeforeCallingTheForEachMethod = 5;

			var foreachResult = decimalTypePriorityQueue.ForEach();


			//check if the order of the returned elements are correct

			foreach (var item in foreachResult)
			{
				Console.WriteLine($"Priorty: {item.Priorty} and Value: {item.Value}");
			}

			if (totalItemsBeforeCallingTheForEachMethod == foreachResult.Count)
				Console.WriteLine("After the iteration, check if the class still has the elements. [PERFECT]");
			else
				Console.WriteLine("[NOOOOOOO.....]");


//CHECK HERE
var p0 = foreachResult.Where(a=>Priorty == 0);

foreach (var item in p0 )
			{
				Console.WriteLine($"Priorty: {item.Priorty} and Value: {item.Value}");
			}

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The QueueItem stores a generic value and an integer priority.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class QueueItem<T>
	{
		public int Priorty { get; set; }
		public T Value { get; set; }
	}



	/// <summary>
	/// Create a generic PriorityQueue class, which stores its QueueItem items in a private list.
	/// The PriorityQueue has two methods: Add and Next.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PriorityQueue<T> 
	{

		private List<QueueItem<T>> _queueItems;

		public PriorityQueue()
		{
			//Initialising the list
			//This will create null exception if not done
			_queueItems = new List<QueueItem<T>>();
		}

		/// <summary>
		/// The Add method adds a QueueItem to the end of its private list.
		/// </summary>
		/// <param name="item"QueueItem></param>
		public void Add(QueueItem<T> item) {
			_queueItems.Add(item);
		}

		/// <summary>
		/// The Next method returns with the value of the highest priority item from the start of the list.
		/// It removes the returned item from the list. If it finds an item with a 0 priority, it removes the item, and jumps to the next one. 
		/// (****) If there are no more items in the list, it returns with a null value.
		/// </summary>
		public T Next()
		{
			//The Next method returns with the value of the highest priority item from the start of the list.
			QueueItem<T> queueItem = _queueItems.OrderBy(a => a.Priorty).FirstOrDefault();


			//But from the Quesion (****) If there are no more items in the list 
			if (queueItem == null)
			{
				//This is how you return null in generic class
				return default;
			}
			else
			{
				//It removes the returned item from the list.
				_queueItems.Remove(queueItem);
				return queueItem.Value;
			}
		}

		/// <summary>
		/// The PriorityQueue class can be iterated through with foreach
		/// In this case, it does not remove its returned elements. 
		/// The foreach loop returns items in the same order as the Next method, 
		/// jumping through 0 priority items, but not removing them 
		/// (e.g. [A(0), B(1), C(2), D(0), E(1)] -> C, B, E). 
		/// Unlike the Next method, a foreach returns QueueItems, not their stored values.
		/// </summary>
		/// <returns>T</returns>
		public List<QueueItem<T>> ForEach()
		{
			return _queueItems.OrderBy(a => a.Priorty).ToList();
		}
	}
}
