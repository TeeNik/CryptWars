using Assets._Scripts.System;
using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        float _maxHealth = 100;

        float _curHealth;
        public bool _facingRight;

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
