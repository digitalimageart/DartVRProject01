using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnergyBar : MonoBehaviour {

    private Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        material.color = Color.green;
    }

    public void ChangeGaugeScore(int score, int originScore)
    {
        Transform transform = GetComponent<Transform>();
        Vector3 scaleVector = transform.localScale;

        transform.localScale += new Vector3((float)score/(float)originScore * 10,0,0);

        if(DataManager.Instance.score <= 500)
        {
            material.color = Color.red;
        }
    }
}
