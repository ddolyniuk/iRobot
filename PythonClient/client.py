import socket
"""Atm we just connect to our C# server,
and print data received. """

#need to separate into new class files later

def ConnectToServer(ip, port):
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect((ip, port))
    return s;

def StartListening(sock):
    while True:
        data = sock.recv(1024)
        if data != None:
            HandlePacket(data)

""" Here we handle the packets
being sent to the client using 
basic string manipulators. """
def HandlePacket(packet):
    print("Received Packet: ") #just a placeholder
    print(packet)              #later we can make a switch for opcode etc

def Main():
    sock = ConnectToServer('127.0.0.1', 8422)
    StartListening(sock)

Main();