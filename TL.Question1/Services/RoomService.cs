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
    public class RoomService : IRoomServics
    {
        private IDictionary<string, Room> Rooms;
        private string[] AvailableRoomIds = Array.Empty<string>();

        public RoomService(IDictionary<string, Room> rooms)
        {
            Rooms = rooms;
            UpdateAvailableRoomIds(rooms);
        }

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

                    UpdateAvailableRoomIds(Rooms);

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

        private void UpdateAvailableRoomIds(IDictionary<string, Room> rooms)
        {
            var availableRooms = rooms.Where(r => r.Value.Status == RoomStatus.Available);
            if (availableRooms.Any())
            {
                AvailableRoomIds = availableRooms.ToDictionary(r => r.Key, r => r.Value).Keys.ToArray();
            }
        }

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

