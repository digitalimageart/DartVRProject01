using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableThrower : MonoBehaviour, Gunner{

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
            FireBullet();
        }
    }

    protected abstract IEnumerator PressContinuously();

    public abstract void FireBullet();

    public void MakeBullet()
    {
        madeObject = Instantiate(_thrownObject, transform.position, Quaternion.identity);
    }
}
