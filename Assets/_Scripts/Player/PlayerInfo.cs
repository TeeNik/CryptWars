using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    int coin;
    int energy;

    public GameObject obj;
    public Transform place;

    [SerializeField]
    private GameInfo.CharacterType[] selectedWarriors;
    public static event EventHandler.CreateSpawnButtons csb;

    private void Start()
    {
        
    }

    public static void SetSelectedWarriors(GameInfo.CharacterType[] arr)
    {
        csb(arr);
    }
}
