using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTon<DataManager> {

    private const int INITIALSCORE = 10000;

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }
    [HideInInspector]
    public bool isEffectBulletTime;

    [SerializeField]
    private UIManager _ui;
    [SerializeField]
    private Target _player;

    private List<DART_TYPE?> _dartList;

    private DataManager() { }

    private void Start()
    {
        stopwatch.Start();
        _score = INITIALSCORE;
        isEffectBulletTime = false;
        _dartList = new List<DART_TYPE?>();
    }

    //StopWatch
    public System.Diagnostics.Stopwatch stopwatch
    {
        get { return new System.Diagnostics.Stopwatch(); }
    }

    public void DARTBulletHit(int score, COLOR_TYPE color, DART_TYPE d_type) {
        ChangeScore(score);
        FireBGColorChange(color);
        CollectDart(d_type);
    }

    public void NegativeBulletHit(int score, COLOR_TYPE color) {
        ChangeScore(score);
        FireBGColorChange(color);
    }

    private void CollectDart(DART_TYPE d_type) {

        if (_dartList.Find(x => x == d_type) == null)
        {
            CheckGameOver();
        }
        else
        {
            _dartList.Add(d_type);
        }
    }

    private void ChangeScore(int score) {
        _score += score;
        _ui.ChangeGaugeScore(score, INITIALSCORE);
    }

    private void FireBGColorChange(COLOR_TYPE type)
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
        if (_score < 0 || _dartList.Count > 4)
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