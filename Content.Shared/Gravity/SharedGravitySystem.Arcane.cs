using Content.Shared._Arcane.Camera;
using Robust.Shared.Player;

namespace Content.Shared.Gravity;

public abstract partial class SharedGravitySystem
{
    [Dependency] private ESScreenshakeSystem _shake = default!;

    private static readonly ESScreenshakeParameters GridShake = new(0.8f, 0.04f, 0.015f);

    private bool TryScreenshakeGrid(EntityUid uid)
    {
        _shake.Screenshake(Filter.BroadcastGrid(uid), GridShake, null);
        return true;
    }
}