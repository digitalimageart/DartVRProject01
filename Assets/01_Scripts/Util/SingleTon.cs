using System.Collections;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour {


    // SingleTon
    private static T _intstance;

    public static T Instance
    {
        get
        {
            if (_intstance == null)
            {
                _intstance = FindObjectOfType(typeof(T)) as T;
                if (_intstance == null)
                    Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
            }

            return _intstance;
        }
    }
}
