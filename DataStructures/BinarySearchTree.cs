using System;

namespace Sample
{
	public class BinarySearchTree<T> where T : IComparable
	{
		private Node<T> root;

		public BinarySearchTree ()
		{
		}

		public void insert(T data)
		{
			if (root == null) {
				root = new Node<T> (data);
			} else {
				addData (data, root);
			}
		}

		private void addData(T data, Node<T> node)
		{
			int comparison = data.CompareTo (node.getData ());
			if (comparison < 0) {
				Node<T> leftChild = node.getLeftChild ();
				if (leftChild != null) {
					addData (data, leftChild);
				} else {
					node.addLeftChild (data);
				}
			} else if (comparison > 0) {
				Node<T> rightChild = node.getRightChild ();
				if (rightChild != null) {
					addData (data, rightChild);
				} else {
					node.addRightChild (data);
				}
			}
		}

		public void remove(T data)
		{
			Node<T> node = find (data);
			removeNode (node);
		}

		private void removeNode(Node<T> node)
		{
			Node<T> leftChild = node.getLeftChild ();
			Node<T> rightChild = node.getRightChild ();
			Node<T> parent = node.getParent ();
			bool nodeIsRoot = parent == null;
			bool nodeIsALeftChild = !nodeIsRoot && parent.getLeftChild () == node;

			if (leftChild == null && rightChild == null) {
				if (nodeIsALeftChild) {
					parent.setLeftChild (null);
				} else {
					parent.setRightChild (null);
				}
			} else if (leftChild == null) {
				replaceWithChild (node, rightChild, nodeIsALeftChild, nodeIsRoot);
			} else if (rightChild == null) {
				replaceWithChild (node, leftChild, nodeIsALeftChild, nodeIsRoot);
			} else {
				Node<T> successor = rightChild.findMinimumNode ();
				node.setData (successor.getData ());
				removeNode (successor);
			}
		}

		private void replaceWithChild(Node<T> node, Node<T> child, bool nodeIsAleftChild, bool nodeIsRoot)
		{
			Node<T> parent = node.getParent ();
			child.setParent (parent);
			if (nodeIsRoot) {
				root = child;
			} else if (nodeIsAleftChild) {
				parent.setLeftChild (child);
			} else {
				parent.setRightChild (child);
			}
		}

		public Node<T> find(T data)
		{
			if (root == null) {
				return null;
			}

			return findData (data, root);
		}

		private Node<T> findData(T data, Node<T> node)
		{
			if (node == null) {
				return null;
			}

			int comparison = data.CompareTo (node.getData ());

			if (comparison == 0) {
				return node;
			} else if (comparison < 0) {
				return findData (data, node.getLeftChild ());
			} else {
				return findData (data, node.getRightChild ());
			}
		}


		public class Node<DataType> where DataType : IComparable
		{
			private DataType data;
			private Node<DataType> leftChild;
			private Node<DataType> rightChild;
			private Node<DataType> parent;

			public Node (DataType data)
			{
				this.data = data;
			}

			public DataType getData()
			{
				return data;
			}

			public void setData(DataType data)
			{
				this.data = data;
			}

			public Node<DataType> getLeftChild()
			{
				return leftChild;
			}

			public void addLeftChild(DataType data)
			{
				leftChild = new Node<DataType> (data);
				leftChild.setParent (this);
			}

			public void setLeftChild(Node<DataType> leftChild)
			{
				this.leftChild = leftChild;
			}

			public Node<DataType> getRightChild()
			{
				return rightChild;
			}

			public void addRightChild(DataType data)
			{
				rightChild = new Node<DataType> (data);
				rightChild.setParent (this);
			}

			public void setRightChild(Node<DataType> rightChild)
			{
				this.rightChild = rightChild;
			}

			public Node<DataType> getParent()
			{
				return parent;
			}

			public void setParent(Node<DataType> parent)
			{
				this.parent = parent;
			}

			public Node<DataType> findMinimumNode()
			{
				Node<DataType> currentNode = this;
				while (currentNode.getLeftChild () != null) {
					currentNode = currentNode.getLeftChild ();
				}

				return currentNode;
			}

			public override string ToString ()
			{
				return "Node(value=" + data + " parent=" + (parent != null ? parent.getData ().ToString() : "null") + " leftChild=" + (leftChild != null ? leftChild.getData ().ToString() : "null") + " rightChild=" + (rightChild != null ? rightChild.getData ().ToString() : "null") + ")";
			}
		}
	}
}

