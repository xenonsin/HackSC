using UnityEngine;
using System.Collections;

[System.Serializable]
public class AddMeshColliders : MonoBehaviour {

    public bool shouldAddColliders = false;
	// Use this for initialization
	void Start () {
#if !UNITY_EDITOR
        shouldAddColliders = true;
#endif
        if (shouldAddColliders)
        {
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach (Transform t in children)
            {
                if (t.GetComponent<MeshCollider>() == null)
                {
                    t.gameObject.AddComponent<MeshCollider>();
                }
            }
        }
        else
            Debug.Log("This is not setting up the colliders!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
