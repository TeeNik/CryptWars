using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour, WebSocketUnityDelegate {

    private static NetworkManager instance;
    private WebSocketUnity webSocket;
    private Decoder decoder;
    public Action<string, JSONObject> responceEvent;

    public void Awake()
    {
        instance = this;
        instance.Connect();
    }

    public void Connect()
    {
        NetworkHandler.Init(this);
        webSocket = new WebSocketUnity("ws://localhost:3735/socket.io/?EIO=4&transport=websocket", this);
        webSocket.Open();
        /*Debug.Log(webSocket.IsOpened());
        TestObject test = new TestObject();
        test.str = "123123123";
        instance.Send("test", new JSONObject(test.GetJson()));*/
        //Debug.Log("Connect");
    }

    public void Send(string eventName, JSONObject data)
    {
        webSocket.Send(eventName, data);
    }

    public void OnWebSocketUnityClose(string reason)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityError(string error)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityOpen(string sender)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityReceiveData(byte[] data)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityReceiveDataOnMobile(string base64EncodedData)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityReceiveEvent(string eventName, JSONObject data)
    {
        throw new NotImplementedException();
    }

    public void OnWebSocketUnityReceiveMessage(string message)
    {
        throw new NotImplementedException();
    }
}
