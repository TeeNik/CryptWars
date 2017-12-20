using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using Newtonsoft.Json;
using UnityEngine;



public class ResponseObject
{
    public string EventName;
    public JSONObject JsonObject;
}

public class NetworkHandlers : MonoBehaviour {

    private static NetworkManager _networkManager;
    private static List<ResponseObject> responseObjects = new List<ResponseObject>();

    public static void Init(NetworkManager n)
    {
        _networkManager = n;
        _networkManager.responceEvent = OnEvent;
    }

    public static void FixedUpdate()
    {
        for (int i = 0; i < responseObjects.Count; i++)
        {
            if (responseObjects[i] != null)
            {
                NetworkCommands eventType = responseObjects[i].EventName.ToEnum<NetworkCommands>();
                switch (eventType)
                {
                    case NetworkCommands.auth:
                        break;
                    case NetworkCommands.connect:

                        ConnectObject co = ConnectObject.FromJson<ConnectObject>(responseObjects[i].JsonObject.ToString());
                        //networkManager.Send(NetworkCommands.connect.ToString(), ConnectObject.FromJson<ConnectObject>(re)
                        print(responseObjects[i].JsonObject.ToString());
                        print(co.id + "  " + co.ok);
                        break;
                    case NetworkCommands.startBattle:
                        print("Start Battle");
                        break;
                    case NetworkCommands.spawnWarrior:

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
        print("On event " + ev);
        responseObjects.Add(
            new ResponseObject()
            {
                EventName = ev,
                JsonObject = json
            }
        );
    } 

    private void SpawnEvent(ResponseObject r)
    {
        WarriorObject w = WarriorObject.FromJson<WarriorObject>(r.JsonObject.ToString());
        EventHandler.Instance.SpawnEvent(w);
    }
}
