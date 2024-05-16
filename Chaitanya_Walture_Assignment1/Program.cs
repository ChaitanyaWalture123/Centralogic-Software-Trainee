using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task
    {
        internal string title;
        internal string description;

        public Task(string title, string description)
        {
            this.title = title;
            this.description = description; 
        }


        
    }
    internal class Program
    {
        List<Task> tasks=new List<Task>();
        void add() {
            
           
            Console.WriteLine("Please enter Task Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Please enter Task Discriptiom:");
            string description = Console.ReadLine();

            Task t = new Task(title,description);
            tasks.Add(t);
            Console.WriteLine("Task Added Sucessfully");

        }

        void display() {

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            int count = 1;
            foreach(Task task in tasks)
            {
                Console.WriteLine("{0} | Task Title : {1} | Discription : {2}", count, task.title, task.description);
                count++;
            }
        }

        void update()
        {
          
            display();

            Console.WriteLine("Enter the task number to update");
            int num = int.Parse(Console.ReadLine());
            int index = num - 1;
            Console.WriteLine("Enter the task title to be updated with(leave blank if want to keep as it is)");
            string newtitle = Console.ReadLine();
            Console.WriteLine("Enter the task discription to be updated with (leave blank if want to keep as it is)");
            string newdescription = Console.ReadLine();

            if (index >= 0 && index < tasks.Count)
            {
                if (newtitle != null)
                {

                    tasks[index].title = newtitle;
                }
                if (newdescription != null)
                {

                    tasks[index].description = newdescription;
                }
                
                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task number. No task updated.");
            }

        }

        void remove()
        {
            display() ;

            Console.WriteLine("Please enter Task Title You Want To delete:");
            string dtitle = Console.ReadLine();

            if (tasks.Exists(task=>task.title==dtitle)) {
                tasks.RemoveAll(task => task.title == dtitle);
                Console.WriteLine("Task deleted Sucessfull !");

            }
            else
            {
                Console.WriteLine("Task not Available");
            }

        }
        
        
        
        static void Main(string[] args)
        {

            Program program = new Program();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Task List Application");
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Read tasks");
                Console.WriteLine("3. Update a task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        program.add();
                        break;
                    case 2:
                        program.display();
                        break;
                    case 3:
                        program.update();
                        break;
                    case 4:
                        program.remove();
                        break;
                    case 5:
                        isRunning = false;
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }


           
           
        }
    }
}
