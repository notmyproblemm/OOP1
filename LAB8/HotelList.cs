using System;
namespace LAB8;

public class HotelList
{
    private Hotel[] _hotels = null;
    private int _hotelCounter = 0;

    public bool AddHotel(string name, string desc, int roomAmnt)
    {
        Array.Resize(ref _hotels, _hotelCounter + 1);
        _hotels[_hotelCounter] = new Hotel(name, desc, roomAmnt);
        _hotelCounter++;
        return true;
    }

    public bool RemoveHotel(int index)
    {
        _hotelCounter--;
        for (int i = index; i < _hotelCounter; i++)
        {
            _hotels[i] = _hotels[i + 1];
        }

        _hotels[_hotelCounter] = null;
        Array.Resize(ref _hotels, _hotelCounter );
        return true;
    }

    public bool FindHotel(string name)
    {
        foreach (var i in _hotels)
        {
            if (i.GetName() != name) continue;
            Console.WriteLine(i.GetName()); 
            Console.WriteLine(i.GetRooms());
            Console.WriteLine();
            Console.WriteLine(i.GetDesc());
            return true;
        }

        return false;
    }
    public void PrintHotelNames()
    {
        foreach (var i in _hotels)
        {
            Console.WriteLine(i.GetName()); 
        }
    }

    public Hotel GetHotel(int ind)
    {
        return _hotels[ind];
    }
    
}