using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Remove");
	}

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(.5f);

        Destroy(this.gameObject);
    }
	
}
