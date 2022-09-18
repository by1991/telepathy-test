using System;

namespace TL.Question1.Models
{
    /// <summary>
    /// Class <c>Room</c> models the guest for the hotel.
    /// </summary>
    public class Guest
    {
        public int GuestId { get; set; }

        public Guest()
        {
            // Generates a random ID
            var random = new Random();
            GuestId = random.Next();
        }
    }
}

