using UnityEngine;
using System.Collections;

public class CollectedDart : MonoBehaviour {

    public DART_TYPE type;
    Material material;

    private void Start()
    {

        material = GetComponent<Renderer>().material;

        material.color = Color.white;
    }

    public void Collected()
    {

        switch (type) {
            case DART_TYPE.D:
                material.color = Color.red; break;
            case DART_TYPE.A:
                material.color = Color.yellow; break;
            case DART_TYPE.R:
                material.color = Color.green; break;
            case DART_TYPE.T:
                material.color = Color.blue; break;
        }
    }
}
