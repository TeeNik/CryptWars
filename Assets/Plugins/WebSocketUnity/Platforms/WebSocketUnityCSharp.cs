//----------------------------------------------
// WebSocketUnity
// Copyright (c) 2015, Jonathan Pavlou
// All rights reserved
//----------------------------------------------

using UnityEngine;
using System.Collections;

#if (!UNITY_IPHONE && !UNITY_ANDROID && !UNITY_WEBGL) || UNITY_EDITOR
using WebSocketCSharp;

public class WebSocketUnityCSharp : IWebSocketUnityPlatform {
	private Encoder encoder;
	private Decoder decoder;

	private WebSocket mWebSocket;
	private WebSocketUnityDelegate mDelegateObject;
	
	// Constructor
	// param : url of your server (for example : ws://echo.websocket.org)
	// param : gameObjectName name of the game object who will receive events
	public WebSocketUnityCSharp(string url, WebSocketUnityDelegate delegateObject){
		encoder = new Encoder();
		decoder = new Decoder();

		mWebSocket =  new WebSocket(url);
		mDelegateObject = delegateObject;
		
		// Setting WebSocket events 
		mWebSocket.OnOpen += OnConnected;
		mWebSocket.OnMessage += OnReceivedMessage;
		mWebSocket.OnError += OnError;
		mWebSocket.OnClose += OnDisconnected;
	}
	
	#region Basic features
	
	// Open a connection with the specified url
	public void Open(){
		mWebSocket.ConnectAsync();
	}
	
	// Close the opened connection
	public void Close(){
		mWebSocket.CloseAsync();
	}

    public void DropConnection()
    {
        mWebSocket.Close();
    }
	
	// Check if the connection is opened
	public bool IsOpened(){
		return mWebSocket.ReadyState==WebSocketState.Open;
	}
	
	// Send a message through the connection
	// param : message is the sent message
	public void Send(string message){
		mWebSocket.Send(message);
	}
	
	// Send a message through the connection
	// param : data is the sent byte array message
	public void Send(byte[] data){
		mWebSocket.Send(data);
	}

	public void Send(string eventName, JSONObject data)
	{
		mWebSocket.Send(encoder.Encode(new Packet(eventName, data)));
	}
	
	
	#endregion
	
	# region Internal Delegate
	
	private void OnConnected(object sender, System.EventArgs e){
		mDelegateObject.OnWebSocketUnityOpen(sender.ToString());
	}
	
	private void OnDisconnected(object sender, CloseEventArgs e){
		mDelegateObject.OnWebSocketUnityClose(e.Reason);
	}
	
	private void OnReceivedMessage(object sender, MessageEventArgs e){
		if(e.Type==Opcode.Binary){
			mDelegateObject.OnWebSocketUnityReceiveData(e.RawData);
		}else{
			var data = e.Data;
			mDelegateObject.OnWebSocketUnityReceiveMessage(data);
			MyDecodeStringMessage(data);
		}
	}

	private void MyDecodeStringMessage(string data)
	{
		Packet packet = decoder.Decode(data);
	    //Debug.Log("MyDecodeStringMessage" + packet.socketPacketType.ToString() + " " + packet.enginePacketType.ToString());
		if (packet != null && packet.socketPacketType == SocketPacketType.EVENT && packet.enginePacketType == EnginePacketType.MESSAGE)
		{
			SocketIOEvent sevent = decoder.Parse(packet.json);
			mDelegateObject.OnWebSocketUnityReceiveEvent(sevent.name, sevent.data);
		}
	}
	
	private void OnError(object sender, ErrorEventArgs e){
		mDelegateObject.OnWebSocketUnityError(e.Message);
	}
	
	#endregion
	
}
#else
public class WebSocketUnityCSharp {}
#endif // #if (!UNITY_IPHONE && !UNITY_ANDROID && !UNITY_WEBGL) || UNITY_EDITOR