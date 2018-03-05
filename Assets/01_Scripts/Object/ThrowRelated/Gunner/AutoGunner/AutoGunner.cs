using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunner : MonoBehaviour,Gunner {

    [SerializeField]
    private GameObject _thrownObject;
    [SerializeField]
    private float _throwerPower;

    private Transform point1;
    private Transform point2;
    private Transform point3;

    private GameObject madeObejct;

    public void setPoints(GameObject p1, GameObject p2, GameObject p3)
    {
        point1 = p1.transform;
        point2 = p2.transform;
        point3 = p3.transform;

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
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void FireBullet()
    {
        madeObejct.GetComponent<Rigidbody>().AddForce(transform.forward * _throwerPower);
    }

    public void MakeBullet()
    {
        madeObejct = Instantiate(_thrownObject, transform.position, Quaternion.identity);
    }   
}
