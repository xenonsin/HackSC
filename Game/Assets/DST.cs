using UnityEngine;
using System.Collections;

[System.Serializable]
public class DST : MonoBehaviour {

    public int cubeSize = 100;
    public GameObject[] allocatedCubes;
    public GameObject cubePrefab;

    private float cubeDims;
	void Start () {
        if (cubePrefab == null)
            Debug.LogError("You did not set the prefab up!");
        else
        {

            allocatedCubes = new GameObject[cubeSize];
            for (int i = 0; i < cubeSize; i++)
            {
                if (allocatedCubes[i] == null)
                {
                    allocatedCubes[i] = (GameObject)Instantiate(cubePrefab);
                    allocatedCubes[i].SetActive(false);
                    allocatedCubes[i].transform.position = new Vector3(0, -100.0f, 0);
                    allocatedCubes[i].transform.parent = gameObject.transform;
                }
            }
        }
	}

    public void MoveTo(Vector3 newPosition, float width, float length, float height, Transform newParent)
    {
        cubeDims = (float) (width * length * height) / (cubeSize * 1.0f);
        cubeDims = Mathf.Pow(cubeDims, 1f / 3f);
        float startingX = newParent.position.x - width / 2.0f;
        float startingY = newParent.position.y - height / 2.0f;
        float startingZ = newParent.position.z - length / 2.0f;
        //Debug.Log("newParent.position.x = " + newParent.position.x + "        width = " + width + "      startingX: " + startingX);
        int index = 0;
        Debug.Log("Cube Dimensions: " + cubeDims);
        for (float f1 = startingX; f1 < (startingX + width); f1 += cubeDims)
        {
            for (float f2 = startingZ; f2 < (startingZ + length); f2 += cubeDims)
            {
                for (float f3 = startingY; f3 < (startingY + height); f3 += cubeDims)
                {
                    //Debug.Log("StartingX: " + startingX + "     and f1: " + f1 + "       and bound: " + (startingX + width));
                    //Debug.Log("StartingZ: " + startingZ + "     and f2: " + f2 + "       and bound: " + (startingZ + length));
                    //Debug.Log("StartingY: " + startingY + "     and f3: " + f3 + "       and bound: " + (startingY + height));
                    if (index < allocatedCubes.Length)
                    {
                        allocatedCubes[index].transform.parent = newParent;
                        allocatedCubes[index].transform.position = new Vector3(f1, f3, f2);
                        allocatedCubes[index].transform.localScale = new Vector3(cubeDims, cubeDims, cubeDims);
                        allocatedCubes[index].SetActive(true);
                        index++;
                        Debug.Log("Index: " + index);
                    }
                }
            }
        }
        ApplyPhysics();
    }

    private void ApplyPhysics()
    {
        for(int i = 0; i < allocatedCubes.Length; i++)
        {
            if (allocatedCubes[i] != null)
            {
                if (allocatedCubes[i].rigidbody != null)
                {
                    allocatedCubes[i].rigidbody.AddForce(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
                    Debug.Log("Random Physics Applied To Cube " + i);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
	
	}
}
