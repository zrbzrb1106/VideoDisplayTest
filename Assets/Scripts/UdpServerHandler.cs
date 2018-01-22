using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class UdpServerHandler : MonoBehaviour
{
    //Socket socket;
    //Socket client;
    //EndPoint clientEnd;
    //IPEndPoint ipEnd;
    TcpClient client;
    IPAddress myIP;
    TcpListener server;

    byte[] buffer = new byte[2764800];
    //byte[] temp = new byte[2304];

    public static int flagShow;

    //Thread connectThread;
    public void InitSocket() {
        // udp
        //ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
        //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//
        //socket.Bind(ipEnd);
        //socket.Listen(5);
        try
        {
            myIP = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(myIP, 8888);
            server.Start();
            // udp client
            //IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);//
            //clientEnd = (EndPoint)sender;//
            

            flagShow = 0;
            client = server.AcceptTcpClient();
            
            //connectThread = new Thread(new ThreadStart(SocketReceive));
            //connectThread.Start();
        }
        catch (Exception e)
        {
            print("Exception: " + e);
        }
        finally {
            server.Stop();
        }
            
    } 
    public void SocketReceive()
    {
        try { InitSocket(); }
        catch (Exception e) { print("Exception: " + e); }
        finally { server.Stop(); }

        int k;

        NetworkStream stream = client.GetStream();
        while (true)
        {
            k = stream.Read(buffer, 0, buffer.Length);
        }
    }
    public void SetFlagShow(int flag) {
        flagShow = flag;
    }

    public int GetFlagShow() {
        return flagShow;
    }

    public Byte[] GetRecvStr()
    {
        return buffer;
    }
   
    public void SocketQuit()
    {
        client.Close();
    }
}
