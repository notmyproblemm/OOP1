namespace LAB8;

public class Request
{
    private readonly Client _clientRequesting;
    private Order _orderRequested;
    private int _toRoom;

    public Request(Client clientRequesting, Order orderRequested, int toRoom)
    {
        _clientRequesting = clientRequesting;
        _orderRequested = orderRequested;
        _toRoom = toRoom;
    }
    public bool ChangeOrder(Hotel targetH,  int room, DateTime orderStart, TimeSpan duration)
    {
        return targetH.ChangeOrder( _clientRequesting,  room,  orderStart,  duration);
    }

    public bool SendTo(Hotel reqHotel)
    {
        reqHotel.AddClient(_clientRequesting);
        reqHotel.AddOrder(_orderRequested, _toRoom);
        return true;
    }

    public void CheckRoomVacancy( Hotel saidHotel, DateTime date)
    {
        saidHotel.PrintEmptyRooms(date);
    }
}