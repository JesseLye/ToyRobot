# Toy Robot
A C# implementation of a famous coding exercise

## Requirements
- .NET 8.0
- Visual Studio 2022

## How To Run Application
1) Open Project in Visual Studio
2) Click **Build** > **Build Solution**
3) Open PowerShell
4) In PowerShell, navigate to directory **ToyRobot** > **bin** > **Debug** > **net8.0**
5) Create the file `Commands.txt`
6) Write your robot's commands (see examples below)
7) In PowerShell, run `./ToyRobot.exe -i="Commands.txt"`

## How To Run Tests
1) Open Project in Visual Studio
2) In Solution Explorer, right click on **ToyRobotTests**
3) Click **Run Tests**

## Commands
- `PLACE` - Places robot on a 5x5 Table
- `LEFT` - Rotate placed robot 90 degrees to the left
- `RIGHT` - Rotate placed robot 90 degrees to the right
- `MOVE` - Move robot in current facing direction
- `REPORT` - Report current location
```
PLACE 1,2,EAST
MOVE
RIGHT
MOVE
LEFT
MOVE
REPORT
```

The Robot cannot be placed off the 5x5 Table. When placed on the table, it will not move beyond it. All commands are ignored until a `PLACE` command is issued.
