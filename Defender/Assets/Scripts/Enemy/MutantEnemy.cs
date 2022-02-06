using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void enemyBehavior()
    {
        InvokeRepeating("instantiateEnemy", 0f, 2f);
    }

    public override void instantiateEnemy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
