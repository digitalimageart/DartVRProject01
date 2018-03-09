using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerManager : SingleTon<GunnerManager>
{
    private GunnerManager() { }

    [SerializeField]
    private AutoGunner[] _gunnerNagativePrefab;
    [SerializeField]
    private AutoGunner[] _gunnerDartPrefab;
    

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
        int rand;
        do
        {
            rand = (new System.Random()).Next(0, 5);
        } while (_isMadeType[rand]);
        _isMadeType[rand] = true;

        _madeNegativeGunner = Instantiate(_gunnerNagativePrefab[rand], transform) as AutoGunner;
        _madeNegativeGunner.fireInterval = 2;
        _madeNegativeGunner.firePower = 500;
        _madeNegativeGunner.target = DataManager.Instance.player.transform;
    }

    public Transform[] GetMakePositions()
    {
        return GetComponent<PositionData>().GetPositions();
    }


}
