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
            var clone = (GameObject)Instantiate(ResourceManager.getCharacter(GameInfo.spawnType.ToString()), spawnPoint.position, spawnPoint.rotation);
            GameInfo.isSpawn = false;
        }
    }

    public void Spawn(WarriorObject w)
    {

    }
}
