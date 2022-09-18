using System;
using TL.Question1.Enums;

namespace TL.Question1.Models
{
    /// <summary>
    /// Class <c>Room</c> models the hotel room.
    /// </summary>
    public class Room
    {
        public string RoomId { get; set; }
        public RoomStatus Status { get; set; }
        public int? GuestId { get; set; } // Guest who is assigned the room, assume one room fits max one guest

        public Room(string id)
        {
            RoomId = id;
            Status = RoomStatus.Available; // Assume initial status is Available
            GuestId = null;
        }
    }
}

