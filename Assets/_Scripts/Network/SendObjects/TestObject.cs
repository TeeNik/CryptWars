using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TestObject {
    public string str;

    public string GetJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
