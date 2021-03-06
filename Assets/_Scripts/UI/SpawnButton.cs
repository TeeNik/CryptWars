﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour {

    [SerializeField]
    private GameInfo.CharacterType type;

    public void SetType(GameInfo.CharacterType t)
    {
        type = t;
        transform.GetComponentInChildren<Text>().text = t.ToString();
    }

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        var localType = GetComponent<SpawnButton>().type;
        if (GameInfo.IsSpawn && GameInfo.SpawnType == localType)
        {
            GameInfo.IsSpawn = false;
        }
        else
        {
            GameInfo.IsSpawn = true;
            GameInfo.SpawnType = localType;
        }
    }
}
