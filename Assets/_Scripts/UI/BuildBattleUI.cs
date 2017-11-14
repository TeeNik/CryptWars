using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBattleUI : MonoBehaviour {

    
    [SerializeField]
    private Button spawnButton;  

    void Start()
    {
        PlayerInfo.csb += CreateSpawnButtons;
    }

    private void CreateSpawnButtons(GameInfo.CharacterType[] types)
    {
        foreach(var t in types)
        {
            Instantiate(spawnButton, transform, false);
        }
    }	

	
}
