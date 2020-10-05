using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10;
    public float jumpImpulse = 700;
    public float allowedHoverTime = 0.5F;
    public float jumpCooldown = 1;
    public float timeToDesiredSpeed = 0.01f;

    public float betweenSteps = 0.1F;

    public float lastWalk = -100;


    private float lastGrounded;
    private float lastJump = -100;
    private Rigidbody2D rb2d;
    private List<Vector2> positions = new List<Vector2>();

    public float stepLength = 0.8f * 1.16f;
    public readonly float animationLength = 0.667f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        foreach (var cam in FindObjectsOfType<CameraFollow>())
        {
            if (cam)
            {
                cam.target = transform;
            }
        }
    }
    public ReadOnlyCollection<Vector2> History
    {
        get
        {
            return this.positions.AsReadOnly();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (var point in collision.contacts)
        {
            UnityEngine.Debug.DrawLine(point.point, point.point + point.normal, Color.red);
            if (point.normal.y > 0)
            {
                lastGrounded = Time.time;
                //break;
            }
        }
    }

    private bool IsAlmostGrounded()
    {
        return Time.time - lastGrounded < allowedHoverTime;
    }

    private bool Jumped()
    {
        bool jumped = Input.GetButton("Jump") && IsAlmostGrounded() && Time.time - lastJump > jumpCooldown;
        if (jumped)
        {
            lastJump = Time.time;
        }
        return jumped;
    }

    void FixedUpdate()
    {
        this.positions.Add(rb2d.position);

        if (Jumped())
        {
            rb2d.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }

        float xVelocity = rb2d.velocity.x;
        float walkAmount = Input.GetAxis("Horizontal");

        float desiredVelocity = walkAmount * walkSpeed;
        float velocityDelta = desiredVelocity - xVelocity;

        float desiredForce = rb2d.mass * Mathf.Clamp(velocityDelta, -walkSpeed, walkSpeed) / timeToDesiredSpeed;
        rb2d.AddForce(Vector2.right * (IsAlmostGrounded() ? desiredForce : (desiredForce / 2)), ForceMode2D.Force);


        float secondsPerStep = IsAlmostGrounded() ? stepLength / Mathf.Abs(desiredVelocity) : Mathf.Infinity;
        animator.speed = animationLength / secondsPerStep;
        if (Mathf.Abs(walkAmount) > 0.01)
        {
            spriteRenderer.flipX = walkAmount < 0;
        }

    }
}
