using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using UnityEngine;

public class VideoDisplayTest : MonoBehaviour {

    int width = 1280;
    int height = 720;

    UdpServerHandler udpServer;
    Thread connectThread;
    Texture2D tex;
    int i = 0;
    // Use this for initialization
    void Start () {

        tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        udpServer = gameObject.AddComponent<UdpServerHandler>();
        connectThread = new Thread(new ThreadStart(udpServer.SocketReceive));
        connectThread.Start();

    }

    //Update is called once per frame

    void Update()
    {
        //IntPtr ptr = getFrame();
        //Marshal.Copy(ptr, buffer, 0, buffer.Length);
        //tex.LoadRawTextureData(buffer);
        //tex.Apply();
        //GetComponent<Renderer>().material.mainTexture = tex;

        byte[] picBytes = udpServer.GetRecvStr();
        tex.LoadRawTextureData(picBytes);
        tex.Apply();
        GetComponent<Renderer>().material.mainTexture = tex;
            
        udpServer.SetFlagShow(0);
    }
    private void OnApplicationQuit()
    {
        connectThread.Interrupt();
        connectThread.Abort();

        udpServer.SocketQuit();
    }
}
