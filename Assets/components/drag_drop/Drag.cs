using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public Camera camera;

    private GameObject selectedObject;

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
                if (hitInfo.transform.tag == "test") {
                    selectedObject = hitInfo.transform.gameObject;
                }
            }
        }

        if (Input.GetMouseButton(0)) {
            if (selectedObject != null) {
                RaycastHit hit;
                Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayCast, out hit, 100))
                {
                    if (hit.transform.tag == "bridge") {
                        float offset = 1f;
                        float x = hit.point[0] - (hit.point[0] % 2) + offset;
                        float z = hit.point[2] - (hit.point[2] % 2) + offset;
                        selectedObject.transform.position = new Vector3(x, 0, z);
                    }
                }
            }
        }
    }
}
