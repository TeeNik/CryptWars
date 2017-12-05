using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackObject {

    public string GetJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public static T FromJson<T>(string json)
    {
        T obj = JsonConvert.DeserializeObject<T>(json);
        return obj;
    }

}
