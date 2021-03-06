﻿using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using UnityEngine;

public class PlayerModel {

    public bool FacingRight;
    public int Hp;
    public int MaxHp;
    public int Gold;
    public int Mana;
    public int MaxMana;
    public int MoneySpeed;
    public int ManaSpeed;
    public List<WarriorObject> Army;

    void AddGold(int value)
    {
        Gold += value;
    }

    void AddMana(int value)
    {
        Mana += value;
        if (Mana > MaxMana)
            Mana = MaxMana;
    }

    bool RemoveCoin(int value)
    {
        if (Gold >= value)
        {
            Gold -= value;
            return true;
        }
        return false;
    }

    bool RemoveMana(int value)
    {
        if (Mana >= value)
        {
            Mana -= value;
            return true;
        }
        return false;
    }

}
