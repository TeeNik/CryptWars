using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountObject : CallbackObject {

    public int id;
    public string name;

    public AccountObject(){}

    public AccountObject(int i, string s)
    {
        id = i;
        name = s;
    }

    
}
