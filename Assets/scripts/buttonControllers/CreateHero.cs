using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHero : MonoBehaviour
{

    public Camera camera;
    public GameObject myPrefab;
    public GameObject createdPrefab;

    public void create() {
        createdPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        createdPrefab.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
    }

    void Update()
    {

        if (createdPrefab != null) {
            RaycastHit hit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayCast, out hit, 100))
            {
                if (hit.transform.tag == "HeroZone") {
                    Vector3 position = hit.transform.position;
                    position[1] = 0f;
                    createdPrefab.transform.position = position;
                }
            }

            if (Input.GetMouseButtonDown(0)) {
                if (Physics.Raycast(rayCast, out hit, 100))
                {
                    if (hit.transform.tag == "HeroZone") {
                        // need make global variable for check that i placed character
                        createdPrefab = null;
                    }
                }
                
            }
        }
    }
}
