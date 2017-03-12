using UnityEngine;
using System.Collections;

public class MachineGun : Weapon {

    private const float DEVIATION = 0.05f;
    private const float COOLDOWN = 0.075f;
    private float cooldown = 0;

    public override bool Fire()
    {
        if (cooldown > 0)
            return false;



        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;
        Vector3 localTarget = fwd * 100;

        Vector3 shift = Random.rotation * (fwd * DEVIATION);

               
        Quaternion t = Quaternion.LookRotation(localTarget + shift);



        GameObject _b = Resources.Load<GameObject>("Bullet");
        GameObject b = (GameObject)Instantiate(_b, transform.position, t);

        //b.GetComponent<Projectile>().target = target;

        cooldown = COOLDOWN;

        return true;
    }

    public void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
