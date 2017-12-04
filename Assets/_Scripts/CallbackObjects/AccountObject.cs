using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountObject {

    public long id;
    public string name;

    public AccountObject(){}

    public AccountObject(long i, string s)
    {
        id = i;
        name = s;
    }

    public string GetJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
