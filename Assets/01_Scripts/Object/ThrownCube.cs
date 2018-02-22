using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownCube : MonoBehaviour,ThrownObject {

    public void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * 10000);

        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    //부딪혔을 때 상대 오브젝트를 받아 HeadMount이면 영향을 주자
    public void hit(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }

}
