using System;
using TL.Question1.Models;

namespace TL.Question1.Interfaces
{
    public interface IRoomService
    {
        public IDictionary<string, Room> Print();
        public bool CheckIn();
        public bool CheckOut(string roomId);
        public bool CleanRoom(string roomId);
        public bool MarkRepair(string roomId);
        public bool RepairRoom(string roomId);
    }
}

