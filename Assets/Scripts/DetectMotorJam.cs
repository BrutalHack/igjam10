using System;
using UnityEngine;
using System.Collections;

public class DetectMotorJam : MonoBehaviour
{
    public int MaxTorque = 50;
    private HingeJoint2D _hingeJoint2D;

    // Use this for initialization
    void Start()
    {
        _hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var motorTorque = _hingeJoint2D.GetMotorTorque(0.1f);
        if (motorTorque > MaxTorque)
        {
            Debug.Log("RESET!");
            Debug.Break();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
//        Debug.Log(collision.contacts[0].collider.gameObject.name + ": " +
//                  collision.contacts[0].collider.gameObject.GetComponent<HingeJoint2D>().GetMotorTorque(0.1f));
//        Debug.Log("velocity: " + collision.relativeVelocity + ";     inertia: " + this.GetComponent<Rigidbody2D>().inertia);
    }
}