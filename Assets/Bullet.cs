using UnityEngine;
using System.Collections;

public class Bullet : Projectile {

    private const float LIFETIME = 0.5f;
    private const float SPEED = 500.0f;


    private float life = 0;

    Vector3[] p = { Vector3.zero, Vector3.zero };
	// Use this for initialization
	void Start () {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPositions(p);
	}
	
	// Update is called once per frame
	void Update () {
        life += Time.deltaTime;
        if (life > LIFETIME)
            Destroy(this.gameObject);
        else {
            float k = 1.0f - life / LIFETIME;

            LineRenderer lr = GetComponent<LineRenderer>();
            lr.SetColors(new Color(1, 1, 1, k), new Color(1, 1, 0, 0));

            p[0].z += 0.5f * SPEED * Time.deltaTime;
            p[1].z += SPEED * Time.deltaTime;
            lr.SetPositions(p);
        }
	}
}
