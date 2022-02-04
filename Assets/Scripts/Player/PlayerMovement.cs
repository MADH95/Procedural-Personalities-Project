
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;

    public float speed = 4f;
    public float airSpeedMult = 1f;

    public float jumpHeight = 1.5f;
    public float jumpCooldown = .2f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private Vector3 inputDir = Vector3.zero;
    private bool isGrounded = true, canJump = true;
    private float jumpCooldownAccum = 0f;

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere( groundCheck.position, groundDistance, groundMask );

        inputDir = Vector3.zero;

        inputDir = transform.right * Input.GetAxis( "Horizontal" ) + transform.forward * Input.GetAxis( "Vertical" );

        if ( Input.GetButtonDown( "Jump" ) && isGrounded && canJump )
        {
            Vector3 offset = new Vector3( 0f, -rigidbody.velocity.y, 0f );
            rigidbody.AddForce( Vector3.up * Mathf.Sqrt( jumpHeight * -2f * Physics.gravity.y ) + offset, ForceMode.VelocityChange );
            canJump = false;
        }

        
        if ( !canJump )
		{
            jumpCooldownAccum += Time.deltaTime;

            if ( jumpCooldownAccum >= jumpCooldown )
            {
                canJump = true;
                jumpCooldownAccum = 0f;
            }
		}
    }

	private void FixedUpdate ()
	{
        Vector3 velocity = inputDir * ( isGrounded ? speed : speed * airSpeedMult );

        velocity.y = rigidbody.velocity.y;

        rigidbody.velocity = velocity;

	}
}
