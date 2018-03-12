﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : SingleTon<DataManager> {

    private const int INITIALSCORE = 10000;

    //Read Only Score
    private int _score;

    public List<PlayerResult> playerList = new List<PlayerResult>();

    public int score { get { return _score; } }
    [HideInInspector]
    public bool isEffectBulletTime;
    
    public GameObject[] Effects;

    [SerializeField]
    private UIManager _ui;
    
    public Target player;

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
        player.tag = "SpecialAtk";
        yield return new WaitForSeconds(3f);
        player.tag = "Target";
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

    //IO


    private string GetSaveRoute(string data)
    {
        string route;
        string dirRoute;
        DirectoryInfo dir;

#if (UNITY_EDITOR)
        route = Application.persistentDataPath + "/DataFiles/" + data + "/" + data + ".json";
        dirRoute = Application.persistentDataPath + "/DataFiles/" + data;

#elif (UNITY_STANDALONE_WIN)
        route = Application.dataPath + "/"+data.ToString("G")+"/"+data.ToString("G")+".json";
        dirRoute = Application.dataPath + "/"+data.ToString("G");
#endif
        dir = new DirectoryInfo(dirRoute);

        if (dir.Exists == false)
        {
            dir.Create();
        }

        return route;

    }
    private void Load()
    {
        string JsonString;
        string route = GetSaveRoute("players");

        try
        {
            JsonString = File.ReadAllText(route);
        }
        catch (FileNotFoundException e)
        {
            Save();

            JsonString = File.ReadAllText(route);
        }

        if (JsonString != "")
            playerList = JsonHelper.FromJson<PlayerResult>(JsonString);
    }

    private void Save()
    {
        string Json;
        string route;

        List<PlayerResult> tmpJson = playerList;

        if (tmpJson != null)
            Json = JsonHelper.ToJson<PlayerResult>(tmpJson);
        else
            Json = null;

        route = GetSaveRoute("players");

        File.WriteAllText(route, Json);
    }


}

public class PlayerResult
{
    string name;
    string department;
    int score;
}