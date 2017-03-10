using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Plane : MonoBehaviour {

    public Transform target;
    public Transform target2;

    float speed = 20;
    float turn = .3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;
        transform.position += fwd * speed * Time.fixedDeltaTime;
        Vector3 localTarget = (target.position - transform.position);

        float tilt = Mathf.Clamp(Vector3.Angle(localTarget, fwd), -45, 45);
        
        Vector3 _up = Quaternion.AngleAxis(tilt,localTarget) * Vector3.up;
        Vector3 up = transform.worldToLocalMatrix * _up;
        Quaternion t = Quaternion.LookRotation(localTarget,up);
        
        transform.localRotation = Quaternion.Slerp(transform.localRotation, t, Time.fixedDeltaTime);

      //  target2.position = target.position + _up * 20;

      //  EditorApplication.isPaused = true;
    }

}
