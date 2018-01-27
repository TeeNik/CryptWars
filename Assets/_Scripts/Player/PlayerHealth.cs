using Assets._Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        float _maxHealth = 100;

        float _curHealth;

        public Image HealthBar;

        void Start () {
            _curHealth = _maxHealth - 20;
        }
	
        void Update () {
            HealthBar.fillAmount = _curHealth / _maxHealth;
        }
    }
}
