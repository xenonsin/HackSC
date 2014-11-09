using UnityEngine;
using System.Collections;

public class DST_Source : MonoBehaviour {

    private bool destroyed = false;
    private AutoDelete[] components;

	
	void Start () {
        components = GetComponentsInChildren<AutoDelete>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].rigidbody != null)
            {
                components[i].rigidbody.isKinematic = true;
                components[i].rigidbody.useGravity = false;
            }
        }
	}

    public void BeginDestructionSequence()
    {
        components = GetComponentsInChildren<AutoDelete>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].rigidbody != null)
            {
                components[i].rigidbody.isKinematic = false;
                components[i].rigidbody.useGravity = true;
            }
        }
        ApplyPhysics();
    }

    private void ApplyPhysics()
    {
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] != null)
            {
                if (components[i].rigidbody != null)
                {
                    components[i].rigidbody.AddForce(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
                }
            }
        }
    }
}
