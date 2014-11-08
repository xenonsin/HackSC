using UnityEngine;
using System.Collections;

public class ShootingLasers : MonoBehaviour {
    LineRenderer line;

    public float LaserDistance = 10;

    void Start() 
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 50, Color.red);

        if (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1))
        {
            line.enabled = true;
            if (Physics.Raycast(ray, out hit, LaserDistance))
            {
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
                print("There is something in front of the object!");
            }
            else
                line.SetPosition(1, new Vector3(0, 0, 300));
        }
        else
            line.enabled = false;
    }
    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1))
        {

            //line.SetPosition(0, ray.origin);


            transform.position += transform.forward * 10 * Time.deltaTime;


            yield return null;
        }

        line.enabled = false;
    }
}