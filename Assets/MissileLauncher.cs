using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
	}

    private const float COOLDOWN = 1f;
    private float cooldown = 0;

    public override bool Fire()
    {
        if (cooldown > 0)
            return false;

        foreach (var missile in transform.parent.GetComponentsInChildren<Missile>())
        {
            missile.enabled = true;
            missile.transform.parent = null;
            break;
        }

        
      

        cooldown = COOLDOWN;

        return true;
    }
}
