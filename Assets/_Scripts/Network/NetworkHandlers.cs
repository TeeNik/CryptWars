using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;



public class ResponseObject
{
    public string eventName;
    public JSONObject jsonObject;
}

public class NetworkHandlers : MonoBehaviour {

    private static NetworkManager networkManager;
    private static List<ResponseObject> responseObjects = new List<ResponseObject>();

    public static void Init(NetworkManager n)
    {
        networkManager = n;
        networkManager.responceEvent = OnEvent;
    }

    public static void FixedUpdate()
    {
        for (int i = 0; i < responseObjects.Count; i++)
        {
            if (responseObjects[i] != null)
            {
                NetworkCommands eventType = responseObjects[i].eventName.ToEnum<NetworkCommands>();
                switch (eventType)
                {
                    case NetworkCommands.auth:
                        break;
                    case NetworkCommands.connect:

                        ConnectObject co = ConnectObject.FromJson<ConnectObject>(responseObjects[i].jsonObject.ToString());
                        networkManager.Send(NetworkCommands.connect.ToString(), )
                        break;
                }
                //StaticManager.ServerEvent.Publish(eventType);
                responseObjects[i] = null;
            }
        }
        responseObjects.RemoveAll(x => x == null);
    }

    public static void OnEvent(string ev, JSONObject json)
    {
        responseObjects.Add(
            new ResponseObject()
            {
                eventName = ev,
                jsonObject = json
            }
        );
    } 
}
