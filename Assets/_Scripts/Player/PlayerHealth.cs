﻿using Assets._Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        float _maxHealth = 100;

        float _curHealth;
        public bool _facingRight;

        public Image HealthBar;

        [SerializeField]
        private bool _player;

        void Start () {
            _curHealth = _maxHealth - 20;
        }
	
        void Update () {
            HealthBar.fillAmount = _curHealth / _maxHealth;
        }

        void TakeDamage(float d, bool p)
        {
            if(_player == p)
            {
                print("Damage");
                _curHealth -= d;
            }
        }
    }
}
