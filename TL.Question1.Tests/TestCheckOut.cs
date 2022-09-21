namespace TL.Question1.Tests;

public class TestCheckOut
{
    IRoomService _roomService;

    public TestCheckOut()
    {
        _roomService = new RoomService();
    }

    [Fact]
    public void TestCheckOutSuccess()
    {
        _roomService.CheckIn();
        var result = _roomService.CheckOut("1A");
        Assert.True(result);
    }

    [Fact]
    public void TestCheckOutFailure()
    {
        var result = _roomService.CheckOut("1A");
        Assert.False(result);
    }
}
