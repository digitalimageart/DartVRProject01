using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBenefitFactor : ThrownObject
{
    [SerializeField]
    private int _addingScore;

    public override void hit(GameObject obj)
    {
        obj.GetComponent<Target>().AddScore(_addingScore);

        //이펙트 넣기
    }
}
