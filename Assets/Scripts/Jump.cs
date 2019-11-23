using UnityEngine;

public class Jump : MonoBehaviour
{
    private Animator animator;
    private Rigidbody playerRigidbody;
    [SerializeField] private bool isGrounded;
    public LayerMask GroundLayers;
    public float GroundCheckLength = 0.0f;
    private Vector3 jumpVector;
    private bool flyUp = false;
    private bool flyTop = false;
    private bool flyDown = true;
    private bool canJump = false;
    private bool start = false;
    private bool emergency = false;
    private bool detonateJump = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        GroundCheckLength += GetComponent<CapsuleCollider>().height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsGrounded();
        CheckVelocityForAnimation();
    }

    public void PrepareJump()
    {
        if(!canJump)
        {
            GetComponent<Drop>().drop();
        }
        if (canJump && !start)
        {
            animator.SetTrigger("Start");
            start = true;
        }
    }

    private void CheckVelocityForAnimation()
    {
        if (flyUp && !flyTop && playerRigidbody.velocity.y == 0)
        {
            flyTop = true;
            animator.SetTrigger("Top");
        }else if (!flyDown && !isGrounded && playerRigidbody.velocity.y < -0.1)
        {
            flyDown = true;
            animator.SetBool("FlyDown", true);
        }
        else if (flyDown && isGrounded)
        {
            animator.SetTrigger("Land");
            animator.SetBool("FlyDown", false);
            flyDown = false;
            flyTop = false;
            flyUp = false;
            detonateJump = false;
        }else if (!emergency && !canJump && isGrounded)
        {
            if (detonateJump)
            {
                detonateJump = false;
                return;
            }
            emergency = true;
            animator.SetTrigger("Emergency");
            animator.SetBool("FlyDown", false);
            flyDown = false;
            flyTop = false;
            flyUp = false;
        }
    }

    private void UpdateIsGrounded()
    {
        Vector3 relativeDown = transform.TransformDirection(Vector3.down);
        Vector3 relativeDownFront = transform.TransformDirection(Vector3.down) +
                                    transform.TransformDirection(Vector3.right);
        Vector3 relativeDownBack = transform.TransformDirection(Vector3.down) +
                                   transform.TransformDirection(Vector3.left);
        relativeDownFront.Normalize();
        relativeDownFront = relativeDownFront * relativeDown.magnitude;
        relativeDownBack.Normalize();
        relativeDownBack = relativeDownBack * relativeDown.magnitude;
        isGrounded = Physics.Raycast(transform.position, relativeDown, GroundCheckLength, GroundLayers);
        Debug.DrawLine(transform.position, transform.position + relativeDown * GroundCheckLength, Color.red);
        Debug.DrawLine(transform.position, transform.position + relativeDownBack * GroundCheckLength, Color.blue);
        Debug.DrawLine(transform.position, transform.position + relativeDownFront * GroundCheckLength, Color.yellow);
    }

    public void StartJump(Vector3 jumpVector)
    {
        if (canJump && start)
        {
            playerRigidbody.AddForce(jumpVector, ForceMode.Impulse);
            animator.SetTrigger("Up");
            flyUp = true;
            canJump = false;
            detonateJump = true;
        }
        start = false;
    }

    public void BreakUpJump()
    {
        animator.SetTrigger("Emergency");
        start = false;
    }

    public void AllowJump()
    {
        canJump = true;
        emergency = false;
        animator.ResetTrigger("Start");
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Top");
        animator.ResetTrigger("Land");
        animator.ResetTrigger("Emergency");
    }
}
