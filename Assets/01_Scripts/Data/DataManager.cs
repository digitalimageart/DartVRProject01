using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTon<DataManager> {

    private const int INITIALSCORE = 10000;

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }

    public bool isEffectBulletTime;

    [SerializeField]
    private UIManager _ui;
    [SerializeField]
    private GameObject _player;

    private DataManager() { }
    

    private void Start()
    {
        stopwatch.Start();
        _score = INITIALSCORE;
        isEffectBulletTime = false;
    }

    //StopWatch
    public System.Diagnostics.Stopwatch stopwatch
    {
        get { return new System.Diagnostics.Stopwatch(); }
    }

    public void ChangeScore(int score) {
        _score += score;
        _ui.ChangeGaugeScore(_score, INITIALSCORE);
    }

    public void FireBGColorChange(COLOR_TYPE type)
    {
        _ui.ChangeBGColor(type);
    }

    public void FireSpcAtk() {
        _ui.ChangeBGColor(COLOR_TYPE.SPECIAL);
        StartCoroutine("ChangePlayerTag");
        isEffectBulletTime = true;
    }

    IEnumerator ChangePlayerTag()
    {
        _player.tag = "SpecialAtk";
        yield return new WaitForSeconds(3f);
        _player.tag = "Target";
    }

    public void CheckGameOver()
    {
        if (_score < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        stopwatch.Stop();
        _ui.ShowGameOver();
        SaveResult();
    }

    private void SaveResult()
    {
    }

}