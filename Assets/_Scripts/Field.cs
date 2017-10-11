using UnityEngine;
using static GameInfo;

public class Field : MonoBehaviour {

    [SerializeField]
    GameObject spawnPoint;

    private void OnMouseDown()
    {
        print("click");
    }

    void Spawn(CharacterType type)
    {

    }
}
