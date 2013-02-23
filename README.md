iRobot
======
Right now this is just a barebones TCP server in C#.
Write text in the console window and hit enter.
This will send the packets to our listening python
socket. Python will then print the output. We need to
add handlers later for specific outputs, i.e.

```python
""" here's some pseudo python (still learning it)
for a packet handler """
packet = "1E|10|10" # test packet
data = packet.split("|")
switch data[0] :
    case "1E": #move forward opcode
        MoveForward(data[1], data[2]); //move forward 10 meters at 10 speed 
        break
    case "2E":
        break
    default:
        break

    
```