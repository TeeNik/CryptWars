using System.Runtime.InteropServices;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.Network;
using Assets._Scripts.Player;
using Assets._Scripts.System;
using UnityEngine;


public class Field : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private int fieldNumber;

    private void OnMouseDown()
    {
        if (GameInfo.IsSpawn)
        {
            //var clone = (GameObject)Instantiate(ResourceManager.GetCharacter(GameInfo.spawnType.ToString()), spawnPoint.position, spawnPoint.rotation);
            SendSpawn();
            GameInfo.IsSpawn = false;
        }
    }

    public void Spawn(WarriorObject wo)
    {
        var clone = Instantiate(ResourceManager.GetCharacter(wo.Type.ToString()), spawnPoint.position, spawnPoint.rotation);
        InitEnemy(clone, wo);
    }

    private void InitEnemy(GameObject enemy, WarriorObject wo)
    {
        if(!wo.FacingRight)
            enemy.GetComponent<Enemy>().ChangeDirection();

        enemy.GetComponent<Character>().Init(wo);
    }

    private void SendSpawn()
    {
        WarriorObject wo = new WarriorObject();
        wo.Id = StaticManager.Player.Id;
        wo.Line = fieldNumber;
        wo.Type = GameInfo.SpawnType;
        NetworkManager.Instance.Send(NetworkCommands.spawnWarrior.ToString(), new JSONObject(wo.GetJson())); 
    }
}
