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
        _makeTime[0] = 20f;
        _makeTime[1] = 20f;
        _makeTime[2] = 20f;
        _makeTime[3] = 20f;
        _makeTime[4] = 20f;

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
        _madeNegativeGunner = Instantiate(_gunnerPrefab, transform) as AutoGunner;
        _madeNegativeGunner.firePower = 1200;
        _madeNegativeGunner.target = DataManager.Instance.player.transform;
        _madeNegativeGunner.type = GUNNER_TYPE.NEGATIVE;
    }

    private void MakeSpcGunner()
    {
        SpcGunner spcGunner = Instantiate(_spcGunnerPrefab, _spcGunnerPosition.position,Quaternion.identity,transform) as SpcGunner;
        spcGunner.firePower = 200;
    }
    public Bullet ReturnRandomNegativeBullet()
    {
        return _negativeBullets[(new System.Random()).Next(0, 5)];
    }

    private void MakeDartGunner()
    {
        _madeDartGunner = Instantiate(_gunnerPrefab, transform) as AutoGunner;
        _madeDartGunner.fireInterval = 5f;
        _madeDartGunner.firePower = 700;
        _madeDartGunner.target = DataManager.Instance.player.transform;
        _madeDartGunner.type = GUNNER_TYPE.DART;
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
