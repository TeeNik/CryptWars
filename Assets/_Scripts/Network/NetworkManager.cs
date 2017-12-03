using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class NetworkManager : MonoBehaviour, WebSocketUnityDelegate
{

    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;
    private WebSocketUnity websocket;
    public Action<string, JSONObject> responceEvent;

    private static NetworkManager instance;
    public static NetworkManager getInstance()
    {
        return instance;
    }

    void Start () {
        instance = this;
        Connect();
	}
	
	public class TestObject
    {
        public int num;

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [ContextMenu("Connect")]
    private void Connect()
    {
        NetworkHandlers.Init(this);
        websocket = new WebSocketUnity("ws://localhost:3735/socket.io/?EIO=4&transport=websocket", this);
        websocket.Open();
    }

    public void SendTest(int n)
    {
        TestObject t = new TestObject();
        t.num = n;
        JSONObject json = new JSONObject(t.GetJson());
        Send("test", json);
    }

    public void Send(string eventName, JSONObject data)
    {
        websocket.Send(eventName, data);
    }

    public void OnWebSocketUnityOpen(string sender)
    {
        print(sender);
    }

    public void OnWebSocketUnityClose(string reason)
    {
        print(reason);
    }

    public void OnWebSocketUnityReceiveMessage(string message)
    {
        print(message);
    }

    public void OnWebSocketUnityReceiveDataOnMobile(string base64EncodedData)
    {
        print(base64EncodedData);
    }

    public void OnWebSocketUnityReceiveData(byte[] data)
    {
        print(data);
    }

    public void OnWebSocketUnityReceiveEvent(string eventName, JSONObject data)
    {
        print(eventName + data.str);
        responceEvent.Invoke(eventName, data);
    }

    public void OnWebSocketUnityError(string error)
    {
        print(error);
    }
}
