using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chaitanya_Walture_Assignment2
{

    

    internal class Item
    {
        private int id;
        private string name;
        private double price;
        private int quantity;


        public Item(int id, string name, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public int getId() { return id; }
        public string getName() { return name; }
        public double getPrice() { return price; }
        public int getQuantity() { return quantity; }


        public void SetName(String name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.name = name;
            }
            else
            {
                Console.WriteLine("Name cannot be empty or whitespace ");
                
            }
            

        }
        public void SetPrice(double price)
        {
            if(price>0)
            {
                this.price = price;

            }
            else
            {
                Console.WriteLine("value is invalid");
            }
            
        }

        public void SetQuantity(int quantity)
        {
            if (quantity >=0)
            {
                this.quantity = quantity;
            }
            else
            {
                Console.WriteLine(" value is invalid");

            }
        }
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Price: {price}, Quantity: {quantity}";
        }
    }



    class Inventory
    {
        private List<Item> items;
        private int nextId;
        
        public Inventory()
        {  
            items = new List<Item>();

            nextId = 1;
            

        }

        public void Add()
        {
            string name;
            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
                Console.WriteLine("Name cannot be empty or whitespace. Please enter a valid name.");
            }

            double price;
            while (true)
            {
                Console.Write("Enter Price: ");
                if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
                Console.WriteLine("Price must be a positive number. Please enter a valid price.");
            }

            int quantity;
            while (true)
            {
                Console.Write("Enter Quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    break;
                }
                Console.WriteLine("Quantity must be a positive integer. Please enter a valid quantity.");
            }

            Item item = new Item(nextId, name, price, quantity);
            items.Add(item);
            nextId++;
            Console.WriteLine("Item added successfully");
        }


        public void Display()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
                return;
            }
            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void FindById()
        {
            Console.WriteLine("Enter Id id item : ");

            string ids = Console.ReadLine();
            if (int.TryParse(ids, out int id))
            {
                Item item = items.Find(it => it.getId() == id);
                if (item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine(" Item not found ");
                }
            }
            else
            {
                Console.WriteLine(" Invalid input ");
            }
        }
        public void Update()
        {
            Console.WriteLine("Enter the Id of the item to be updated:");
            string ids = Console.ReadLine();

            if (int.TryParse(ids, out int id))
            {
                Item item = items.Find(it => it.getId() == id);
                if (item != null)
                {
                    bool updated = false;

                    Console.WriteLine("Enter the Item Name (Leave blank if you don't want to change):");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        item.SetName(newName);
                        updated = true;
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the Item Price (Leave blank if you don't want to change):");
                        string newPrice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newPrice))
                        {
                            break; 
                        }

                        if (double.TryParse(newPrice, out double price))
                        {
                            if (price > 0)
                            {
                                item.SetPrice(price);
                                updated = true;
                                break; 
                            }
                            else
                            {
                                Console.WriteLine("Price must be a positive number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price value.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the Item Quantity (Leave blank if you don't want to change):");
                        string newQuantity = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newQuantity))
                        {
                            break; 
                        }

                        if (int.TryParse(newQuantity, out int quantity))
                        {
                            if (quantity >= 0)
                            {
                                item.SetQuantity(quantity);
                                updated = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Quantity cannot be negative.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity value.");
                        }
                    }

                    if (updated)
                    {
                        Console.WriteLine("Item updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No changes were made to the item.");
                    }
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID entered.");
            }
        }



        public void Delete()
        {
            Console.WriteLine("Enter the item id to be deleted");
            string ids = Console.ReadLine();
            if (int.TryParse(ids, out int id))
            {
                Item item = items.Find(it => it.getId() == id);
                if (item != null)
                {
                    items.Remove(item);
                    Console.WriteLine("Item deleted ");

                }

                else
                {
                    Console.WriteLine("Item not found ");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Inventory inventory = new Inventory();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        inventory.Add();
                        break;
                    case "2":
                        inventory.Display();
                        break;
                    case "3":
                        inventory.FindById();
                        break;
                    case "4":
                        inventory.Update();
                        break;
                    case "5":
                        inventory.Delete();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again ");
                        break;
                }
            }
        }
    }
}
