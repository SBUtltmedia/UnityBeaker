using UnityEngine;
using System.Collections;

public class ResourceDirectories {

    //folders
    private static string LiquidPhysicsRoot = "LiquidPhysics/";
    private static string PrefabRoot = "Prefabs/";
    private static string ParticleRoot = PrefabRoot + "Particles/";
    private static string WorldObjectsRoot = PrefabRoot + "World Objects/";

    //liquid phyiscs includes
    public static string DefaultDynamicParticle = LiquidPhysicsRoot+"DynamicParticle";

    //Prefabs
    public static string ParticleSpawner = ParticleRoot + "ParticleSpawner";
    public static string DynamicParticle = ParticleRoot + "DynamicParticle";
    public static string Flask = WorldObjectsRoot + "Flask";
    public static string Beaker = WorldObjectsRoot + "Beaker";
}
