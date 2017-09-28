using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour {

    [SerializeField]
    private GameInfo.CharacterType type;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        switch (type)
        {
            case GameInfo.CharacterType.Warrior:
                Instantiate(ResourceManager.getCharacter("Warrior"), ResourceManager.getSpawnPosition().position, ResourceManager.getSpawnPosition().rotation);
                break;
        }
    }
}
