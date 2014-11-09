using UnityEngine;
using System.Collections;

public class ShootingLasers : MonoBehaviour {
    LineRenderer line;

    public float LaserDistance = 50f;
    public float LaserGunCoolDown = 1.5f;

    private bool CanFire = true;

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

        if (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1) && CanFire)
        {
            CanFire = false;
            line.enabled = true;
            if (Physics.Raycast(ray, out hit, LaserDistance))
            {
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
                print("There is something in front of the object!");
            }
            else
                line.SetPosition(1, new Vector3(0, 0, 300));

            StartCoroutine("CoolDown");

        }

    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.7f);
        line.enabled = false;

        yield return new WaitForSeconds (LaserGunCoolDown);
        CanFire = true;
        
    }
}