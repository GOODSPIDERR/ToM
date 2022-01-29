using UnityEngine;
using DG.Tweening;

public class PlayerStunnedState : PlayerBaseState
{
    private Rigidbody2D rb;
    public override void EnterState(PlayerMovement player)
    {
        rb = player.rb;
        
        rb.constraints = RigidbodyConstraints2D.None;
    }
    public override void UpdateState(PlayerMovement player)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = Vector2.zero;
            player.yVelocity = 2f;
            player.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.25f);
            
            player.Switch(false);
            player.SwitchState(player.AirState);
        }
        
        Debug.Log("YOU ARE IN STUNNED STATE");
    }
    public override void FixedUpdateState(PlayerMovement player)
    {
        
    }
}
