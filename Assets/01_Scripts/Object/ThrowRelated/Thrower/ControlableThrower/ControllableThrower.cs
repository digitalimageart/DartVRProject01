using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableThrower : MonoBehaviour, Thrower{

    [SerializeField]
    private GameObject _thrownObject;
    [SerializeField]
    protected float _throwerPower;
    [SerializeField]
    private int _controllerType;

    protected GameObject madeObject;

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode) _controllerType))
        {
            StartCoroutine("PressContinuously");
        }

        if (Input.GetKeyUp((KeyCode) _controllerType))
        {
            StopCoroutine("PressContinuously");
            ThrowObject();
        }
    }

    protected abstract IEnumerator PressContinuously();

    public abstract void ThrowObject();

    public void MakeThrownObject()
    {
        madeObject = Instantiate(_thrownObject, transform.position, Quaternion.identity);
    }
}
