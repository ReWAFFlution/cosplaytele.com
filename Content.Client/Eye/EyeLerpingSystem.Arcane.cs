using Content.Shared._Arcane.Camera;

namespace Content.Client.Eye;

public sealed partial class EyeLerpingSystem
{
    private Angle GetShakeRotation(EntityUid uid)
    {
        var ev = new ESGetEyeRotationEvent();
        RaiseLocalEvent(uid, ref ev);
        return ev.Rotation;
    }
}
