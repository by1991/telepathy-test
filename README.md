# Telepathy Labs Technical Assessment

## Prerequisites
- Install .Net 6 SDK or later

## Question 1
### Solutions
- Enums/RoomStatus.cs defines 4 status: Available, Occupied, Vacant, Repair
- Models/Guest.cs defines the guest object for the hotel
- Models/Room.cs defines hotel room object
- Interfaces/IRoomServices.cs is an interface that defines the following methods:
  - Print() will print all rooms' number and status
  - ListAvailableRooms() will list all available room numbers
  - CheckIn() will check in the nearest available room in O(1) time complexity
  - CheckOut() will check out the room given a room number
  - CleanRoom() will clean the room given a room number
  - MarkRepair() will mark the room for repair given a room number
  - RepairRoom() will repair the room given a room number
- Services/RoomService.cs implements IRoomServices interface
  - Uses a Dictionary to store the room number and Room object in order 
  - Uses a string List to store available room numbers, and it will be updated when a room becomes available
- Program.cs initializes RoomService and interacts with the user
### Run Program
Run this command under TL.Question1 folder:
`dotnet run`

## Question 2
### Solutions
> Use AVL tree data structure to store a large set of random numbers, to inset and to look up a number, because AVL tree is more strictly balanced given a large set of data and it has faster look up operations compared with red-black tree.
- Node.cs defines a node object and stores children nodes (Left and Right)
- AVL.cs defines an AVL tree structure that can store integers
  - AddData(int data) inserts a number into the AVL tree with worst case O(log n) time complexity
  - SearchData(int key) searches for a number inside the AVL tree with worst case O(log n) time complexity
  - Print() uses in order traversal and prints all the number in ascending order with worst case O(log n) time complexity
- Program.cs initializes the AVL tree and interacts with the user
### Run Program
Run this command under TL.Question2 folder:
`dotnet run`
### References:
- https://www.geeksforgeeks.org/avl-tree-set-1-insertion/
- https://en.wikipedia.org/wiki/AVL_tree

## Run Unit Tests
Run `dotnet test` under the root folder