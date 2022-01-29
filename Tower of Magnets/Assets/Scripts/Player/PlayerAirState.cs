using UnityEditor;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    private Rigidbody2D rb;
    private float inputX;
    private float movementSpeed;
    private Transform spriteTransform;
    private float initialSpriteTransform;
    private bool grounded;
    
    public override void EnterState(PlayerMovement player)
    {
        rb = player.rb;
        movementSpeed = player.movementSpeed;
        spriteTransform = player.spriteTransform;
        initialSpriteTransform = player.initialSpriteTransform;
        
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
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Switch(true);
            player.SwitchState(player.StunnedState);
        }

        if (grounded)
        {
            player.SwitchState(player.MoveState);
        }
        
        Debug.Log("YOU ARE IN AIR STATE");
    }
    public override void FixedUpdateState(PlayerMovement player)
    {
        rb.AddForce(new Vector2(inputX * 12f,0), ForceMode2D.Force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -movementSpeed, movementSpeed), rb.velocity.y);
    }
}
