using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountObject {

    public long id;
    public string name;

    public string GetJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
