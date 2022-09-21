namespace TL.Question1.Tests;

public class TestCleanRoom
{
    IRoomService _roomService;

    public TestCleanRoom()
    {
        _roomService = new RoomService();
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
