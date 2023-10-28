using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    [SerializeField]
    private GameObject lineGeneratorPrefab;

    [SerializeField]
    private int horizontalCount;

    [SerializeField]
    private int verticalCount;

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLineGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLineGenerator()
    {
        float verticalOffset = this.size[0] / (this.verticalCount);
        float horizontalOffset = this.size[1] / (this.horizontalCount);
        
        for (int i = 0; i < this.verticalCount + 1; i++) {
            GameObject newLineGenVerical = Instantiate(lineGeneratorPrefab);
            LineRenderer lRendVerical = newLineGenVerical.GetComponent<LineRenderer>();
            lRendVerical.SetPosition(0, new Vector3(this.position[0] + i * verticalOffset, this.position[1], this.position[2]));
            lRendVerical.SetPosition(1, new Vector3(this.position[0] + i * verticalOffset, this.position[1], this.position[2] + this.size[1]));
        }

        for (int i = 0; i < this.horizontalCount + 1; i++) {
            GameObject newLineGenHorizontal = Instantiate(lineGeneratorPrefab);
            LineRenderer lRendHorizontal = newLineGenHorizontal.GetComponent<LineRenderer>();
            lRendHorizontal.SetPosition(0, new Vector3(this.position[0], this.position[1], this.position[2] + i * horizontalOffset));
            lRendHorizontal.SetPosition(1, new Vector3(this.position[0] + this.size[0], this.position[1], this.position[2] + i * horizontalOffset));
        }
    }
}
