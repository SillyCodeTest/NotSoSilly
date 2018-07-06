using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetencyPuzzles
{
    public class SinglyLinkedList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intList"></param>
        /// <exception cref="ArgumentNullException">Thrown if intList is null or empty.</exception>
        public SinglyLinkedList(IEnumerable<int> intList)
        {
            if ((intList == null) || (!intList.Any()))
            {
                throw new ArgumentNullException("intList", "intList cannot be null or empty.");
            }


            SinglyLinkedNode current = null;
            Length = 0;
            foreach (var item in intList)
            {
                if (Head == null)
                {
                    Head = new SinglyLinkedNode(item);
                    current = Head;
                }
                else
                {
                    current.Next = new SinglyLinkedNode(item);
                    current = current.Next;
                }

                Length++;
            }

            Tail = current;
        }

        public SinglyLinkedList(int firstInt)
        {
            Head = new SinglyLinkedNode(firstInt);
            Tail = Head;
            Length = 1;
        }

        public SinglyLinkedNode Head { get; private set; }

        public SinglyLinkedNode Tail
        {
            get;
            private set;
        }

        public int Length { get; private set; }

        /// <summary>
        /// Append value at tail.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Newly added node.</returns>
        /// <remarks>Insert functions and remove functions are not supported in this release.</remarks>
        public SinglyLinkedNode Append(int value)
        {
            Tail.Next = new SinglyLinkedNode(value);
            Tail = Tail.Next;
            Length++;
            return Tail;
        }


    }

    public class SinglyLinkedNode
    {
        public int Value { get; set; }

        public SinglyLinkedNode Next { get; set; }

        public SinglyLinkedNode(int value)
        {
            Value = value;
        }
    }

    public static class SinglyLinkedListHelper
    {
        /// <summary>
        /// Return node at the 1 based index.
        /// </summary>
        /// <param name="index">1 based index.</param>
        /// <returns>Node at index, or Null if index exceed the length.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is less than 1.</exception>
        public static SinglyLinkedNode GetNode(this SinglyLinkedList list, int index)
        {
            if (index < 1)
            {
                throw new ArgumentOutOfRangeException("index", "Index must be greater than 0.");
            }

            SinglyLinkedNode current = list.Head;
            int i = 1;
            while ((current != null) && (i < index))
            {
                current = current.Next;
                i++;
            }

            return current;
        }

        /// <summary>
        /// Return node at the 1 based index from tail.
        /// </summary>
        /// <param name="list">1 based index from tail</param>
        /// <param name="indexFromTail"></param>
        /// <returns>Node at index, or Null if index exceed the length.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if indexFromTail is less than 1.</exception>
        public static SinglyLinkedNode GetNodeFromTail(this SinglyLinkedList list, int indexFromTail)
        {
            if (indexFromTail < 1)
            {
                throw new ArgumentOutOfRangeException("indexFromTail", "IndexFromTail must be greater than 0.");
            }

            int index = list.Length - indexFromTail + 1;
            if (index < 1)
            {
                return null;
            }
            return GetNode(list, index);
        }
    }

}
