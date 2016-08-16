using UnityEngine;
using System.Collections;

public class WaterLevelChecker : MonoBehaviour {

    private PolyGrow beakerWater;
    private int layerMask;

	void Start () {
        beakerWater = FindObjectOfType<PolyGrow>();
	    layerMask = LayerMask.GetMask("MetaBalls");
    }
	
    public void SetTarget(Vector3 position, float target)
    {
        
    }
}
