using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool triggerButtonDown = false;
    private bool isGripped = false;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    [SerializeField]
    private Shield _shieldPrefab;
    private Shield _shield;

    private bool isShieldEnabled = false;


    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        _shield = Instantiate(_shieldPrefab, this.transform);
        _shield.gameObject.SetActive(false);
    }
    private void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        triggerButtonDown = device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger);
        //isGripped = device.GetPress(SteamVR_Controller.ButtonMask.Grip);

        if (triggerButtonDown)
        {
            if (isShieldEnabled)
            {
                _shield.gameObject.SetActive(false);
                isShieldEnabled = false;
            }
            else
            {
                _shield.gameObject.SetActive(true);
                isShieldEnabled = true;
            }
        }

        //if (isGripped)
        //{
        //    if (DataManager.Instance.spcAtkNum  > 0)
        //    {
        //        DataManager.Instance.spcAtkNum--;
        //        DataManager.Instance.FireSpcAtk();
        //    }
        //}
    }
}
