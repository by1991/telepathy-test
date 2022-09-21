namespace TL.Question1.Tests;

public class TestMarkRepair
{
    IRoomService _roomService;

    public TestMarkRepair()
    {
        _roomService = new RoomService();
    }

    [Fact]
    public void TestMarkRepairSuccess()
    {
        _roomService.CheckIn();
        _roomService.CheckOut("1A");
        var result = _roomService.MarkRepair("1A");
        Assert.True(result);
    }

    [Fact]
    public void TestMarkRepairFailure()
    {
        var result = _roomService.MarkRepair("1A");
        Assert.False(result);
    }
}
