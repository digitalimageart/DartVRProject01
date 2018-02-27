using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour {

    [SerializeField]
	private int _score = 1000;
    private int _leftSpecial;

    [SerializeField]
    private int _key;
    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)_key))
            SpecialWeaponActive();
    }

    public void AddScore(int sc)
    {
        _score += sc;
    }

    public void UseSpecialWeapon()
    {
        _leftSpecial--;
        SpecialWeaponActive();
    }

    public abstract void SpecialWeaponActive();
}
