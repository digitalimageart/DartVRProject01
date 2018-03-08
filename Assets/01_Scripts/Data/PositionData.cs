using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData: MonoBehaviour {

    private const int _positionNum = 4;
    
    [SerializeField]
    private Transform[] _positions;
	// Use this for initialization
	

    public Transform[] GetPositions()
    {
        Transform[] ret = new Transform[_positionNum];
        int randNum;

        for(int i = 0; i < _positionNum; i++)
        {
            randNum = (new System.Random()).Next(0, 4);
            ret[i] = _positions[4*i + randNum];
        }

        return ret;
    }

}
