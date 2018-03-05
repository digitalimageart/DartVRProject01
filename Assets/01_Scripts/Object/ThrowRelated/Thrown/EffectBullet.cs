using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBullet : Bullet {
    public override void Effect()
    {
        
    }

    //부딪혔을 때 상대 오브젝트를 받아 HeadMount이면 영향을 주자
    public override void Hit(GameObject obj)
    {
        

        Effect();
    }

}
