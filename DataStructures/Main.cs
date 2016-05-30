using System;
using System.Collections.Generic;

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
			List<int> intsToRemove = new List<int> ();
			Random r = new Random ();
			while (bst.getSize () < 50) {
				int randomInt = r.Next (0, 200);
				bst.insert (randomInt);

				if (randomInt % 2 == 0) {
					intsToRemove.Add (randomInt);
				}
			}

			printTreeAsList (bst);

			// Let's remove all the even numbers
			for (int i = 0; i < intsToRemove.Count; i++) {
				bst.remove (intsToRemove [i]);
			}

			printTreeAsList (bst);

//			Console.WriteLine (bst.find (4));
//			Console.WriteLine (bst.find (7));
//			Console.WriteLine (bst.find (2));
		}

		static void printTreeAsList (BinarySearchTree<int> bst)
		{
			List<int> list = bst.toList ();
			Console.Write ("[");
			for (int i = 0; i < bst.getSize (); i++) {
				int data = list [i];
				if (i > 0) {
					Console.Write (", ");
				}
				Console.Write (data);
			}
			Console.WriteLine ("]");
		}
	}
}

