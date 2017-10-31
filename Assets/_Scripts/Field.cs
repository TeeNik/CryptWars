using UnityEngine;
using UnityEngine.Networking;

public class Field : NetworkBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    public delegate void SpawnFromPlayer(GameObject clone);
    public static event SpawnFromPlayer Spawn;

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            Spawn(CreateObject(GameInfo.spawnType));
            GameInfo.isSpawn = false;
        }
    }

    

    GameObject CreateObject(GameInfo.CharacterType type)
    {
        var clone = (GameObject)Instantiate(ResourceManager.getCharacter(type.ToString()), spawnPoint.position, spawnPoint.rotation);
        return clone;
    }
}
