using UnityEngine;
using UnityEngine.Networking;

public class Field : NetworkBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private int fieldNumber;

    public static event EventHandler.SpawnFromPlayer Spawn;

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            var clone = (GameObject)Instantiate(ResourceManager.getCharacter(GameInfo.spawnType.ToString()), spawnPoint.position, spawnPoint.rotation);
            EnemySpawnObject en = new EnemySpawnObject(GameInfo.spawnType, fieldNumber);

            Spawn(en);
            GameInfo.isSpawn = false;
        }
    }
}
