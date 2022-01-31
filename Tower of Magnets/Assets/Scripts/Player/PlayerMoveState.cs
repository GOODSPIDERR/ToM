using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float inputX;
    private Transform spriteTransform;
    private float initialSpriteTransform;
    private bool grounded;
    private Rigidbody2D rb;
    private float jumpForce;
    private Animator playerAnimator;
    private float movementSpeed;
    
    public override void EnterState(PlayerMovement player)
    {
        spriteTransform = player.spriteTransform;
        initialSpriteTransform = player.initialSpriteTransform;
        rb = player.rb;
        jumpForce = player.jumpForce;
        playerAnimator = player.playerAnimator;
        movementSpeed = player.movementSpeed;
    }

    public override void UpdateState(PlayerMovement player)
    {
        grounded = player.grounded;
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX < 0f)
            spriteTransform.localScale = new Vector2(-initialSpriteTransform, initialSpriteTransform);
        else if (inputX > 0f)
        {
            spriteTransform.localScale = new Vector2(initialSpriteTransform, initialSpriteTransform);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Switch(true, 20);
            player.SwitchState(player.StunnedState);
        }

        if (!grounded)
        {
            player.SwitchState(player.AirState);
        }
        
        playerAnimator.SetFloat("Speed", Mathf.Abs(inputX));

        Debug.Log("YOU ARE IN MOVE STATE");
    }
    public override void FixedUpdateState(PlayerMovement player)
    {
        rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
    }
}
