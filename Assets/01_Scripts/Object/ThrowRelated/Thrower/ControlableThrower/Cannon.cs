using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ControllableThrower
{

    protected override IEnumerator PressContinuously()
    {
<<<<<<< HEAD
        MakeThrownObject();
        madeObject.GetComponent<Rigidbody>().useGravity = false;
        while (true)
        {
            if (madeObject != null)
            {
                madeObject.transform.localScale += new Vector3(1, 1, 1);
                //무게값을 받아 무게를 키워주기
                //이펙트 넣어주기
            }
=======
		MakeThrownObject ();
		madeObject.GetComponent<Rigidbody> ().useGravity = false;
        while (true)
        {
			if(madeObject != null)
				madeObject.transform.localScale += new Vector3 (1, 1, 1);
            //크기값을 받아 크기를 키워주기
            //무게값을 받아 무게를 키워주기
            //이펙트 넣어주기
>>>>>>> ce58283eee9e87fc80bc24cb23578924457e81a1
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override void ThrowObject()
<<<<<<< HEAD
    {   
        if (madeObject != null)
        {
            madeObject.GetComponent<Rigidbody>().useGravity = true;
            madeObject.GetComponent<Rigidbody>().AddForce(transform.forward * _throwerPower /* 곱하기 추가된 무게를 더 해 주어야 한다.*/);
        }
=======
    {
		if (madeObject != null) {
			madeObject.GetComponent<Rigidbody> ().useGravity = true;
			madeObject.GetComponent<Rigidbody> ().AddForce (transform.forward * _throwerPower); /* 곱하기 추가된 무게를 더 해 주어야 한다.*/
		}
>>>>>>> ce58283eee9e87fc80bc24cb23578924457e81a1
    }

    
}
