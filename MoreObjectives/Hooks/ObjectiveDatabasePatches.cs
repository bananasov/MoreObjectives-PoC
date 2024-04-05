using MonoMod.Cil;
using MoreObjectives.Objectives;

namespace MoreObjectives.Hooks;

public static class ObjectiveDatabasePatches
{
    public static void Init()
    {
        IL.ObjectiveDatabase.Initialize += ObjectiveDatabaseOnInitialize;
        On.ObjectiveDatabase.Initialize += ObjectiveDatabaseOnInitialize;
    }

    private static void ObjectiveDatabaseOnInitialize(On.ObjectiveDatabase.orig_Initialize orig)
    {
        orig();
        ObjectiveDatabase.types.Add(15, typeof(ExampleObjective)); // TODO: Loop through a registry and add to types list
    }

    private static void ObjectiveDatabaseOnInitialize(ILContext il)
    {
        var c = new ILCursor(il);
        c.GotoNext(x => x.MatchLdcI4(15)); // TODO: Better checking for this, i highly doubt this is the way
        c.Next.Operand = 16; // TODO: Update this accordingly, this is just the capacity (for optimizations) and should update automatically.
    }
}