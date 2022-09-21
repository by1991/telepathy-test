namespace TL.Question1.Tests;

public class TestCheckIn
{
    IRoomService _roomService;

    public TestCheckIn()
    {
        _roomService = new RoomService();
    }

    [Fact]
    public void TestCheckInSuccess()
    {
        var result = _roomService.CheckIn();
        Assert.True(result);
    }
}
