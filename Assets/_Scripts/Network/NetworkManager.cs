using System;
using System.IO;
using System.Net.Sockets;
using Assets._Scripts.System;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets._Scripts.Network
{
    public class NetworkManager : MonoBehaviour, WebSocketUnityDelegate
    {

        private TcpClient socket;
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;
        private WebSocketUnity websocket;
        public Action<string, JSONObject> responceEvent;

        private bool isAuth = true;

        public static NetworkManager Instance;

        void Start () {
            Instance = this;
            Connect();       
        }

        public void FixedUpdate()
        {
            if (isAuth)
            {
                Auth();
                isAuth = false;
            }
            NetworkHandlers.FixedUpdate();
        }


        public void Auth()
        {
            print("id: " + PlayerPrefs.GetInt("id"));
            if(PlayerPrefs.GetInt("id") != 0)
            {
                int id = UnityEngine.Random.Range(10000000, 90000000);
                PlayerPrefs.SetInt("id", id);
                StaticManager.Instance.Player.Id = id;
                SendAuth(id, "Yanchik");
            } else
            {
                int id = PlayerPrefs.GetInt("id");
                StaticManager.Instance.Player.Id = id;
                SendAuth(id, "Yanchik");
            }
        }

        private void SendAuth(int id, string nickname)
        {
            AccountObject ao = new AccountObject(id, nickname);
            JSONObject js = new JSONObject(ao.GetJson());
            websocket.Send(NetworkCommands.auth.ToString(), js);
        }

        public class TestObject
        {
            public int num;

            public string GetJson()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }

        [ContextMenu("Connect")]
        private void Connect()
        {
            NetworkHandlers.Init(this);
            websocket = new WebSocketUnity("ws://localhost:3735/socket.io/?EIO=4&transport=websocket", this);
            websocket.Open();
        
            //websocket.Send(NetworkCommands.auth.ToString(), )
        }

        public void SendTest(int n)
        {
            TestObject t = new TestObject();
            t.num = n;
            JSONObject json = new JSONObject(t.GetJson());
            Send("test", json);
        }

        public void Send(string eventName, JSONObject data)
        {
            websocket.Send(eventName, data);
        }

        public void OnWebSocketUnityOpen(string sender)
        {
            isAuth = true;
        }

        public void OnWebSocketUnityClose(string reason)
        {
            print(reason);
        }

        public void OnWebSocketUnityReceiveMessage(string message)
        {
            //print(message);
        }

        public void OnWebSocketUnityReceiveDataOnMobile(string base64EncodedData)
        {
            print(base64EncodedData);
        }

        public void OnWebSocketUnityReceiveData(byte[] data)
        {
            print(data);
        }

        public void OnWebSocketUnityReceiveEvent(string eventName, JSONObject data)
        {
            print(eventName + data.str);
            responceEvent.Invoke(eventName, data);
        }

        public void OnWebSocketUnityError(string error)
        {
            print(error);
        }
    }
}
