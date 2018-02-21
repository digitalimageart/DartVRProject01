using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    // SingleTon
    private static DataManager _Instance;

    private DataManager() { }
    public static DataManager Instance {
        get
        {
            if (_Instance == null)
            {
                _Instance = new DataManager();
            }
            return _Instance;
        }
    }

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }
    //StopWatch
    public System.Diagnostics.Stopwatch stopwatch
    {
        get { return new System.Diagnostics.Stopwatch(); }
    }


}
