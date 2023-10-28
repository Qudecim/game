using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    // 1 - Fight
    public static int stage = 0;

    public static GameObject[] heroes;
    public static GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Game.enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(Game.enemies.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Game.stage == 1) {
                Game.stage = 0;
            } else {
                Game.stage = 1;
            }
        }
    }
}
