using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.System
{
    class StaticManager : MonoBehaviour
    {

        public PlayerInfo Player;
        public PlayerInfo Opponent;

        public static StaticManager Instance;

        void Awake()
        {
            Instance = this;
        }

    }
}
