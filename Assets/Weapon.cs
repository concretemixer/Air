using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public bool Primary;
    protected Vector3 target;

    public virtual bool Fire()
    {
        return false;
    }

    public virtual void UpdateTarget(GameObject trg)
    {
        
    }
}
