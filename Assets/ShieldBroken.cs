using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBroken : MonoBehaviour {

    [SerializeField]
    private Transform[] positions;

	// Use this for initialization
	void Start () {
        positions = gameObject.GetComponentsInChildren<Transform>();
        StartCoroutine("ShieldBreakEffect");

	}

    IEnumerator ShieldBreakEffect()
    {
        GameObject obj;
        for (int i = 1; i < positions.Length; i++)
        {
             obj = Instantiate(DataManager.Instance.Effects[1], positions[i]);
            yield return new WaitForSeconds(0.5f);
        }

        obj = Instantiate(DataManager.Instance.Effects[2], this.transform);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
