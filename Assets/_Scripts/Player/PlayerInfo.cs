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
    public int FacingRight;
    int _coin;
    int _energy;

    public GameObject Obj;
    public Transform Place;

    private PlayerModel _playerModel;

    [SerializeField]
    private GameInfo.CharacterType[] _selectedWarriors;

    void Start()
    {
        Id = 3315;
    }

    public void Init(PlayerModel model)
    {
        _playerModel = model;
    }

    public void UpdatePlayerFromServer(PlayerModel model)
    {
        _playerModel.Hp = model.Hp;
        _playerModel.Army = model.Army;
    }
}
