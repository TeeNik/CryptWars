//----------------------------------------------
// WebSocketUnity
// Copyright (c) 2015, Jonathan Pavlou
// All rights reserved
//----------------------------------------------

using UnityEngine;
using System.Collections;


// Each platform has to implement this interface
public interface IWebSocketUnityPlatform{
	void Open();
	void Close();
    void DropConnection();
	bool IsOpened();
	void Send(string message);
	void Send(byte[] data);
	void Send(string eventName, JSONObject data);
}

public class WebSocketUnity {

	// URL used for the connection
	private string mUrl;
	// Websocket implementation
	private IWebSocketUnityPlatform mPlatformWebSocket;

	private Encoder encoder;
	private Decoder decoder;

	// Constructor
	// param : url of your server (for example : ws://echo.websocket.org)
	// param : eventHandler MonoBehaviour who will receive event; it has to extend WebSocketUnityDelegate
	public WebSocketUnity(string url, MonoBehaviour eventHandler){
		encoder = new Encoder();
		decoder = new Decoder();

		// need to check if the Game Object implements WebSocketUnityDelegate
		if((eventHandler as WebSocketUnityDelegate) == null){
			Debug.LogError("WebSocketUnity : your GameObject "+eventHandler.name+" has to extend WebSocketUnityDelegate !");
			return;
		}
		mUrl = url;
#if UNITY_IPHONE && !UNITY_EDITOR
		mPlatformWebSocket = new WebSocketUnityiOS(mUrl, eventHandler.gameObject.name);
#elif UNITY_ANDROID && !UNITY_EDITOR
		mPlatformWebSocket = new WebSocketUnityAndroid(mUrl, eventHandler.gameObject.name);
#elif UNITY_WEBGL && !UNITY_EDITOR
		mPlatformWebSocket = new WebSocketUnityWebGL(mUrl,  eventHandler as WebSocketUnityDelegate, eventHandler.gameObject.name);
#else
		mPlatformWebSocket = new WebSocketUnityCSharp(mUrl, eventHandler as WebSocketUnityDelegate);
#endif
	}	

#region Basic features

	// Open a connection with the specified url
	public void Open(){
		mPlatformWebSocket.Open();
	}
	
	// Close the opened connection
	public void Close(){
		mPlatformWebSocket.Close();
	}

    public void DropConnection()
    {
        mPlatformWebSocket.DropConnection();
    }
	
	// Check if the connection is opened
	public bool IsOpened(){
		if(mPlatformWebSocket==null)
			return false;
		return mPlatformWebSocket.IsOpened();
	}
	
	// Send a message through the connection
	// param : message is the sent string message
	public void Send(string message){
		mPlatformWebSocket.Send(message);
	}

	public void Send(string eventName, JSONObject data){
		mPlatformWebSocket.Send(encoder.Encode(new Packet(eventName, data)));
	}
	
	// Send dataa through the connection
	// param : data is the sent byte array message
	private void Send(byte[] data){
		mPlatformWebSocket.Send(data);
	}
	
	public byte[] decodeBase64String(string encodedData){
		return System.Convert.FromBase64String(encodedData);
	}

#endregion
		
}

