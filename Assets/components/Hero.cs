using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public int speed = 1;
    public float viewRadius = 20f;
    public float attackRadius = 2f;
    public bool isHero = true;

    public GameObject attackTarget;
    public Animator heroAnimator;

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
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            heroAnimator.SetInteger("State", 1);
            heroAnimator.SetBool("isSeeEnemy", false);
            
            string enemyTag = "Enemy";
            if (!isHero) {
                enemyTag = "Hero";
            }

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(enemyTag)) {
                float distanceSqr = (transform.position - enemy.transform.position).sqrMagnitude;
                if(distanceSqr < viewRadius) {
                    attackTarget = enemy;
                }
            }
        } else {

            float distanceSqr = (transform.position - attackTarget.transform.position).sqrMagnitude;

            if (distanceSqr < attackRadius) {
                // attack
                heroAnimator.SetInteger("State", 2);
            } else {
                // go to enemy
                Vector3 targetPosition = attackTarget.transform.position;
                targetPosition[1] = transform.position[1];
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                Vector3 targetDirection = attackTarget.transform.position - transform.position;
                float singleStep = speed * Time.deltaTime;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);

                heroAnimator.SetInteger("State", 1);
                heroAnimator.SetBool("isSeeEnemy", true);
            }
            
        }
    }

    public void EndEvent() {
        Debug.Log("End event");
    }
}
