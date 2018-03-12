using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableThrower : Gunner{

    [SerializeField]
    protected GameObject _thrownObject;
    [SerializeField]
    protected float _throwerPower;
    [SerializeField]
    private int _controllerType;

    protected GameObject madeObject;

    private bool triggerButtonDown = false;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;


    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    private void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        triggerButtonDown = device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger);

        if (triggerButtonDown)
        {
            StartCoroutine("PressContinuously");
        }
        
        
    }

    protected abstract IEnumerator PressContinuously();
    
}
