using TL.Question1.Interfaces;
using TL.Question1.Models;
using TL.Question1.Services;

// initialize hotel rooms
string[] roomIds = {
    "1A", "1B", "1C", "1D", "1E",
    "2E", "2D", "2C", "2B", "2A",
    "3A", "3B", "3C", "3D", "3E",
    "4E", "4D", "4C", "4B", "4A"
};

IDictionary<string, Room> rooms = new Dictionary<string, Room>();

foreach (string id in roomIds)
{
    rooms.Add(new KeyValuePair<string, Room>(id, new Room(id)));
}

IRoomServics roomService = new RoomService(rooms);

roomService.CheckIn();
roomService.CheckOut("2A");
roomService.CheckIn();
roomService.CheckOut("1B");
roomService.MarkRepair("1B");
roomService.RepairRoom("1B");
roomService.CleanRoom("1B");
roomService.CheckIn();
roomService.MarkRepair("2A");
roomService.RepairRoom("2A");
roomService.CleanRoom("2A");
roomService.Print();
