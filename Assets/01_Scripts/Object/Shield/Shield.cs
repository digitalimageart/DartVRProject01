using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    [SerializeField]
    private Transform ShieldEffect;

    public int HealthPoint = 2000;
    
    public void ShieldHit(int score)
    {
        HealthPoint += score;
        CheckShieldBroken();
    }

    private void CheckShieldBroken()
    {
        if (HealthPoint <= 0)
        {
            ShieldDestroy();
        }
    }
    private void ShieldDestroy()
    {
        Transform obj = Instantiate(ShieldEffect, this.transform);
        Invoke("DestoryObj",2.5f);
    }

    private void DestoryObj()
    {
        Destroy(this.gameObject);
    }


}
