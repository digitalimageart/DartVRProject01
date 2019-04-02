using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GUNNER_TYPE
{
    NEGATIVE,
    DART
}

public class AutoGunner : Gunner {

    public static AutoGunnerBuilder AutoGunnerFactory(GUNNER_TYPE type, AutoGunner gunnerPrefab, Transform transform) {

        AutoGunnerBuilder ret = new AutoGunnerBuilder(Instantiate(gunnerPrefab, transform) as AutoGunner);

        switch (type) {
            case GUNNER_TYPE.NEGATIVE:
                ret.setGunnerType(GUNNER_TYPE.NEGATIVE);
                break;
            case GUNNER_TYPE.DART:
                ret.setGunnerType(GUNNER_TYPE.DART);
                break;
        }

        return ret;
    }

    public class AutoGunnerBuilder {

        private AutoGunner _gunner;
        public float fireInterval;
        public float firePower;
        public GUNNER_TYPE type;
        public Transform target;

        public AutoGunnerBuilder(AutoGunner gunner)
        {
            _gunner = gunner;
        }

        public AutoGunnerBuilder setFireInterval(float value) {
            fireInterval = value;
            return this;
        }

        public AutoGunnerBuilder setGunnerType(GUNNER_TYPE type) {
            this.type = type;
            return this;
        }

        public AutoGunnerBuilder setTarget(Transform target)
        {
            this.target = target;
            return this;
        }

        public AutoGunnerBuilder setFirePower(float power)
        {
            firePower = power;
            return this;
        }

        public AutoGunner Build() {
            AutoGunner ret = _gunner;
            return ret.GetAutoGunner(this);
        }

    }

    private AutoGunner GetAutoGunner(AutoGunnerBuilder builder)
    {
        _type = builder.type;
        _target = builder.target;
        _firePower = builder.firePower;
        _fireInterval = builder.fireInterval;
        return this;
    }

    private GUNNER_TYPE _type;
    public GUNNER_TYPE type { get { return _type; } }
    private float _fireInterval;
    public float fireInterval { get { return _fireInterval; } }
    private Transform _target;
    public Transform target { get { return _target; } }


    IEnumerator GunnerMove()
    {
        Transform[] pos;

        while (true)
        {
            pos = GunnerManager.Instance.GetMakePositions();

            for (int i = 0; i < 4; i++)
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", pos[i].position.x, "y", pos[i].position.y, "z", pos[i].position.z, "easeType", "easeInOutExpo", "loopType", "none"));
                yield return new WaitForSeconds(0.8f);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("ThrowContinuously");
        StartCoroutine("GunnerMove");
    }

    IEnumerator ThrowContinuously()
    {
        while (true)
        {
            if (!DataManager.Instance.isEffectBulletTime)
            {
                MakeBullet();
                FireBullet();
                if (type == GUNNER_TYPE.NEGATIVE)
                    yield return new WaitForSeconds(new System.Random().Next(1, 4));
                else
                    yield return new WaitForSeconds(fireInterval);
            }
        }
    }

    public override void FireBullet()
    {
        _madeBullet.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * _firePower);
    }

    public override void MakeBullet()
    {
        if (type == GUNNER_TYPE.DART)
            _bulletObject = GunnerManager.Instance.RetunRandomDartBullet();
        else
            _bulletObject = GunnerManager.Instance.ReturnRandomNegativeBullet();

        _madeBullet = Instantiate(_bulletObject, transform.position, Quaternion.identity) as Bullet;
    }
}