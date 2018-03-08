using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunner : MonoBehaviour,Gunner {

    [SerializeField]
    private Transform _tmpTarget;
    [SerializeField]
    private GameObject _bulletObject;
    [SerializeField]
    private float _firePower;
    [SerializeField]
    private float _fireInterval;

    private Transform point1;
    private Transform point2;
    private Transform point3;

    private GameObject _madeBullet;
    
    public void SetFireInterval(float fireInterval)
    {
        _fireInterval = fireInterval;
    }

    public void SetPoints(Transform p1, Transform p2, Transform p3)
    {
        point1 = p1;
        point2 = p2;
        point3 = p3;

        StartCoroutine("GunnerMove");
    }

    IEnumerator GunnerMove()
    {
        while(true)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", point1.transform.position.x, "easeType", "easeInOutExpo", "loopType", "none", "y", point1.transform.position.y, "z", point1.transform.position.z));
            yield return new WaitForSeconds(0.8f);
            iTween.MoveTo(gameObject, iTween.Hash("x", point2.transform.position.x, "easeType", "easeInOutExpo", "loopType", "none", "y", point2.transform.position.y, "z", point2.transform.position.z));
            yield return new WaitForSeconds(0.8f);
            iTween.MoveTo(gameObject, iTween.Hash("x", point3.transform.position.x, "easeType", "easeInOutExpo", "loopType", "none", "y", point2.transform.position.y, "z", point3.transform.position.z));
            yield return new WaitForSeconds(0.8f);
            iTween.MoveTo(gameObject, iTween.Hash("x", point2.transform.position.x, "easeType", "easeInOutExpo", "loopType", "none", "y", point2.transform.position.y, "z", point2.transform.position.z));
            yield return new WaitForSeconds(0.8f);
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine("ThrowContinuously");
	}

    IEnumerator ThrowContinuously()
    {
        while (true)
        {
            MakeBullet();
            FireBullet();
            yield return new WaitForSeconds(_fireInterval);
        }
    }

    public void FireBullet()
    {
        _madeBullet.GetComponent<Rigidbody>().AddForce( (_tmpTarget.position - transform.position).normalized * _firePower);
    }

    public void MakeBullet()
    {
        _madeBullet = Instantiate(_bulletObject, transform.position, Quaternion.identity);
    }   
}
