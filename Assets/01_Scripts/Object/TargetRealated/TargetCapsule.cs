using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCapsule : Target {

    public override void SpecialWeaponActive()
    {
        StartCoroutine("ChangeTag");
    }

    IEnumerator ChangeTag() {
        this.tag = "invincibility";

        yield return new WaitForSeconds(4f);

        this.tag = "Target";
    }

}
