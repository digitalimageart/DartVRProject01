using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciator : MonoBehaviour {

    public GameObject gameObject;
    

    private void Start()
    {
        StartCoroutine("Maker");
    }

    private IEnumerator Maker()
    {
        while (true)
        {
            Instantiate(gameObject.transform,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }
    }
}
