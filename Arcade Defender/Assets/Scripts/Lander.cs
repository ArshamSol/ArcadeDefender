using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    public Sprite _mutantSprite;
    public GameObject _firePrefab;
    public Transform _playerShipTransform;
    public float _duration = 0.1f;
    private ShipMove _shipObject;
    private Rigidbody2D _landerRB;
    private bool _followShip=false;

    public virtual void Start()
    {
        _shipObject = _playerShipTransform.gameObject.GetComponent<ShipMove>();
        _landerRB = GetComponent<Rigidbody2D>();
        InvokeRepeating("instantiateFire", 1f, 3f);
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    private void instantiateFire()
    {
        var fireCopy = Instantiate(_firePrefab, transform.position, Quaternion.identity);
        var landerFireControl=fireCopy.GetComponent<LanderFireControl>();
        var fireDirection = (_playerShipTransform.position-transform.position ).normalized;
        var fireRigidBody = fireCopy.GetComponent<Rigidbody2D>();
        fireRigidBody.velocity = new Vector2(fireDirection.x, fireDirection.y) * 0.25f;
        
        landerFireControl._onShipFired = () => _shipObject.ShipAttacked();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Scientist")
        {
            ScientistCollisionControl(collision);
        }

        if (collision.tag == "Player")
        {
            _shipObject.ShipAttacked();
        }

        if (collision.tag == "TopBorder")
        {
            TopBorderCollisionControl();
        }
    }

    private void ScientistCollisionControl(Collider2D collision)
    {
        var scientist = collision.GetComponent<Scientist>();

        _landerRB.velocity = Vector2.zero;

        scientist.transform.parent = _landerRB.transform;
        scientist.transform.position = new Vector3(_landerRB.transform.position.x,
                                                    _landerRB.transform.position.y - 0.02f,
                                                    _landerRB.transform.position.z);
        var moveToTop = Vector3.up;

        _landerRB.velocity = new Vector2(moveToTop.x, moveToTop.y) * 0.12f;
    }

    private void TopBorderCollisionControl()
    {
        _landerRB.velocity = Vector3.zero;
        var landerAnim = GetComponent<Animator>();
        landerAnim.enabled = false;
        var landerSP = GetComponent<SpriteRenderer>();
        landerSP.sprite = _mutantSprite;//changing to mutant enemy type
        _followShip = true;
        
    }

    public void Update()
    {
        if (_followShip)
        {
            followShip();
        }
    }

    public void followShip()
    {
        var followingDirection = (_playerShipTransform.position - transform.position).normalized;
        _landerRB.velocity = new Vector2(followingDirection.x, followingDirection.y) * 0.2f;
    }
}

