namespace TL.Question1.Tests;

public class TestRepairRoom
{
    IRoomService _roomService;

    public TestRepairRoom()
    {
        _roomService = new RoomService();
    }

    [Fact]
    public void TestRepairRoomSuccess()
    {
        _roomService.CheckIn();
        _roomService.CheckOut("1A");
        _roomService.MarkRepair("1A");
        var result = _roomService.RepairRoom("1A");
        Assert.True(result);
    }

    [Fact]
    public void TestRepairRoomFailure()
    {
        var result = _roomService.RepairRoom("1A");
        Assert.False(result);
    }
}
