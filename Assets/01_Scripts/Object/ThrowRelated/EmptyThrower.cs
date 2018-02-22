using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyThrower : MonoBehaviour,Thrower {

    [SerializeField]
    private GameObject gameObject;

    // Use this for initialization
    void Start () {
        StartCoroutine("ThrowContinuously");
	}

    IEnumerator ThrowContinuously()
    {
        while (true)
        {
            Throw();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void Throw()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
