using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerManager : SingleTon<GunnerManager>
{
    private GunnerManager() { }
    [SerializeField]
    private Transform _spcGunnerPosition;
    [SerializeField]
    private AutoGunner _gunnerPrefab;
    [SerializeField]
    private SpcGunner _spcGunnerPrefab;

    [SerializeField]
    private DARTBullet[] _dartBullets;
    [SerializeField]
    private NegativeBullet[] _negativeBullets;
    
    private List<AutoGunner> _gunners;

    private AutoGunner _madeNegativeGunner;
    private AutoGunner _madeDartGunner;

    private float[] _makeTime;

    private bool[] _isMadeType = new bool[5];
    
    void Start()
    {

        for(int i = 0; i < 5; i++)
        {
            _isMadeType[i] = false;
        }

        _makeTime = new float[5];
        for (int i = 0; i < 5; i++)
            _makeTime[i] = 20f;

        _gunners = new List<AutoGunner>();
        StartCoroutine("MakeNegativeGunners");
        MakeDartGunner();
    }

    IEnumerator MakeNegativeGunners()
    {
        for (int i = 0; i < 5; i++) {
            MakeNegativeGunner(i + 1);
            yield return new WaitForSeconds(_makeTime[i]);
        }
    }

    private void MakeNegativeGunner(int i)
    {
        _madeNegativeGunner = AutoGunner.AutoGunnerFactory(GUNNER_TYPE.NEGATIVE, _gunnerPrefab, transform)
            .setFirePower(1200)
            .setTarget(DataManager.Instance.player.transform)
            .Build();
    }

    private void MakeSpcGunner()
    {
       // SpcGunner spcGunner = Instantiate(_spcGunnerPrefab, _spcGunnerPosition.position,Quaternion.identity,transform) as SpcGunner;
       // spcGunner.firePower = 200;
    }
    public Bullet ReturnRandomNegativeBullet()
    {
        return _negativeBullets[(new System.Random()).Next(0, 5)];
    }

    private void MakeDartGunner()
    {
        _madeDartGunner = AutoGunner.AutoGunnerFactory(GUNNER_TYPE.NEGATIVE, _gunnerPrefab, transform)
            .setFireInterval(5f)
            .setFirePower(700)
            .setTarget(DataManager.Instance.player.transform)
            .Build();
    }

    public void FireSpcAtk()
    {
        MakeSpcGunner();
    }

    public Bullet RetunRandomDartBullet()
    {
        return _dartBullets[(new System.Random()).Next(0, 4)];
    }

    public Transform[] GetMakePositions()
    {
        return GetComponent<PositionData>().GetPositions();
    }


}
