using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    public float armour = 0;

    public int speed = 1;
    public float viewRadius = 20f;
    public float attackRadius = 2f;

    public bool isHero = true;

    public Animator heroAnimator;
    

    private GameObject attackTarget;
    private Hero script_enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        // set animation speed attack
        // but it doesn't work with variable idk why
        heroAnimator.SetFloat("AttackSpeed", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Game.stage != 1) {
            return;
        }
        if (attackTarget == null) {
            //  Go to door
            // TODO: rotate to door
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            heroAnimator.SetInteger("State", 1);
            
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
            }
            
        }
    }

    public void damage(float hp) {
        currentHealth = currentHealth - hp;
        if (currentHealth < 0) {
            this.die();
        }
    }

    public void heal(float hp) {
        currentHealth = Mathf.Min(currentHealth + hp, maxHealth);
    }

    private void die() {
        Destroy(gameObject);
    }

    public void EventAttack() {
        script_enemy = attackTarget.GetComponent<Hero>();
        script_enemy.damage(75);
    }

    public void EventAttackFinish() {

    }

    public void EndEvent() {
        Debug.Log("End event");
    }
}
