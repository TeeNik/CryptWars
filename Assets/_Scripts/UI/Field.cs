using UnityEngine;
using UnityEngine.Networking;

public class Field : NetworkBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private int fieldNumber;

    
    

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            var clone = (GameObject)Instantiate(ResourceManager.getCharacter(GameInfo.spawnType.ToString()), spawnPoint.position, spawnPoint.rotation);
            EnemySpawnObject en = new EnemySpawnObject(GameInfo.spawnType, fieldNumber);

            EventHandler.Spawn(en);
            GameInfo.isSpawn = false;
        }
    }



    /*EnemySpawnObject CreateObject(GameInfo.CharacterType type)
    {
        var clone = (GameObject)Instantiate(ResourceManager.getCharacter(type.ToString()), spawnPoint.position, spawnPoint.rotation);
        EnemySpawnObject en = new EnemySpawnObject(type, fieldNumber);
        return en;
    }*/
}
