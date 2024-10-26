using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingProjectile : Projectile, ITargetWeapon
{
    public Transform target;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Init(Transform pTarget)
    {
        base.Init();

        isReady = true;

        Destroy(this.gameObject, 10f);
    }

    public override void Update() // METODO CHAMADO A TODO FRAME
    {
        if (isReady == false) return;

        base.Update();

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;

        //Dar dano

        other.gameObject.GetComponent<IDamageable>().TakeDamage(brain.Damage);

        Destroy(this.gameObject);
    }
}
