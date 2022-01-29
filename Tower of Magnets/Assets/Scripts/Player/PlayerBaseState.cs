public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerMovement player);

    public abstract void UpdateState(PlayerMovement player);
    
    public abstract void FixedUpdateState(PlayerMovement player);
}
