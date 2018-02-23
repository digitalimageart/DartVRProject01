using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoThrower : MonoBehaviour,Thrower {

    [SerializeField]
    private GameObject _thrownObject;
    [SerializeField]
    private float _throwerPower;

    private GameObject madeObejct;

    // Use this for initialization
    void Start () {
        StartCoroutine("ThrowContinuously");
	}

    IEnumerator ThrowContinuously()
    {
        while (true)
        {
            MakeThrownObject();
            ThrowObject();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ThrowObject()
    {
        madeObejct.GetComponent<Rigidbody>().AddForce(transform.forward * _throwerPower);
    }

    public void MakeThrownObject()
    {
        madeObejct = Instantiate(_thrownObject, transform.position, Quaternion.identity);
    }   
}
