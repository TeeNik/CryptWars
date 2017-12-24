using System;

namespace Assets._Scripts.CallbackObjects
{
    public class WarriorObject : CallbackObject
    {
        public int PlayerId;
        public int Id;
        public GameInfo.CharacterType Type;
        public int MaxHp;
        public int Hp;
        public float Reload;
        public float X;
        public float Y;
        public bool FacingRight;
        public int Line;
    }
}
  