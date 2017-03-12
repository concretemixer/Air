using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Plane : MonoBehaviour {

    public Transform target;
    public Transform indicator;
    public Transform hull;

    float speed = 20f;
    float turn = .3f;

    Vector3 mp;

    // Use this for initialization
    void Start () {
        mp = Input.mousePosition;
        indicator.position = transform.position;
	}


    Vector3 control = Vector3.zero;
    // Update is called once per frame
    void Update () {
        Vector3 diff = Input.mousePosition - mp;

        control += diff * 0.01f;

        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;        
        Vector3 side = Vector3.Cross(Vector3.up, fwd);
        side.Normalize();     

        indicator.position = transform.position + Vector3.up * control.y * 10+ side* control.x* 10 + Vector3.up * 4;

        control.x = Mathf.Clamp(control.x, -1, 1);
        control.y = Mathf.Clamp(control.y, -1, 1);


        mp += diff;

        if (Input.GetMouseButton(0))
        {
            foreach (var w in GetComponentsInChildren<Weapon>())
                w.Fire();
        }
    }

    void SetTarget()
    {
        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;
        Vector3 side = Vector3.Cross(Vector3.up, fwd);
        side.Normalize();

        fwd.y = 0;
        fwd.Normalize();

        target.position = transform.position + fwd * 100 + side*100*control.x + 100*Vector3.up*control.y;
        
    }

    void FixedUpdate()
    {
        SetTarget();


        Vector3 fwd = transform.localToWorldMatrix * Vector3.forward;
        transform.position += fwd * speed * Time.fixedDeltaTime;
        Vector3 localTarget = (target.position - transform.position);
        

        float tilt =  Mathf.Clamp(Vector3.Angle(new Vector3(localTarget.x, 0, localTarget.z),
            new Vector3(fwd.x, 0, fwd.z)), 0, 45);
        if (Vector3.Cross(localTarget, fwd).y < 0)
            tilt = -tilt;

        hull.transform.localRotation = Quaternion.Euler(0, 0, tilt);


        Vector3 _up = Quaternion.AngleAxis(tilt,fwd) * Vector3.up;
        Vector3 up = transform.worldToLocalMatrix * _up;
        Quaternion t = Quaternion.LookRotation(localTarget);
        
        transform.localRotation = Quaternion.Slerp(transform.localRotation, t, Time.fixedDeltaTime);

        //target.transform.position += fwd * speed * Time.fixedDeltaTime;



          //EditorApplication.isPaused = true;
       
    }

}
