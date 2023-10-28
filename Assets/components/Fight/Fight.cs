using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public int speed = 1;
    public float viewRadius = 20f;
    public float attackRadius = 2f;

    public GameObject attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.stage != 1) {
            return;
        }
        if (attackTarget == null) {
            //  Go to door
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            
            foreach (GameObject enemy in Game.enemies) {
                float distanceSqr = (transform.position - enemy.transform.position).sqrMagnitude;
                if(distanceSqr < viewRadius) {
                    attackTarget = enemy;
                }
            }
        } else {

            float distanceSqr = (transform.position - attackTarget.transform.position).sqrMagnitude;

            if (distanceSqr < attackRadius) {
                // attack
            } else {
                // go to enemy
                transform.position = Vector3.MoveTowards(transform.position, attackTarget.transform.position, speed * Time.deltaTime);
            }
            
        }
    }
}
