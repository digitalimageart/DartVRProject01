using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrownObject : MonoBehaviour {

    [SerializeField]
    private float _deathCount = 4f;

    public void Start()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(_deathCount);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            hit(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    //부딪혔을 때 상대 오브젝트를 받아 HeadMount이면 영향을 주자
    public abstract void hit(GameObject obj);

}
