using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDead : MonoBehaviour {

    public void Start()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
    
}
