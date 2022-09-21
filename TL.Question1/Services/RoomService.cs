using System;
using System.Net.NetworkInformation;
using TL.Question1.Enums;
using TL.Question1.Interfaces;
using TL.Question1.Models;

namespace TL.Question1.Services
{
    /// <summary>
    /// Class <c>RoomService</c> defines functions for hotel room operations.
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly IDictionary<string, Room> Rooms = new Dictionary<string, Room>();
        private List<string> AvailableRoomIds = new List<string>();
        string[] roomIds = {
            "1A", "1B", "1C", "1D", "1E",
            "2E", "2D", "2C", "2B", "2A",
            "3A", "3B", "3C", "3D", "3E",
            "4E", "4D", "4C", "4B", "4A"
        };

        public RoomService()
        {
            foreach (string id in roomIds)
            {
                Rooms.Add(new KeyValuePair<string, Room>(id, new Room(id)));
            }
            UpdateAvailableRoomIds(Rooms);
        }

        /// <summary>
        /// Method <c>Print</c> prints all rooms and status.
        /// </summary>
        public IDictionary<string, Room> Print()
        {
            Console.WriteLine("------ All rooms status: ------");
            foreach (KeyValuePair<string, Room> room in Rooms)
            {
                Console.WriteLine("Room Number: {0}, Status: {1}", room.Key, room.Value.Status.ToString());
            }
            Console.WriteLine("-------------------------------");

            return Rooms;
        }

        /// <summary>
        /// Method <c>ListAvailableRooms</c> prints all available rooms.
        /// </summary>
        public List<string> ListAvailableRooms()
        {
            if (AvailableRoomIds.Any())
            {
                Console.WriteLine("------ All available rooms: ------");
                foreach (var id in AvailableRoomIds)
                {
                    Console.WriteLine("Room Number: {0}", id);
                }
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("No available rooms!");
            }

            return AvailableRoomIds;
        }

        /// <summary>
        /// Method <c>CheckIn</c> checks in a guest.
        /// </summary>
        /// <returns>suceeded: true, failed: false</returns>
        public bool CheckIn()
        {
            if (AvailableRoomIds.Any())
            {
                var roomId = AvailableRoomIds.First();
                var room = Rooms[roomId];
                var newStatus = RoomStatus.Occupied;

                if (IsStatusValid(room.Status, newStatus))
                {
                    room.Status = newStatus;
                    var guest = new Guest();
                    room.GuestId = guest.GuestId;

                    Console.WriteLine("Checked in room: {0}", roomId);

                    AvailableRoomIds.RemoveAt(0);

                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to check in room: {0}, this room is not available", roomId);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("All rooms are occupied");
                return false;
            }
        }

        /// <summary>
        /// Method <c>CheckOut</c> checks out a room.
        /// </summary>
        /// <param name="roomId">id of the room to be checked out</param>
        /// <returns>suceeded: true, failed: false</returns>
        public bool CheckOut(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                var room = Rooms[roomId];
                var newStatus = RoomStatus.Vacant;

                if (IsStatusValid(room.Status, newStatus))
                {
                    room.Status = newStatus;
                    room.GuestId = null;
                    Console.WriteLine("Checked out room: {0}", roomId);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to check out room: {0}, this room is not occupied", roomId);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Room not found in this hotel, please provide a valid room number");
                return false;
            }
        }

        /// <summary>
        /// Method <c>CheckOut</c> cleans a room.
        /// </summary>
        /// <param name="roomId">id of the room to be cleaned</param>
        /// <returns>suceeded: true, failed: false</returns>
        public bool CleanRoom(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                var room = Rooms[roomId];
                var newStatus = RoomStatus.Available;

                if (IsStatusValid(room.Status, newStatus))
                {
                    room.Status = newStatus;

                    Console.WriteLine("Cleaned room: {0}", roomId);

                    UpdateAvailableRoomIds(Rooms);

                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to clean room: {0}, this room is not vacant", roomId);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Room not found in this hotel, please provide a valid room number");
                return false;
            }
        }

        /// <summary>
        /// Method <c>MarkRepair</c> marks room to be repaired.
        /// </summary>
        /// <param name="roomId">id of the room to be marked</param>
        /// <returns>suceeded: true, failed: false</returns>
        public bool MarkRepair(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                var room = Rooms[roomId];
                var newStatus = RoomStatus.Repair;

                if (IsStatusValid(room.Status, newStatus))
                {
                    room.Status = newStatus;
                    Console.WriteLine("Marked room: {0} to be repaired", roomId);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to mark room: {0} to be repaired, this room is not vacant", roomId);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Room not found in this hotel, please provide a valid room number");
                return false;
            }
        }

        /// <summary>
        /// Method <c>RepairRoom</c> repairs a room.
        /// </summary>
        /// <param name="roomId">id of the room to be repaired</param>
        /// <returns>suceeded: true, failed: false</returns>
        public bool RepairRoom(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                var room = Rooms[roomId];
                var newStatus = RoomStatus.Vacant;

                if (IsStatusValid(room.Status, newStatus))
                {
                    room.Status = newStatus;
                    Console.WriteLine("Repaired room: {0}", roomId);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to repair room: {0}, this room is not under repair status", roomId);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Room not found in this hotel, please provide a valid room number");
                return false;
            }
        }

        /// <summary>
        /// Method <c>UpdateAvailableRoomIds</c> get all room ids under Available status and assign to AvailableRoomIds.
        /// </summary>
        /// <param name="rooms">rooms dictionary which key is the room id and value is the room object</param>
        private void UpdateAvailableRoomIds(IDictionary<string, Room> rooms)
        {
            var availableRooms = rooms.Where(r => r.Value.Status == RoomStatus.Available);
            if (availableRooms.Any())
            {
                AvailableRoomIds = availableRooms.ToDictionary(r => r.Key, r => r.Value).Keys.ToList();
            }
        }

        /// <summary>
        /// Method <c>IsStatusValid</c> checks whether the next stattus is valid or not.
        /// </summary>
        /// <param name="currentStatus">current status of the room</param>
        /// <param name="nextStatus">next status of the room</param>
        /// <returns>status valid: true, status invalid: false</returns>
        private bool IsStatusValid(RoomStatus currentStatus, RoomStatus nextStatus)
        {
            switch (currentStatus)
            {
                case RoomStatus.Available:
                    return nextStatus == RoomStatus.Occupied ? true : false;
                case RoomStatus.Occupied:
                    return nextStatus == RoomStatus.Vacant ? true : false;
                case RoomStatus.Vacant:
                    var validStatus = new RoomStatus[] { RoomStatus.Available, RoomStatus.Repair };
                    return validStatus.Contains(nextStatus) ? true : false;
                case RoomStatus.Repair:
                    return nextStatus == RoomStatus.Vacant ? true : false;
                default:
                    return false;

            }
        }
    }
}

