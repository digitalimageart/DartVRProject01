using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTon<DataManager> {

    private const int INITIALSCORE = 10000;

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }

    [SerializeField]
    private UIManager _ui;
    [SerializeField]
    private GameObject _player;

    private DataManager() { }
    

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
        _ui.ChangeGaugeScore(_score, INITIALSCORE);
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
