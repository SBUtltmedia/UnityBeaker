using UnityEngine;
using System.Collections;

public class ResourceDirectories : MonoBehaviour {

    //folders
    private static string LiquidPhysicsRoot = "LiquidPhysics/";
    private static string PrefabRoot = "Prefabs/";
    private static string ParticleRoot = PrefabRoot + "Particles/";

    //liquid phyiscs includes
    public static string DefaultDynamicParticle = LiquidPhysicsRoot+"DynamicParticle";

    //Prefabs
    public static string ParticleSpawner = ParticleRoot + "ParticleSpawner";
    public static string DynamicParticle = ParticleRoot + "DynamicParticle";
}
