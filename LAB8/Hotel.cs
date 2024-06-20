namespace LAB8;

public class Hotel
{
    private OrderList _orderList;
    private int _roomAmount;
    private Client[] _clientList;
    private int[][] _roomPricePerDayList;
    private int[] _roomPrices;
    private readonly string _hotelName;
    private readonly string _hotelDesc;

    public Hotel(string hotelName, string hotelDesc, int roomAmount)
    {
        _hotelName = hotelName;
        _hotelDesc = hotelDesc;
        _roomAmount = roomAmount;
        _orderList = new OrderList(roomAmount);
    }
    
    public bool AddOrder(Client client, int room, DateTime orderStart, TimeSpan duration)
    {
        if (FindClient(client) == -1) return false;
        _orderList.AddOrder(client, room, orderStart, duration);
        return true;
    }

    public int FindOrder(Order order)
    {
        return  _orderList.FindOrder(order);
    }
    public bool AddOrder(Order order, int toRoom)
    {
        if (FindClient(order.GetClient()) == -1) return false;
        _orderList.AddOrder(order, toRoom);
        return true;
    }
    
    public bool RemoveOrder(Order order)
    {
        return _orderList.RemoveOrder(order);
    }
    
    public bool RemoveClient(Client client)
    {
        int index = Array.IndexOf(_clientList, client);

        if (index < 0)
        {
            return false;
        }

        Client[] newClientList = new Client[_clientList.Length - 1];

        for (int i = 0, j = 0; i < _clientList.Length; i++)
        {
            if (i != index)
            {
                newClientList[j] = _clientList[i];
                j++;
            }
        }

        _clientList = newClientList;

        return true;
    }

    public bool ChangeOrder(Client client, int room, DateTime orderStart, TimeSpan duration)
    {
        if (room < 1 || room > _roomAmount)
        {
            return false;
        }

        _orderList.ChangeOrder(client, room, orderStart, duration);
        return true;
    }

    public bool AddClient(Client client)
    {
        if (_clientList == null)
        {
            Array.Resize(ref _clientList, 1);
        }
        else
        {
            Array.Resize(ref _clientList, _clientList.Length + 1);
        }

        _clientList[_clientList.Length - 1] = client;

        return true;
    }

    public int FindClient(Client client)
    {
        if (_clientList == null) return -1;
        for (int i = 0; i < _clientList.Length; i++)
        {
            if (_clientList[i].Name == client.Name && _clientList[i].Surname == client.Surname)
            {
                return i;
            }
        }

        return -1;
    }

    public void ChangeClientData(int ind, string newName, string newSurname)
    {
        if (ind < 0 || ind >= _clientList.Length)
        {
            throw new ArgumentOutOfRangeException("Invalid client index");
        }
        
        _clientList[ind].Name = newName;
        _clientList[ind].Surname = newSurname;
    }

    public void GetClientData(int ind)
    {
        if (ind < 0 || ind >= _clientList.Length)
        {
            throw new ArgumentOutOfRangeException("Invalid client index");
        }
        Client client = _clientList[ind];
        Console.WriteLine($"Name: {client.Name}, Surname: {client.Surname}");
    }

    public void SortClientList(int typeOfData)
    {
        switch (typeOfData)
        {
            case 1:
                Array.Sort(_clientList, (x, y) => string.Compare(x.Name, y.Name));
                break;
            case 2:
                Array.Sort(_clientList, (x, y) => string.Compare(x.Surname, y.Surname));
                break;
            default:
                throw new ArgumentException("Invalid type of data");
        }
    }

    public void PrintClientList()
    {
        foreach (Client client in _clientList)
        {
            Console.WriteLine($"Name: {client.Name}, Surname: {client.Surname}");
        }
    }

    public void PrintAllOrders()
    {
        _orderList.PrintOrders();
    }

    public void PrintOrderAmount()
    {
        _orderList.PrintOrderAmnt();
    }

    public void PrintEmptyRooms(DateTime atDate)
    {
        _orderList.PrintEmpty(atDate);
    }
    public string GetName()
    {
        return _hotelName;
    }
    public string GetDesc()
    {
        return _hotelDesc;
    }

    public int GetRooms()
    {
        return _roomAmount;
    }

    public void SetRoomsPrice(int[] roomPrices, int[][] roomPriceArr)
    {
        _roomPrices = roomPrices;
        _roomPricePerDayList = roomPriceArr;
    }
    
    public int GetRoomPrice(int room)
    {
        for (int i = 0; i < _roomPricePerDayList.Length; i++)
        {
            for (int j = 0; j < _roomPricePerDayList[i].Length; j++)
            {
                if (_roomPricePerDayList[i][i] == room)
                {
                    return _roomPrices[i];
                }
            }
            
        }

        return 0;
    }
    
}