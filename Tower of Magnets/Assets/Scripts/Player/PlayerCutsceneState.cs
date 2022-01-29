using UnityEngine;

public class PlayerCutsceneState : PlayerBaseState
{
    public override void EnterState(PlayerMovement player)
    {
        
    }
    public override void UpdateState(PlayerMovement player)
    {
        Debug.Log("YOU ARE IN CUTSCENE STATE");
    }
    public override void FixedUpdateState(PlayerMovement player)
    {
        
    }
}
