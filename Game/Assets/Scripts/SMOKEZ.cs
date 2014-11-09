using UnityEngine;
using System.Collections;

public class SMOKEZ : MonoBehaviour {

    private bool timeToDie = false;
    private bool what = true;
    public GameObject smokes;
    public float collapseSpeed = 2f;
    public float umSpeed = 2f;

	// Use this for initialization
	void Start () {
        //ParticleRenderer[] t = GetComponentsInChildren<ParticleRenderer>();
        //for (int i = 0; i < t.Length; i++)
        //{
        //    Debug.Log(t[i].gameObject.name);
        //    if (t[i].gameObject.name.Contains("smoke"))
        //        smokes = t[i].gameObject;
        //}
	}

    // Update is called once per frame
    void Update()
    {

        if (timeToDie)
        {
            transform.Translate(Vector3.down * collapseSpeed * Time.deltaTime);
           // transform.Rotate(Vector3.up, Mathf.Sin(Time.deltaTime) * umSpeed);
            if(what)
                StartCoroutine("SlowDeath");
        }
	
	}

    public void SuchIsLife()
    {
        timeToDie = true;
    }

    IEnumerator SlowDeath()
    {
        gameObject.SetActiveRecursively(true);
        what = false;
        if (smokes)
            smokes.SetActive(true);
        yield return new WaitForSeconds(30f);
        //smokes.SetActive(false);
        gameObject.SetActive(false);
    }
}
