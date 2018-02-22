using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ControllableThrower
{

    protected override IEnumerator PressContinuously()
    {
        while (true)
        {
            //크기값을 받아 크기를 키워주기
            //무게값을 받아 무게를 키워주기
            //이펙트 넣어주기
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override void ThrowObject()
    {
        //
        madeObject.GetComponent<Rigidbody>().AddForce(transform.forward * _throwerPower /* 곱하기 추가된 무게를 더 해 주어야 한다.*/);
    }

    
}
