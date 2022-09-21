using TL.Question1.Interfaces;
using TL.Question1.Models;
using TL.Question1.Services;

// initialize room service
IRoomService roomService = new RoomService();

Console.WriteLine("-----------------------------");
Console.WriteLine("---------- Welcome ----------");
Console.WriteLine("-----------------------------");
Console.WriteLine();
Console.WriteLine("Please Select An Action Below:");
ShowMenu();

void ShowMenu()
{
    Console.WriteLine("-- Check In, Please Type 1");
    Console.WriteLine("-- Check Out, Please Type 2");
    Console.WriteLine("-- Clean Room, Please Type 3");
    Console.WriteLine("-- Mark Repair, Please Type 4");
    Console.WriteLine("-- Repair Room, Please Type 5");
    Console.WriteLine("-- List Available Rooms, Please Type 6");

    var action = Console.ReadLine();

    if (action == null)
    {
        Console.WriteLine("Please Type A Valid Action:");
        ShowMenu();
    }
    else
    {
        action = action.Replace(" ", "");
    }

    switch (action)
    {
        case "1":
            Console.WriteLine("... Check In ...");
            roomService.CheckIn();
            Console.WriteLine("-- Type 1 To Continue");
            Console.WriteLine("-- Type 2 To Exit");

            var step1 = Console.ReadLine();

            if (step1 != null && step1.Replace(" ", "") == "1")
            {
                Console.WriteLine("Please Select An Action Below:");
                ShowMenu();
            }
            else if (step1 != null && step1.Replace(" ", "") == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please Type A Valid Action:");
                ShowMenu();
            }

            break;
        case "2":
            Console.WriteLine("Please provide a room number:");
            var roomIdForCheckout = Console.ReadLine();
            if (roomIdForCheckout != null)
            {
                roomService.CheckOut(roomIdForCheckout);
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }

            break;
        case "3":
            Console.WriteLine("Please provide a room number:");
            var roomIdForClean = Console.ReadLine();
            if (roomIdForClean != null)
            {
                roomService.CleanRoom(roomIdForClean);
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            break;
        case "4":
            Console.WriteLine("Please provide a room number:");
            var roomIdForMarkRepair = Console.ReadLine();
            if (roomIdForMarkRepair != null)
            {
                roomService.MarkRepair(roomIdForMarkRepair);
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            break;
        case "5":
            Console.WriteLine("Please provide a room number:");
            var roomIdForRepair = Console.ReadLine();
            if (roomIdForRepair != null)
            {
                roomService.RepairRoom(roomIdForRepair);
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu();
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu();
                }
            }
            break;
        case "6":
            roomService.ListAvailableRooms();
            Console.WriteLine("-- Type 1 To Continue");
            Console.WriteLine("-- Type 2 To Exit");

            var step6 = Console.ReadLine();

            if (step6 != null && step6.Replace(" ", "") == "1")
            {
                Console.WriteLine("Please Select An Action Below:");
                ShowMenu();
            }
            else if (step6 != null && step6.Replace(" ", "") == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please Type A Valid Action:");
                ShowMenu();
            }

            break;
        default:
            Console.WriteLine("Please Type A Valid Action:");
            ShowMenu();
            break;
    }
}