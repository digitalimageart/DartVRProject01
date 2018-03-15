using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    [SerializeField]
    private Transform ShieldEffect;
    [SerializeField]
    private TextMesh scoreText;

    public int HealthPoint = 2000;

    private void Start()
    {
        scoreText.text = HealthPoint.ToString();
    }

    public void ShieldHit(int score)
    {
        HealthPoint += score;
        if(HealthPoint >= 0)
        scoreText.text = HealthPoint.ToString();
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
        Invoke("DestoryObj",3f);
    }

    private void DestoryObj()
    {
        Destroy(this.gameObject);
    }


}
