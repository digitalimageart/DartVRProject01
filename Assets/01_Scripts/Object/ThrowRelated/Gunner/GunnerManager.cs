using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerManager : SingleTon<GunnerManager>
{
    private GunnerManager() { }

    [SerializeField]
    private GameObject _newGunner;

    [SerializeField]
    private GameObject _point1;

    [SerializeField]
    private GameObject _point2;

    [SerializeField]
    private GameObject _point3;

    private GameObject _madeGunner;

    private List<GameObject> _gunners;

    void Start()
    {
        _gunners = new List<GameObject>();
        MakeGunner();
    }

    private void MakeGunner()
    {
        _madeGunner = Instantiate(_newGunner, transform.position, Quaternion.identity);
        _madeGunner.GetComponent<AutoGunner>().setPoints(_point1, _point2, _point3);
        _gunners.Add(_madeGunner);
    }
}
