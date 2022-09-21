# TL Technical Assessment

## Prerequisites
- .Net 6 SDK or later

## Question 1
### Solutions
- Enums/RoomStatus.cs defines 4 status: Available, Occupied, Vacant, Repair
- Models/Guest.cs defines the guest object for the hotel
- Models/Room.cs defines hotel room object
- Interfaces/IRoomServices.cs is an interface that defines the following methods:
  - Print() will print all rooms' number and status
  - ListAvailableRooms() will list all available room numbers
  - CheckIn() will check in the nearest available room and check in the guest (in O(1) time complexity)
- Services/RoomService.cs implements IRoomServices interface, uses a Dictionary to store the room number and Room object and uses a string List to store available room numbers
- Program.cs initialise all rooms in order with Available status and interacts with the user
### Run Program
Run this command under TL.Question1 folder:
`dotnet run`

## Question 2
### Run Program
Run this command under TL.Question2 folder:
`dotnet run`
### References:
- https://www.geeksforgeeks.org/avl-tree-set-1-insertion/
- https://en.wikipedia.org/wiki/AVL_tree

## Run Unit Tests
Run `dotnet test` under the root folder