using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DARTBullet : Bullet{

    public override void Effect()
    {
        
    }

    public override void Hit(GameObject obj)
    {
        DataManager.Instance.FireBGColorChange(COLOR_TYPE.POSITIVE);
        DataManager.Instance.ChangeScore(0);

        Effect();
    }

    
}

public enum DART_TYPE {
    D,
    A,
    R,
    T
}