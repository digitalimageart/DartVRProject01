using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBullet : Bullet {
    
    public override void Effect()
    {
        //이펙트 넣기
        GameObject effect = Instantiate(DataManager.Instance.Effects[0], this.transform.position, Quaternion.identity);
    }

    public override void Hit(GameObject obj)
    {
        DataManager.Instance.NegativeBulletHit(_bulletPoint, COLOR_TYPE.NEGATIVE);

        Effect();
    }
}
