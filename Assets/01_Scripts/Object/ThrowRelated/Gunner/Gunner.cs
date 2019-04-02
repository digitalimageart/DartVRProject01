using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Gunner : MonoBehaviour
{
    [SerializeField]
    protected Bullet _bulletObject;
    protected float _firePower;
    protected Bullet _madeBullet;


    public abstract void FireBullet();

    public abstract void MakeBullet();
}
