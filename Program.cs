using System;

public class DoublyNode<T>
{
    public DoublyNode(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}

public class Deque<T>
{
    DoublyNode<T> head; // начало списка
    DoublyNode<T> tail; // конец списка

    public Deque() { }

    public List<int> Find(T searchItem)
    {
        List<int> foundPositions = new List<int>();
        DoublyNode<T> current = head;
        int position = 0;
        while (current != null)
        {
            if (current.Data.Equals(searchItem))
            {
                foundPositions.Add(position);
            }
            current = current.Next;
            position++;
        }
        return foundPositions;
    }

    public void AddToFront(T item)
    {
        DoublyNode<T> node = new DoublyNode<T>(item);
        node.Next = head;
        if (head != null)
        {
            head.Previous = node;
        }
        else
        {
            tail = node;
        }
        head = node;
    }

    public void AddToBack(T item)
    {
        DoublyNode<T> node = new DoublyNode<T>(item);
        node.Previous = tail;
        if (tail != null)
        {
            tail.Next = node;
        }
        else
        {
            head = node;
        }
        tail = node;
    }

    public void Remove(T item)
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
            }
            current = current.Next;
        }
    }


    public void RemoveFromFront()
    {
        if (head == null) return;
        head = head.Next;
        if (head != null)
        {
            head.Previous = null;
        }
        else
        {
            tail = null;
        }
    }

    public void RemoveFromBack()
    {
        if (tail == null) return;
        tail = tail.Previous;
        if (tail != null)
        {
            tail.Next = null;
        }
        else
        {
            head = null;
        }
    }

    public void Print()
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Deque<int> deque = new Deque<int>();

        while (true)
        {
            Console.WriteLine("Введите команду (addfront, addback, remove, removefront, removeback, find, print, exit):");
            string command = Console.ReadLine();

            if (command == "addfront")
            {
                Console.WriteLine("Введите элемент для добавления в начало очереди:");
                int item = int.Parse(Console.ReadLine());
                deque.AddToFront(item);
            }
            else if (command == "addback")
            {
                Console.WriteLine("Введите элемент для добавления в конец очереди:");
                int item = int.Parse(Console.ReadLine());
                deque.AddToBack(item);
            }
            else if (command == "remove")
            {
                Console.WriteLine("Введите элемент для удаления из очереди:");
                int item = int.Parse(Console.ReadLine());
                deque.Remove(item);
            }
            else if (command == "removefront")
            {
                deque.RemoveFromFront();
            }
            else if (command == "removeback")
            {
                deque.RemoveFromBack();
            }
            else if (command == "find")
            {
                Console.WriteLine("Введите элемент для поиска в очереди:");
                int item = int.Parse(Console.ReadLine());
                List<int> positions = deque.Find(item);
                if (positions.Count > 0)
                {
                    Console.WriteLine("Элемент найден на позициях: " + string.Join(", ", positions));
                }
                else
                {
                    Console.WriteLine("Элемент не найден в очереди.");
                }
            }
            else if (command == "print")
            {
                deque.Print();
            }
            else if (command == "exit")
            {
                Console.WriteLine("До свидания!");
                break;
            }
            else
            {
                Console.WriteLine("Неверная команда. Попробуйте еще раз.");
            }
        }
    }
}
