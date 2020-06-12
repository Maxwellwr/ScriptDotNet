namespace ScriptDotNet
{
    public enum RejectMoveItemReason : byte
    {
        CanNotPickUp = 0,
        TooFarAway = 1,
        OutOfSight = 2,
        DoesNotBelong = 3,
        AlreadyHolding = 4,
        MustWait = 5
    }
}
