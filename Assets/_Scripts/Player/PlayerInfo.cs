using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int Id;
    public int FacingRight;
    int _coin;
    int _energy;

    public GameObject Obj;
    public Transform Place;

    [SerializeField]
    private GameInfo.CharacterType[] _selectedWarriors;

    void Start()
    {
        Id = 3315;
    }
}
