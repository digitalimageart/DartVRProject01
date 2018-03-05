using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : ControllableThrower {

    [SerializeField]
    private float _fireInterval;

    protected override IEnumerator PressContinuously()
    {
        while (true)
        {
            MakeBullet();
            FireBullet();
            //이펙트 넣어주기
            yield return new WaitForSeconds(_fireInterval);
        }
    }

    public override void FireBullet()
    {
        madeObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * _throwerPower);
    }

}
