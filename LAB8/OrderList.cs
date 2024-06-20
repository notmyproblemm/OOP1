namespace LAB8;

public class OrderList
{
    private Order[][] _orderList;

    public OrderList(int rooms)
    {
        Array.Resize(ref _orderList, rooms);
    }
    public int FindOrder(Order order)
    {
        for (int row = 0; row < _orderList.Length; row++)
        {
            if (_orderList[row] == null) continue;
            for (int i = 0; i < _orderList[row].Length; i++)
            {
                if (_orderList[row][i].GetClient().Name == order.GetClient().Name && _orderList[row][i].GetClient().Surname == order.GetClient().Surname && _orderList[row][i].GetDuration() == order.GetDuration() )
                {
                    return i;
                }
            }

        }

        return -1;
    }

    public bool RemoveOrder(Order order)
    {
        for (int row = 0; row < _orderList.Length; row++)
        {
            if (_orderList[row] == null) continue;
            for (int i = 0; i < _orderList[row].Length; i++)
            {
                if (_orderList[row][i].GetClient().Name == order.GetClient().Name && _orderList[row][i].GetDuration() == order.GetDuration() )
                {
                    Order[] newOrderList = new Order[_orderList[row].Length - 1];

                    for (int j = 0, k = 0; j < _orderList[row].Length; j++)
                    {
                        if (j != i)
                        {
                            newOrderList[k] = _orderList[row][j];
                            k++;
                        }
                    }

                    _orderList[row] = newOrderList;
                    return true;
                }
            }

        }

        return false;
    }
    
    public bool AddOrder(Client client, int room, DateTime orderStart, TimeSpan duration)
    {
        Order newOrder = new Order(client, orderStart, duration);
        
        int roomIndex = room - 1;
        if (_orderList[roomIndex] == null)
        {
            Array.Resize(ref _orderList[roomIndex], 1 );
        }
        else
        {
            Array.Resize(ref _orderList[roomIndex], _orderList[roomIndex].Length + 1);
        }
        _orderList[roomIndex][_orderList[roomIndex].Length - 1] = newOrder;
        if (!CheckOrderValidity())
        {
            RemoveOrder(newOrder);
            return false;
        }

        return true;
    }

    public bool CheckRoomForVacancy(int room, DateTime date)
    {
        if (_orderList[room] == null) return true;
        foreach (var order in _orderList[room])
        {
            if (order.GetStartDate() < date && date < order.GetOrderEndDate())
            {
                return false;
            }
        }

        return true;
    }
    
    public bool AddOrder(Order order, int toRoom)
    {
        if (toRoom > _orderList.Length) return false;
        _orderList[toRoom].Append(order);
        if (!CheckOrderValidity())
        {
            RemoveOrder(order);
            return false;
        }
        return true;
    }
    
    public bool ChangeOrder(Client client, int room, DateTime orderStart, TimeSpan duration)
    {
        int roomIndex = room - 1;
        for (int i = 0; i < _orderList[roomIndex].Length; i++)
        {
            if (_orderList[roomIndex][i].GetClient() == client)
            {
                _orderList[roomIndex][i].ChangeStartDate(orderStart);
                _orderList[roomIndex][i].ChangeTimespan(duration);
                return true;
            }
        }
        

        return false;
    }
    
    
    public void PrintOrders()
    {
        for (var row = 0; row < _orderList.Length; row++)
        {
            Console.Write("Row ");
            Console.WriteLine(row);
            if (_orderList[row] == null) continue;
            foreach (var order in _orderList[row])
            {
                Console.WriteLine(order.GetClient().Name);
                Console.WriteLine(order.GetClient().Surname);
                Console.WriteLine(order.GetStartDate());
                Console.WriteLine(order.GetDuration());
            }
        }
    }

    public bool CheckOrderValidity()
    {
        for (int i = 0; i < _orderList.Length; i++)
        {
            if (_orderList[i] != null) Array.Sort(_orderList[i], (order, order1) => order.GetStartDate().CompareTo(order1.GetStartDate()));
        }

        for (int i = 0; i < _orderList.Length; i++)
        {
            if (_orderList[i] == null) continue;
            for (int j = 0; j < _orderList[i].Length - 1; j++)
            {
                if (_orderList[i][j].GetOrderEndDate() > _orderList[i][j + 1].GetStartDate())
                {
                    return false;
                }
            }
        }
        
        return true;
    }

    public void PrintOrderAmnt()
    {
        var sum = 0;
        foreach (var row in _orderList)
        {
            if (row == null) continue;
            sum += row.Length;
        }
        Console.WriteLine(sum);
    }

    public void PrintEmpty(DateTime atDate)
    {
        for (int i = 0; i < _orderList.Length; i++)
        {
            if (CheckRoomForVacancy(i, atDate))
            {
                Console.WriteLine("Room "+ i + " is empty");
            }
        }
    }
}