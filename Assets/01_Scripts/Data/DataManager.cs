using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    private const int INITIALSCORE = 10000;

    // SingleTon
    private static DataManager _intstance;

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }

    [SerializeField]
    private UIManager _ui;
    [SerializeField]
    private GameObject _player;

    private DataManager() { }
    public static DataManager Instance {
        get
        {
            if (_intstance == null)
            {
                _intstance = (DataManager)GameObject.FindObjectOfType(typeof(DataManager));
                if (_intstance == null)
                    Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
            }
        
            return _intstance;
        }
    }

    private void Start()
    {
        stopwatch.Start();
        _score = INITIALSCORE;
    }

    //StopWatch
    public System.Diagnostics.Stopwatch stopwatch
    {
        get { return new System.Diagnostics.Stopwatch(); }
    }

    private void SaveResult() {
    }

    private void GameOver() {
        stopwatch.Stop();
        _ui.ShowGameOver();
    }

    public void ChangeScore(int score) {
        _score -= score;
        _ui.AffectScore(_score, INITIALSCORE);
    }

    public void FireBGColorChange(COLOR_TYPE type)
    {
        _ui.ChangeBGColor(type);
    }

    public void FireSpcAtk() {
        _ui.ChangeBGColor(COLOR_TYPE.SPECIAL);
        StartCoroutine("ChangePlayerTag");
    }

    IEnumerator ChangePlayerTag()
    {
        _player.tag = "SpecialAtk";
        yield return new WaitForSeconds(3f);
        _player.tag = "Target";
    }



}
