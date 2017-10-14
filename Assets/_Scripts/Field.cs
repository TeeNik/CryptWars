using UnityEngine;

public class Field : MonoBehaviour {

    [SerializeField]
    Transform spawnPoint;

    private void OnMouseDown()
    {
        if (GameInfo.isSpawn)
        {
            Spawn(GameInfo.spawnType);
            GameInfo.isSpawn = false;
        }
    }

    void Spawn(GameInfo.CharacterType type)
    {
        Instantiate(ResourceManager.getCharacter("Goblin"), spawnPoint.position, spawnPoint.rotation);
    }
}
