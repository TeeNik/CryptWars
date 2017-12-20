using System;

namespace Assets._Scripts.CallbackObjects
{
    public class WarriorObject : CallbackObject
    {

        public Guid PlayerId;
        public Guid Id;
        public int Line;
        public GameInfo.CharacterType Type;
        public int MaxHp;
        public int Hp;
        public float Reload;
        public float X;
        public float Y;
        public bool FacingRight;


    }
}
  