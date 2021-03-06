﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ControllableThrower
{

    protected override IEnumerator PressContinuously()
    {
		MakeBullet ();
		madeObject.GetComponent<Rigidbody> ().useGravity = false;
        for(int i = 0; i < 10; i++)
        {
            if (madeObject != null)
            {
                madeObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f) * Time.deltaTime;
                //크기값을 받아 크기를 키워주기
                //무게값을 받아 무게를 키워주기
                //이펙트 넣어주기
            }
            yield return new WaitForSeconds(0.1f);
        }
        FireBullet();
    }

    public override void FireBullet()
    {   
        if (madeObject != null)
        {
            madeObject.GetComponent<Rigidbody>().useGravity = true;
            madeObject.GetComponent<Rigidbody>().AddForce(transform.forward * _throwerPower /* 곱하기 추가된 무게를 더 해 주어야 한다.*/);
        }
    }

    public override void MakeBullet()
    {
        madeObject = Instantiate(_thrownObject, transform.position, Quaternion.identity);
    }
}
