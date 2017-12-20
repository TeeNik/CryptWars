using System.Runtime.InteropServices;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.System;
using UnityEngine;
using UnityEngine.Networking;

public class Field : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private int fieldNumber;

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            var clone = (GameObject)Instantiate(ResourceManager.GetCharacter(GameInfo.spawnType.ToString()), spawnPoint.position, spawnPoint.rotation);
            GameInfo.isSpawn = false;
        }
    }

    public void Spawn(WarriorObject w)
    {
        var clone = Instantiate(ResourceManager.GetCharacter(w.Type.ToString()), spawnPoint.position, spawnPoint.rotation);
        clone.GetComponent<Enemy>
    }

    private void InitEnemy(GameObject enemy, WarriorObject warriorObject)
    {
        enemy.GetComponent<Enemy>().facingRight = warriorObject.FacingRight;
    }
}
