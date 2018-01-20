using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.Network;
using Assets._Scripts.System;
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
                    case NetworkCommands.Auth:
                        break;
                    case NetworkCommands.Connect:
                        ConnectObject co = ConnectObject.FromJson<ConnectObject>(responseObjects[i].JsonObject.ToString());
                        NetworkManager.Instance.Send(NetworkCommands.Connect.ToString(), responseObjects[i].JsonObject);
                        break;
                    case NetworkCommands.StartBattle:
                        print("Start Battle");
                        break;
                    case NetworkCommands.SpawnWarrior:
                        SpawnEvent(responseObjects[i]);
                        break;
                    case NetworkCommands.Move:
                        MoveEvent(responseObjects[i]);
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

    public static void StartBattleEvent(ResponseObject r)
    {
        BattleFrameObject co = CallbackObject.FromJson<BattleFrameObject>(r.JsonObject.ToString());
        StaticManager.Instance.Player.Init(co.player);
    }

    private static void SpawnEvent(ResponseObject r)
    {
        WarriorObject w = WarriorObject.FromJson<WarriorObject>(r.JsonObject.ToString());
        EnemySpawner.Instance.SpawnWarrior(w);
    }

    private static void MoveEvent(ResponseObject r)
    {
        WarriorObject w = WarriorObject.FromJson<WarriorObject>(r.JsonObject.ToString());
        WarriorManager.Instance.SyncWarrior(w);
    }
}
