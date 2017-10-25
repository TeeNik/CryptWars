//----------------------------------------------
// WebSocketUnity
// Copyright (c) 2015, Jonathan Pavlou
// All rights reserved
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

#if UNITY_IPHONE
public class WebSocketUnityiOS : IWebSocketUnityPlatform{
	private Encoder encoder;
	private Decoder decoder;

	[DllImport ("__Internal")]
	private static extern void _Create(string url, string gameObjectName);

	[DllImport ("__Internal")]
	private static extern void _Connect();

	[DllImport ("__Internal")]
	private static extern void _Close();

	[DllImport ("__Internal")]
	private static extern void _Send(string message);

	[DllImport ("__Internal")]
	private static extern void _SendData(byte[] message, uint size);

	[DllImport ("__Internal")]
	private static extern bool _IsOpened();

	// Constructor
	// param : url of your server (for example : ws://echo.websocket.org)
	// param : gameObjectName name of the game object who will receive events
	public WebSocketUnityiOS(string url, string gameObjectName){
		encoder = new Encoder();
		decoder = new Decoder();
		_Create(url, gameObjectName);
	}
	
	#region Basic features
	
	// Open a connection with the specified url
	public void Open(){
		_Connect();
	}
	
	// Close the opened connection
	public void Close(){
		_Close();
	}

	public void DropConnection(){
		_Close();
	}
	
	// Check if the connection is opened
	public bool IsOpened(){
//return false;
		return _IsOpened();
	}
	
	// Send a message through the connection
	// param : message is the sent message
	public void Send(string message){
		_Send(message);
	}
	
	// Send a message through the connection
	// param : data is the sent byte array message
	public void Send(byte[] data){
		_SendData(data, (uint)data.Length);
	}
	
	public void Send(string eventName, JSONObject data){
		Send(encoder.Encode(new Packet(eventName, data)));
	}
	
	#endregion
	

}
#else
public class WebSocketUnityiOS {}
#endif // UNITY_IOS
