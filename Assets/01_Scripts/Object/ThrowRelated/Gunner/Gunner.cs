using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Gunner : MonoBehaviour
{
    [SerializeField]
    protected Bullet _bulletObject;

    public float firePower
    {
        get; set;
    }
    protected Bullet _madeBullet;


    public abstract void FireBullet();

    public void MakeBullet()
    {
        _madeBullet = Instantiate(_bulletObject, transform.position, Quaternion.identity) as Bullet;
    }
}
