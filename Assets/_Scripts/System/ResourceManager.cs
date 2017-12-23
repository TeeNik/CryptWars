using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.System
{
    public class ResourceManager : MonoBehaviour {

        [SerializeField]
        private GameObject[] _characters;      

        public static ResourceManager Instance;

        private void Start()
        {
            Instance = this;
        }

        public static GameObject GetCharacter(string name)
        {
            return Get(name + " (UnityEngine.GameObject)", Instance._characters);
        }

        public static T Get<T>(string name, T[] array){
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString() == name)
                {
                    return array[i];
                }
            }
            return default(T);
        }



    }
}
