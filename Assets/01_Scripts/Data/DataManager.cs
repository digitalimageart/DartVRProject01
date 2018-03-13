using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : SingleTon<DataManager> {

    private const int INITIALSCORE = 2000;

    //Read Only Score
    private int _score;
    public int score { get { return _score; } }

    [HideInInspector]
    public int spcAtkNum = 2;
    [HideInInspector]
    public bool isEffectBulletTime;
    private List<PlayerResult> _playerList;
    [HideInInspector]
    public List<PlayerResult> playerList {
        get
        {
            if(_playerList == null)
            {
                Load();
            }

            return playerList;
        }
        set
        {
            _playerList = value;
        }
    }

    public Target player;
    public GameObject[] Effects;

    [SerializeField]
    private UIManager _ui;
    [SerializeField]
    private CollectedDart[] _darts;
    
    
    private System.Timers.Timer timer;
    private List<DART_TYPE?> _dartList;

    private DataManager() { }
    
    private void Start()
    {
        timer = new System.Timers.Timer(1000); // per 1sec
        timer.Elapsed += _ui.TimeTicker;
        timer.Start();
        _score = INITIALSCORE;
        isEffectBulletTime = false;
        _dartList = new List<DART_TYPE?>();
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
            _dartList.Add(d_type);
            _darts[(int)d_type].Collected();
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
        GunnerManager.Instance.FireSpcAtk();
    }

    IEnumerator ChangePlayerTag()
    {
        player.tag = "SpecialAtk";
        yield return new WaitForSeconds(3f);
        player.tag = "Target";
    }

    public void CheckGameOver()
    {
        if (_score <= 0)
        {
            GameOver();
        }
        if (_dartList.Count == 4)
        {
            GameClear();
        }
    }

    public void GameOver()
    {
        player.tag = "GameOver";
        timer.Stop();
        _ui.ShowGameOver();
    }

    private void GameClear()
    {
        player.tag = "GameOver";
        timer.Stop();
        _ui.ShowGameOver();
        ShowSaveWindow();
    }

    public void ShowSaveWindow()
    {
        //_ui.
    }

    private void SaveResult()
    {
        //이름, 과 입력 받은후에 저장해야 한다.
        //Score과 남은시간을 이용하여 최종점수를 계산해야 한다.
        int ResultScore = score + _ui._leftTime * 10;

        _ui.SaveState("score : " + score.ToString() + " LeftTime * 10 : " + _ui._leftTime * 10 +" = "+ ResultScore);

        //PlayerResult player = new PlayerResult();

        playerList.Sort();
        Save();
    }

    //IO
    private string GetSaveRoute(string data)
    {
        string route;
        string dirRoute;
        DirectoryInfo dir;

#if (UNITY_EDITOR)
        route = Application.dataPath + "/DataFiles/" + data + "/" + data + ".json";
        dirRoute = Application.dataPath + "/DataFiles/" + data;

#elif (UNITY_STANDALONE_WIN)
        route = Application.dataPath + "/"+ data +"/"+ data +".json";
        dirRoute = Application.dataPath + "/"+data;
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

public class PlayerResult :IComparable<PlayerResult>, IEquatable<PlayerResult>
{
    string name;
    string department;
    int score;

    public PlayerResult(string name, string department, int score)
    {
        this.name = name;
        this.department = department;
        this.score = score;
    }

    public int CompareTo(PlayerResult other)
    {
        if (other == null)
            return 1;
        else
            return this.score.CompareTo(other.score);
    }

    public bool Equals(PlayerResult other)
    {
        if (other == null) return false;
        return this.score.Equals(other.score);
    }

    public override string ToString()
    {
        return name +" "+ department + " " + score.ToString();
    }
}