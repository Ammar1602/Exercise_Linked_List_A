using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*creates Node for the circular list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)/*Search for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current,  current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*If the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*If the node is present at the end*/
                return true;
            else
                return (false);/*return false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true ;
            else
                return false ;
        }

        public void traverse()/*Traverses all the node of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "     " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "     " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList Is Empty");
            else
                Console.WriteLine("\nThe First Record In The List Is:\n\n" + LAST.next.rollNumber + "    " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine(" Exit");
                    Console.WriteLine("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number off the student whose record is to be searche: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord founf");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break ;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break ;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
