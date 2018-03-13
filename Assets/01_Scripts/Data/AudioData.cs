using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData : MonoBehaviour {

    AudioSource src;

	// Use this for initialization
	void Start () {
        src = GetComponent<AudioSource>();
        src.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
