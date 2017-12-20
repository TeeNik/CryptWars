using Assets._Scripts.System;
using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        float _maxHealth;

        float _curHealth;

        [SerializeField]
        private bool _player;

        void Start () {
            _curHealth = _maxHealth - 20;
        }
	
        void Update () {
            ResourceManager.Instance.HealthBar.fillAmount = _curHealth / _maxHealth;
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
