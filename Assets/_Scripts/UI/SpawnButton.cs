using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour {

    [SerializeField]
    private GameInfo.CharacterType type { get; set; }

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        var localType = GetComponent<SpawnButton>().type;
        if (GameInfo.isSpawn && GameInfo.spawnType == localType)
        {
            GameInfo.isSpawn = false;
        }
        else
        {
            GameInfo.isSpawn = true;
            GameInfo.spawnType = localType;
        }
    }
}
