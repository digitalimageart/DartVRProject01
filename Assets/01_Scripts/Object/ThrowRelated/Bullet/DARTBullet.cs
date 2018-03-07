using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DARTBullet : Bullet{

    [SerializeField]
    private DART_TYPE _dartType;

    public override void Effect()
    {
        
    }

    public override void Hit(GameObject obj)
    {
        DataManager.Instance.DARTBulletHit(_bulletPoint,COLOR_TYPE.POSITIVE,_dartType);

        Effect();
    }

    
}

public enum DART_TYPE {
    D = 0,
    A,
    R,
    T
}