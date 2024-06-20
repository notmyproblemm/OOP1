
using LA1;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var exit = 0;
        var arr = new DoublyLinkedListArray();
        CharParser parser = null;
        var x = 1;
        do
        {
            Console.WriteLine("There are {0} arrays created. To create a new one hit 0, to remove hit -(ind to remove), index 1-{0} for the rest ", arr.Length()- x);
            x = 0;
            var input = Console.ReadLine();

            if (int.TryParse(input, out var index) && index <= arr.Length())
            {
                if (index == 0)
                {
                    Console.WriteLine("Input the info for the new list");
                    input = Console.ReadLine();
                    arr.Add(input.ToCharArray());
                    Console.WriteLine("Array at index {0} has been created", arr.Length());
                }
                else if (index < 0)
                {
                    index = -index;
                    arr.Remove(index);
                }
                else 
                {
                    index--;
                
                    Console.WriteLine("What do you want to do? ((1)find the '№' element), (2)sum of odd indices , (3)array of values greater then entered, (4)remove all values greater then avg ");
                    var inp = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (inp == '\n' || inp > 59 || inp < 49)
                    {
                        throw new ArgumentException(nameof(inp));
                    }
                    arr._array[index].CallMethod(inp);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer between 0 and {0}.", arr.Length() - 1);
            }

            Console.WriteLine("Do you want to leave? (y/)");
            exit = Console.ReadKey().KeyChar;
            Console.WriteLine();
        } while(exit != 'y') ;

    }
}