using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObject : CallbackObject{

    public int id;
    public bool ok;

    public ConnectObject() { }

    public ConnectObject(int i, bool o)
    {
        id = i;
        ok = o;
    }
}
