using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunner : Gunner { 

    public float fireInterval
    {
        get; set;
    }
    public Transform target
    {
        get; set;
    }


    IEnumerator GunnerMove()
    {
        Transform[] pos;

        while (true)
        {
            pos = GunnerManager.Instance.GetMakePositions();

            for (int i = 0; i < 4; i++)
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", pos[i].position.x, "y", pos[i].position.y, "z", pos[i].position.z, "easeType", "easeInOutExpo", "loopType", "none"));
                yield return new WaitForSeconds(0.8f);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("ThrowContinuously");
        StartCoroutine("GunnerMove");
    }

    IEnumerator ThrowContinuously()
    {
        while (true)
        {
            MakeBullet();
            FireBullet();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    public override void FireBullet()
    {
        _madeBullet.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * firePower);
    }
}