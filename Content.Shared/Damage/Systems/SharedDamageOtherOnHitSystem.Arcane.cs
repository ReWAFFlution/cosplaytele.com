using Content.Shared._Arcane.Camera;

namespace Content.Shared.Damage.Systems;

public abstract partial class SharedDamageOtherOnHitSystem
{
    [Dependency] private ESScreenshakeSystem _shake = default!;

    private static readonly ESScreenshakeParameters HitShake = new(0.35f, 1.4f, 0.014f);
}