using UnityEngine;
using UnityEngine.Networking;

public class Field : NetworkBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            CmdSpawn(GameInfo.spawnType);
            GameInfo.isSpawn = false;
        }
    }

    [Command]
    void CmdSpawn(GameInfo.CharacterType type)
    {
        var clone = (GameObject)Instantiate(ResourceManager.getCharacter(type.ToString()), spawnPoint.position, spawnPoint.rotation);
        NetworkServer.Spawn(clone);
    }
}
