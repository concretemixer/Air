using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile {

    float lifetime = 10;
    float speed = 100f;
    // Use this for initialization
    void Start () {
        GetComponent<ParticleSystem>().Play();	
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            DestroyObject(gameObject);
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;
        transform.position += fwd * speed * Time.fixedDeltaTime;
    }
}
