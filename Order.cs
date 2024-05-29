namespace LAB8;

public class Order
{
    private readonly Client _client;
    private DateTime _startDate;
    private TimeSpan _duration;
    
    public Order(Client client, DateTime startDate, TimeSpan duration)
    {
        _client = client;
        _startDate = startDate;
        _duration = duration;
    }

    public void ChangeTimespan(TimeSpan newDuration)
    {
        _duration = newDuration;
    }

    public void ChangeStartDate(DateTime newStartDate)
    {
        _startDate = newStartDate;
    }
    public Client GetClient()
    {
        return _client;
    }
    public DateTime GetOrderEndDate()
    {
        return _startDate + _duration;
    }

    public DateTime GetStartDate()
    {
        return _startDate;
    }

    public TimeSpan GetDuration()
    {
        return _duration;
    }
}