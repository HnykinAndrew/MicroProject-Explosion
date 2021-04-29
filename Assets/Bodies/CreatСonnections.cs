using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatСonnections : MonoBehaviour
{
    public GameObject parent;
    public float break_force = 300;
    public float break_torque = 300;

    void Start()
    {
        Collider[] hitColliders = Physics.OverlapBox(this.transform.position, this.transform.localScale / 60, this.transform.rotation);
        
        for (int i = 0; i < hitColliders.Length - 1; i++)
        {
            FixedJoint joint = hitColliders[i].gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = hitColliders[i + 1].gameObject.GetComponent<Rigidbody>();
            joint.breakForce = break_force;
            joint.breakTorque = break_torque;
        }
    }
}
