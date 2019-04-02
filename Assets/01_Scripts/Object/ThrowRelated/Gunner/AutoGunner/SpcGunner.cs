using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpcGunner : Gunner{

    public void Start()
    {
        MakeBullet();
        FireBullet();
    }

    public override void FireBullet()
    {
        Transform target = DataManager.Instance.player.transform;
        _madeBullet.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * _firePower);
    }

    public override void MakeBullet()
    {
        _madeBullet = Instantiate(_bulletObject, transform);
    }
}
