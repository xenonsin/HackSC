using UnityEngine;
using System.Collections;

public class DST_Source : MonoBehaviour {

    public int Width, Length, Height;
    private DST masterDST = null;
    private bool destroyed = false;

	
	void Start () {
        masterDST = FindObjectOfType<DST>();
	}

    public void BeginDestructionSequence()
    {
        if (masterDST != null)
        {
            masterDST.MoveTo(transform.position, Width, Length, Height, transform);
        }
    }
	
	
	void Update () {
        if(!destroyed)
        {
            if (Input.GetKey("space"))
            {
                BeginDestructionSequence();
                destroyed = true;
            }
        }
	    // Check for collisions
        // Fire BeginDestructionSequence() when desired
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
            BeginDestructionSequence();
    }
}
