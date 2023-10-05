using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedlist_HW2
{
    class student
    {

        public int id;
        public int average;
        public string name;
        public student(int id,int average, string name)
        {
            this.id = id;
            this.average = average;
            this.name = name;
        }
        //if we were used private definition we must use below code.
        //public int Id { get; set; }
        //public int Average { get; set; }
        //public  string Name { get; set; }
    }
    class Program
    {
        class LinkedListNode
        {
            public student date;
            public LinkedListNode next;
            
            public LinkedListNode(student x)
            {
                date = x;
                next = null;
            }
        }
        class LinkedList
        {
            //For referencing of the beginning of the linked list.
            //if we dont have this head method we will be lost in our linkedlist.
            LinkedListNode head;
            //we create a constructor for count, in orded to find out about
            //how much data is in our linkedlist.
            int count;
            public LinkedList()
            {
                head = null;
                count = 0;
            }

            public void AddStudent(student data)
            {
                LinkedListNode node = new LinkedListNode(data);

                if (head ==null)
                {
                    head = node;
                }
                else
                {
                    LinkedListNode currentnode = head;
                    while (currentnode.next != null)
                    {
                        currentnode = currentnode.next;
                    }
                    currentnode.next = node;
                    count++;
                }
                
                //node.next = head;
                //head = node;
                //count++;
            }
            public void SortbyAve()
            {
                //we use insertion sort here
                //first check
                if (head == null || head.next == null)
                    return;
                
                LinkedListNode current = head;
                //for pointig our head.
                LinkedListNode nextnode = null;
                //for pointing to the second node.
                //now we need to compare all the nodes of the linked list with the current node.
                while (current != null)
                {
                    nextnode = current.next;
                    while (nextnode != null)
                    {
                        if (current.date.average.CompareTo(nextnode.date.average) > 0 )
                        {
                            // for swaping the data. 
                            student temp = current.date;
                            current.date = nextnode.date;
                            nextnode.date = temp;
                        }
                        //geting in the next step for compairing current with the next nodes. 
                        nextnode = nextnode.next;
                    }
                    //next step for 
                    current = current.next;
                }

            }
            public void DeletebyId(student student)
            {
                LinkedListNode node2 = new LinkedListNode(student);
                int found = 0, position = 0, i;
                LinkedListNode temp = head;
                while (temp != null)
                {
                    if (node2.date.id == temp.date.id)
                    {
                        found = 1;
                        break;
                    }
                    temp = temp.next;
                    position++;
                }
                if (found == 1)
                {
                    temp = head;
                    if (position == 0)
                    {
                        head = temp.next;
                        //free(temp);
                        temp = null;
                    }
                    for ( i = 0; i < position-1; i++)
                    {
                        temp = temp.next;
                    }
                    LinkedListNode temp2 = temp.next;
                    temp.next = temp2.next;
                    //free(temp2);
                    temp2 = null;
                    
                    Console.WriteLine("Student deleted");
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
            public LinkedListNode DeletebyID2(int position)
            {
                if (head == null)
                {
                    Console.WriteLine("Underflow! can't delete from empty list");
                    return head;
                }
                if (position < 1)
                {
                    Console.WriteLine("Invalid position");
                    return head;
                }
                if (position ==1)
                {
                    if (head == null)
                    {
                        Console.WriteLine("Underflow! can't delete from empty list");
                        return head;
                    }
                    LinkedListNode ptr = head;
                    head = head.next;
                    ptr = null;
                    return head;
                }
                LinkedListNode ptr1 = head;
                position--;
                while (position > 1)
                {
                    ptr1 = ptr1.next;
                    position--;
                }
                LinkedListNode ptr2 = ptr1.next;
                ptr1.next = ptr2.next;
                ptr2 = null;
                return head;

            }
            public void PrintList()
            {
              
                LinkedListNode runner = head;
                while (runner != null)
                {
                    Console.WriteLine("Student info: Name: {0} Average: {1} Id: {2}",runner.date.name,runner.date.average,runner.date.id);
                    runner = runner.next;
                    
                }
            }

        }
        static void Main(string[] args)
        {
            LinkedList linkedlist = new LinkedList();
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Choose your option: ");
                Console.WriteLine("1- Add student.");
                Console.WriteLine("2- Sort student by their average.");
                Console.WriteLine("3- Delete student by there position in the list.");
                Console.WriteLine("4- Delete student by there ID.");
                Console.WriteLine("5- print list.");
                Console.WriteLine("6- Exit");
                Console.Write("====>> ");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter student name: ");
                        string studentname = Console.ReadLine();
                        Console.Write("Enter student Average: ");
                        int Average = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter student ID: ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        student student = new student(ID, Average, studentname);
                        linkedlist.AddStudent(student);
                        Console.WriteLine("Studnet Added: Name: {0} Average: {1} ID: {2}",studentname,Average,ID);
                        break;
                    case 2:
                        linkedlist.SortbyAve();
                        linkedlist.PrintList();
                        break;
                    case 3:
                        linkedlist.PrintList();
                        Console.WriteLine();
                        Console.Write("Enter the student position that you want to delete: ");
                        int studnetid = Convert.ToInt32(Console.ReadLine());
                        linkedlist.DeletebyID2(studnetid);
                        Console.WriteLine("New student list: ");
                        linkedlist.PrintList();
                        break;
                    case 4:
                        Console.Write("Enter student id that you want to delete: ");
                        int Deleteid = Convert.ToInt32(Console.ReadLine());
                        student student2 = new student(Deleteid,0,null);
                        //student2.id = Deleteid;
                        linkedlist.DeletebyId(student2);
                        Console.WriteLine("New student list:");
                        linkedlist.PrintList();
                        break;
                    case 5:
                        linkedlist.PrintList();
                        break;
                    case 6:
                        Console.WriteLine("You are logged out.");
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("The entered number is not valid.");
                        break;
                }
            }
            
            
        }
    }
}
