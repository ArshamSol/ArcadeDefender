using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBaiter : MonoBehaviour
{
    public ShipMove _ShipObj;
    private Rigidbody2D BaiterRigidBd;

    public void Start()
    {
        BaiterRigidBd = GetComponent<Rigidbody2D>();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _ShipObj.ShipAttacked();
        }
    }

    // Update is called once per frame
    public void Update()
    {
            var followingDirection = (_ShipObj.transform.position - transform.position).normalized;
            BaiterRigidBd.velocity = new Vector2(followingDirection.x, followingDirection.y) * 0.23f;   
    }
}
