using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using UnityEngine;

public class WarriorManager : MonoBehaviour
{
    private Dictionary<int, Character> _warriors;
    public static WarriorManager Instance;

    void Start()
    {
        _warriors = new Dictionary<int, Character>();
        Instance = this;
    }

    public void AddWarrior(Character w)
    {
        _warriors.Add(w.Id, w);
    }

    public void RemoveWarrior(int id)
    {
        _warriors.Remove(id);
    }

    public void SyncWarrior(WarriorObject wo)
    {
        Character character = _warriors[wo.Id];
        character.transform.position = new Vector3(wo.X, character.transform.position.y);   
        print("SyncWarrior: " + wo.Id);
    }
}
