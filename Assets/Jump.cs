using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private bool isGrounded;
    public LayerMask GroundLayers;
    public float GroundCheckLength = 0.0f;

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        GroundCheckLength += GetComponent<CapsuleCollider>().height/2;
        Debug.Log("Length: " + GroundCheckLength);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsGrounded();
        if (isGrounded)
        {
            StartJump(Vector3.up, 50f);
        }
    }

    private void UpdateIsGrounded()
    {
        Vector3 relativeDown = transform.TransformDirection(Vector3.down);
        Vector3 relativeDownFront = transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.right);
        Vector3 relativeDownBack = transform.TransformDirection(Vector3.down) + transform.TransformDirection(Vector3.left);
        relativeDownFront.Normalize();
        relativeDownFront = relativeDownFront * relativeDown.magnitude;
        relativeDownBack.Normalize();
        relativeDownBack = relativeDownBack * relativeDown.magnitude;
        isGrounded = Physics.Raycast(transform.position, relativeDown, GroundCheckLength, GroundLayers);
        Debug.Log(isGrounded);
        Debug.DrawLine(transform.position, transform.position + (relativeDown * GroundCheckLength), Color.red);
        Debug.DrawLine(transform.position, transform.position + (relativeDownBack * GroundCheckLength), Color.blue);
        Debug.DrawLine(transform.position, transform.position + (relativeDownFront * GroundCheckLength), Color.yellow);
    }

    public void StartJump(Vector3 direction, float force)
    {
        if (isGrounded)
        {
            playerRigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}