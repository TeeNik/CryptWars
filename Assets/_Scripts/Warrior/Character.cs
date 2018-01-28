using System;
using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using Assets._Scripts.System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int Id;
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _damage;

    private float _curHealth;

    [SerializeField]
    private Image _healthBar;

    public void Start()
    {
        _curHealth = _maxHealth;
    }

    void OnChangeHealth(float hp)
    {
        _healthBar.fillAmount = hp / _maxHealth;
    }

    public void TakeDamage(float d)
    {
        _curHealth -= d;
        if(_curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Init(WarriorObject wo)
    {
        _maxHealth = wo.MaxHp;
        _curHealth = _maxHealth;
        Id = wo.Id;
        if (StaticManager.Instance.Player.PlayerModel.FacingRight != wo.FacingRight)
            gameObject.tag = "Enemy";
        print(gameObject.tag);
    }

}
