using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunner : MonoBehaviour,Gunner {

    [SerializeField]
    private Transform _tmpTarget;
    [SerializeField]
    private GameObject _bulletObject;
    
    public float firePower
    {
        get; set;
    }
    public float fireInterval
    {
        get;set;
    }
    public Vector3 target
    {
        get;set;
    }
    
    private GameObject _madeBullet;
    
    
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
    void Start () {
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

    public void FireBullet()
    {
        _madeBullet.GetComponent<Rigidbody>().AddForce( -target * firePower);
    }

    public void MakeBullet()
    {
        _madeBullet = Instantiate(_bulletObject, transform.position, Quaternion.identity);
    }   
}
