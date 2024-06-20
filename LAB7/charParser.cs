using System.Diagnostics;

namespace LA1;

public class CharParser
{
    private DoublyLinkedList _charList;
    
    public CharParser(char[] elements)
    {
        _charList = new DoublyLinkedList();

        foreach (var element in elements)
        {
            _charList.Add(element);
        }
    }

    public void CallMethod(int choice)
    {
        
        switch (choice)
        {
            
            case 49:
                var val = ReturnNo();
                if (val == -1)
                {
                    Console.WriteLine("Element '№' not found");
                }
                else
                {
                    Console.WriteLine("Element position: "+ val);
                }
                break;
            case 50:
                var val1 = UnPairSum();
                Console.WriteLine("Sum of odd indices: "+ val1);
                break;
            case 51:
                Console.WriteLine("Enter the value, that will be the array cutoff");
                var input1 = Console.ReadLine();
                if (input1 == null)
                {
                    Console.WriteLine("Enter something!");
                    break;
                }
                var returnA =  ValuesGreaterThan(input1);
                Console.WriteLine("The array after: ");
                var currentA = returnA.Head;
                do
                {
                    Console.Write(currentA.Data + " ");
                    currentA = currentA.Next;
                    
                } while (currentA != null);
                
                Console.WriteLine();
                break;
            case 52:
                RemoveElementsMoreThanAvg();
                Console.WriteLine("The array after: ");
                if (_charList.Head == null)
                {
                    Console.WriteLine("No elements more than x!");
                }
                else
                {
                    var current = _charList.Head;
                    do
                    {
                        Console.Write(current.Data + " ");
                        current = current.Next;
                    } while (current != null);
                }

                Console.WriteLine(); 
                break;
            default:
                throw new ArgumentException("Read pls", nameof(choice));
            
        }
    }
    public int ReturnNo()
    {
        Debug.Assert(_charList != null, nameof(_charList) + " != null");
        var current = _charList.Head;
        var index = 0;
        
        do
        {
            if (current.Data == '№')
            {
                return index;
            }

            index++;
            current = current.Next;
        } while (current != null);
        
        return -1;
    }

    public int UnPairSum()
    {
        int sum = 0;
        
        var current = _charList.Head;
        var index = 0;
        
        do
        {
            if (index % 2 != 0)
            {
                sum += current.Data;
            }

            index++;
            current = current.Next;
        } while (current != null);
        
        return sum;
    }
    public DoublyLinkedList ValuesGreaterThan(int value)
    {
        
        var returnA = new DoublyLinkedList();
        var current = _charList.Head;
        do
        {
            if (current.Data > value)
            {
                returnA.Add(current.Data);
            }
            
            current = current.Next;
        } while (current != null);
        
        return returnA;
    }

    public void RemoveElementsMoreThanAvg()
    {
        
        int avg = GetAvg();
        var current = _charList.Head;
        var index = 0;
        do
        {
            if (current.Data > avg)
            {
                _charList.Remove(index);
            }

            index++;
            current = current.Next;
        } while (current != null);
        
    }

    private int GetAvg()
    {
        int avg = 0;
        var counter = 0;
        var current = _charList.Head;
        do
        {
            counter++;
            avg += current.Data;
            current = current.Next;
        } while (current != null);
        
        return avg / counter;
    }
}

public class Node
{
    public char Data { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(char data)
    {
        Data = data;
    }
}

public class DoublyLinkedList
{
    
    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    
    private int counter;
  
    public DoublyLinkedList()
    {
        counter = 0;
    }

    public void Add(char data)
    {
        Node node = new Node(data);
        counter++;
        
        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }
    }
    
    public void Remove(int index)
    {
        if (index < 0)
        {
            throw new ArgumentException("index is less than 0", nameof(index));
        }

        if (Head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        Node current = Head;
        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException();
            }

            current = current.Next;
        }

        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
        }

        if (current.Next != null)
        {
            current.Next.Prev = current.Prev;
        }

        if (index == 0)
        {
            Head = current.Next;
        }

        if (current == Tail)
        {
            Tail = current.Prev;
        }

        counter--;
    }
}

public class DoublyLinkedListArray
{
    public CharParser[] _array = new CharParser[1];
    private int _count = 0;

    public void Add(char[] elements)
    {
            Array.Resize(ref _array, _count + 1);
            _array[_count] = new CharParser(elements);
            _count++;

    }

    public void Remove(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index is out of range of the array");
        }

        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _count--;
        Array.Resize(ref _array, _count);
    }

    public int Length()
    {
        return _array.Length;
    }
}