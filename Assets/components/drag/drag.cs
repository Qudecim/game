using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{

    public Camera camera;
    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
		    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                if (hitInfo.transform.tag == "Hero") {
                    selectedObject = hitInfo.transform.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            selectedObject = null;
        }

        if (Input.GetMouseButton(0)) {
            if (selectedObject != null) {
                RaycastHit hit;
                Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayCast, out hit, 100))
                {
                    if (hit.transform.tag == "HeroZone") {
                        Vector3 position = hit.transform.position;
                        position[1] = 0f;
                        selectedObject.transform.position = position;
                    }
                }
            }
        }
    }
}
