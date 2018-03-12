using System;
using System.Collections.Generic;
using UnityEngine;

class JsonHelper
{
    [Serializable]
    private class Wrapper<T>
    {
        public List<T> usrs;
    }

    public static List<T> FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.usrs;
    }

    public static string ToJson<T>(List<T> array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.usrs = array;
        return JsonUtility.ToJson(wrapper);
    }
}