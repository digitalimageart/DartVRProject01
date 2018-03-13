using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public int HealthPoint = 500;

    public void ShildDestroy()
    {
        Destroy(this.gameObject);
    }

}
