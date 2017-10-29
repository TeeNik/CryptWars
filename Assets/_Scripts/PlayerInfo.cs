using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : NetworkBehaviour
{

    int coin;
    int energy;

    [SerializeField]
    float maxHealth;

    [SerializeField]
    Image heathBar;

    float curHealth;

    private void Start()
    {
        curHealth = maxHealth-20;
    }

    private void Update()
    {
        heathBar.fillAmount = curHealth / maxHealth;
    }

}
