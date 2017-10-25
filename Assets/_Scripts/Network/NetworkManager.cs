using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour, WebSocketUnityDelegate {

    private static NetworkManager instance;
    private WebSocketUnity webSocket;
    private Decoder decoder;
    public Action<string, JSONObject> responceEvent;

    public void Connect()
    {
        NetworkHandler.Init(this);
        webSocket = new WebSocketUnity("localhost/socket.io/?EIO=4&transport=websocket", this);
        webSocket.Open();
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
