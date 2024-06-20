namespace LAB8;

public class AdminPanel
{
    public bool SendOrderTo(Hotel reqHotel, Client client, Order order, int toRoom)
    {
        reqHotel.AddClient(client);
        reqHotel.AddOrder(order, toRoom);
        return true;
    }

    public bool ChangeOrder(Hotel targetH, Client client, int room, DateTime orderStart, TimeSpan duration)
    {
        return targetH.ChangeOrder( client,  room,  orderStart,  duration);
    }

    public void CheckRoomVacancy( Hotel saidHotel, DateTime date)
    {
        saidHotel.PrintEmptyRooms(date);
    }

    public void SortClientList(int typeOfData , Hotel targetH)
    {
        targetH.SortClientList(typeOfData);
    }

    public void PrintClientList(Hotel targetH)
    {
        targetH.PrintClientList();
    }

    public void PrintAllOrders(Hotel targetH)
    {
        targetH.PrintAllOrders();
    }

    public void PrintOrderAmount(Hotel targetH)
    {
        targetH.PrintOrderAmount();
    }

    public void PrintEmptyRooms(Hotel targetH, DateTime atDate)
    {
        targetH.PrintEmptyRooms(atDate);
    }
    public string GetName(Hotel targetH)
    {
        return targetH.GetDesc();
    }
    public string GetDesc(Hotel targetH)
    {
        return targetH.GetDesc();
    }

    public int GetRooms(Hotel targetH)
    {
        return targetH.GetRooms();
    }

    public void SetRoomsPrice(Hotel targetH, int[] roomPrices, int[][] roomPriceArr)
    {
        targetH.SetRoomsPrice(roomPrices,roomPriceArr);
    }
}