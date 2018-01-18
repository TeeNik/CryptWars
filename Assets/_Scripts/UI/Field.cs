using System.Runtime.InteropServices;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.Network;
using Assets._Scripts.Player;
using Assets._Scripts.System;
using UnityEngine;


public class Field : MonoBehaviour
{

    [SerializeField]
    Transform leftSpawn;
    [SerializeField]
    Transform rightSpawn;
    [SerializeField]
    private int fieldNumber;

    private void OnMouseDown()
    {
        if (GameInfo.IsSpawn)
        {
            SendSpawn();
            GameInfo.IsSpawn = false;
        }
    }

    public void Spawn(WarriorObject wo)
    {
        GameInfo.CharacterType type = wo.Type;
        var clone = Instantiate(ResourceManager.GetCharacter(type.ToString()), leftSpawn.position, leftSpawn.rotation);
        InitEnemy(clone, wo);
        WarriorManager.Instance.AddWarrior(clone.GetComponent<Character>());       
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
        wo.PlayerId = StaticManager.Instance.Player.Id;
        wo.Type = GameInfo.SpawnType;
        wo.Line = fieldNumber;
        wo.FacingRight = true;
        JSONObject jsonObject = new JSONObject(wo.GetJson());
        NetworkManager.Instance.Send(NetworkCommands.SpawnWarrior.ToString(), jsonObject); 
    }
}
