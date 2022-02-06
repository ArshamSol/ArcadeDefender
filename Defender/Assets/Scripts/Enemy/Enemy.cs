using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private Rigidbody2D rbEnemy;
    private Transform shipTransform;
    private Vector3 directionToship;
    private float moveSpeed;
    private int points;
    [SerializeField] private Sprite enemySprite;
    [SerializeField] private Sprite enemyFireSprite;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy=GetComponent<Rigidbody2D>();
        moveSpeed = 10f;
        shipTransform = GameObject.FindWithTag("Ship").transform;
    }

    public virtual void enemyBehavior()
    {
        
    }

    public virtual void instantiateEnemy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        directionToship = (shipTransform.position - transform.position).normalized;//https://www.youtube.com/watch?v=jdAoLlCn2e8&ab_channel=AlexanderZotov
        rbEnemy.velocity = new Vector2(directionToship.x, directionToship.y) * moveSpeed;
    }
}
