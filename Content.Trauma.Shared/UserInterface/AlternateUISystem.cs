// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.UserInterface;
using Content.Shared.Verbs;

namespace Content.Trauma.Shared.UserInterface;

public sealed partial class AlternateUISystem : EntitySystem
{
    [Dependency] private ActivatableUISystem _aui = default!;
    [Dependency] private EntityQuery<ActivatableUIComponent> _auiQuery = default!;

    [SubscribeLocalEvent]
    private void OnGetVerbs(Entity<AlternateUIComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        var aui = _auiQuery.Comp(ent);
        if (!_aui.ShouldAddVerb(ent, aui, args))
            return;

        var user = args.User;
        args.Verbs.Add(new AlternativeVerb
        {
            Act = () => { var interactionParticle = false; _aui.InteractUI(user, ent, aui, ref interactionParticle, ent.Comp.Key); }, // Arcane-Edit
            Text = ent.Comp.VerbText,
            Icon = new SpriteSpecifier.Texture(new ResPath("/Textures/Interface/VerbIcons/settings.svg.192dpi.png"))
        });
    }
}
