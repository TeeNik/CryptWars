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
        Transform pos = wo.FacingRight ? leftSpawn : rightSpawn;
        var clone = Instantiate(ResourceManager.GetCharacter(type.ToString()), pos.position, pos.rotation);
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
        WarriorObject wo = new WarriorObject
        {
            PlayerId = StaticManager.Instance.Player.Id,
            Type = GameInfo.SpawnType,
            Line = fieldNumber,
            FacingRight = StaticManager.Instance.Player.PlayerModel.FacingRight
        };
        print("Spawn fr: " + wo.FacingRight);
        JSONObject jsonObject = new JSONObject(wo.GetJson());
        NetworkManager.Instance.Send(NetworkCommands.SpawnWarrior.ToString(), jsonObject); 
    }
}
