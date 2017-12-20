using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private Guid Id { get { return Id; } set { Id = value; } }
    int _coin;
    int _energy;

    public GameObject Obj;
    public Transform Place;

    [SerializeField]
    private GameInfo.CharacterType[] _selectedWarriors;

    private void Start()
    {
        
    }
}
