using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseObject
{
    public string eventName;
    public JSONObject jsonObject;
}

public class NetworkHandler{


    private static NetworkManager networkManager;
    private static List<ResponseObject> responseObjects = new List<ResponseObject>();

    public static void Init(NetworkManager manager)
    {
        networkManager = manager;
        networkManager.responceEvent = OnEvent;
    }

    public static void FixedUpdate()
    {
        for (int i = 0; i < responseObjects.Count; i++)
        {
            if (responseObjects[i] != null)
            {
                //NetworkCommands eventType = responseObjects[i].eventName.ToEnum<NetworkCommands>();
                switch (responseObjects[i].eventName)
                {
                    case "test":
                        Debug.Log("socket is here");
                        break;
                }
                responseObjects[i] = null;
            }
        }
        responseObjects.RemoveAll(x => x == null);
    }

    public static void OnEvent(string _eventName, JSONObject _jsonObject)
    {
        Debug.Log("OnEvent: " + _eventName);
        responseObjects.Add(
            new ResponseObject()
            {
                eventName = _eventName,
                jsonObject = _jsonObject
            }
        );
    }

    public static T ToEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}
