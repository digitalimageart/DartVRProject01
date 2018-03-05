using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerManager : SingleTon<GunnerManager>
{
    private GunnerManager() { }

    [SerializeField]
    private GameObject _newGunner;

    [SerializeField]
    private GameObject point1;

    [SerializeField]
    private GameObject point2;

    [SerializeField]
    private GameObject point3;

    private GameObject gunner;

    private List<GameObject> Gunners;

    void Start()
    {
        MakeGunner();
    }

    private void MakeGunner()
    {
        gunner = Instantiate(_newGunner, transform.position, Quaternion.identity);
        gunner.GetComponent<AutoGunner>().setPoints(point1, point2, point3);
        Gunners.Add(gunner);
    }
}
