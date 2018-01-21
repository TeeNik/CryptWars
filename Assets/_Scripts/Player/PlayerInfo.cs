using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static event Action OnUpdatePlayerModelEvent ;

    public int Id;

    public PlayerModel PlayerModel;

    [SerializeField]
    private GameInfo.CharacterType[] _selectedWarriors;

    void Start()
    {
        Id = 3315;
    }

    public void Init(PlayerModel model)
    {
        PlayerModel = model;
    }

    public void UpdatePlayerFromServer(PlayerModel model)
    {
        PlayerModel.Hp = model.Hp;
        PlayerModel.Army = model.Army;
    }
}
