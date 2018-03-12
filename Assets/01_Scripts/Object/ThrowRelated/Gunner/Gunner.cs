using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Gunner : MonoBehaviour
{
    protected Bullet _bulletObject;
    public Bullet bulletObject
    {
        set
        {
            _bulletObject = value;
        }
    }

    public float firePower
    {
        get; set;
    }
    protected Bullet _madeBullet;


    public abstract void FireBullet();

    public abstract void MakeBullet();
}
