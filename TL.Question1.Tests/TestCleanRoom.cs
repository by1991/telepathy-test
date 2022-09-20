﻿namespace TL.Question1.Tests;

public class TestCleanRoom : IDisposable
{
    IDictionary<string, Room> rooms = new Dictionary<string, Room>();
    IRoomService _roomService;

    public TestCleanRoom()
    {
        // initialize hotel rooms
        string[] roomIds = {
            "1A", "1B", "1C", "1D", "1E",
            "2E", "2D", "2C", "2B", "2A",
            "3A", "3B", "3C", "3D", "3E",
            "4E", "4D", "4C", "4B", "4A"
        };

        foreach (string id in roomIds)
        {
            rooms.Add(new KeyValuePair<string, Room>(id, new Room(id)));
        }

        _roomService = new RoomService(rooms);
    }

    public void Dispose()
    {
        rooms = new Dictionary<string, Room>();
        _roomService = new RoomService(rooms);
    }

    [Fact]
    public void TestCleanRoomSuccess()
    {
        _roomService.CheckIn();
        _roomService.CheckOut("1A");
        var result = _roomService.CleanRoom("1A");
        Assert.True(result);
    }

    [Fact]
    public void TestCleanRoomFailure()
    {
        var result = _roomService.CleanRoom("1A");
        Assert.False(result);
    }
}