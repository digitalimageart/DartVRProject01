﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    [SerializeField]
    private float _deathCount = 10f;
    [SerializeField]
    protected int _bulletPoint;

    [SerializeField]
    private GameObject audio;

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
            GameObject src = Instantiate(audio.gameObject);
            Hit(other.gameObject);
            Destroy(this.gameObject);
            DataManager.Instance.CheckGameOver();
        }

        if(other.tag == "Shield")
        {
            Effect();
            GameObject src = Instantiate(audio.gameObject);
            other.gameObject.GetComponent<Shield>().ShieldHit(_bulletPoint);
            Destroy(this.gameObject);
        }
    }

    //부딪혔을 때 상대 오브젝트를 받아 HeadMount이면 영향을 주자
    public abstract void Hit(GameObject obj);
    public abstract void Effect();

}
