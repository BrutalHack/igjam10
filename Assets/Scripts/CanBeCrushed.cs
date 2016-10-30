using UnityEngine;
using System.Collections;

public class CanBeCrushed : MonoBehaviour
{
    public float MaximumPressure = 2.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.impulse.magnitude > MaximumPressure)
        {
            Debug.Log("Wanze wurde zerquestscht " + collision.impulse.magnitude);
        }
    }
}