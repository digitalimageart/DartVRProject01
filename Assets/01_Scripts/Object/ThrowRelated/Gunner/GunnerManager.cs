using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerManager : SingleTon<GunnerManager>
{
    private GunnerManager() { }

    [SerializeField]
    private GameObject _newGunner;

    [SerializeField]
    private Transform _point1;

    [SerializeField]
    private Transform _point2;

    [SerializeField]
    private Transform _point3;

    private List<GameObject> _gunners;

    private GameObject _madeGunner;
    
    void Start()
    {
        _gunners = new List<GameObject>();
        MakeGunner();
    }

    private void MakeGunner()
    {
        _madeGunner = Instantiate(_newGunner, transform.position, Quaternion.identity);
        _madeGunner.GetComponent<AutoGunner>().SetPoints(_point1, _point2, _point3);
        _madeGunner.GetComponent<AutoGunner>().SetFireInterval(Random.value * 3);
        _gunners.Add(_madeGunner);
    }
}
