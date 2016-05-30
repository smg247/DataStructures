using System;

namespace Sample
{
	public class Driver
	{
		public Driver ()
		{
		}

		public static void Main (string[] args)
		{
			BinarySearchTree<int> bst = new BinarySearchTree<int> ();
			bst.insert (1);
			bst.insert (3);
			bst.insert (7);
			bst.insert (2);
			bst.insert (10);
			bst.insert (4);
			bst.insert (5);
			bst.remove (1);
			bst.remove (7);

			Console.WriteLine (bst.find (4));
			Console.WriteLine (bst.find (7));
			Console.WriteLine (bst.find (2));
		}
	}
}

