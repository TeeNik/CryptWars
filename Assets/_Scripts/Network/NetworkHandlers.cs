using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.Network;
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
                        NetworkManager.Instance.Send(NetworkCommands.connect.ToString(), responseObjects[i].JsonObject);
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
        EnemySpawner.Instance.SpawnWarrior(w);
    }
}
