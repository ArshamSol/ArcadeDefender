using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Transform shipFront;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite towardLeftSprite;
    [SerializeField] private Sprite towardRightSprite;
    [SerializeField] private Camera mainCamera;

    private float bulletSpeed = 10f;
    private float shipSpeedAmount = 2f;
    //private Rigidbody2D shipRigidbd;
    private Rigidbody shipRigidbd;
    private SpriteRenderer shipSprite;
    Vector2 horizontalMovement;
    Vector2 verticalMovement;
    Vector2 initialPosition;
    float cameraInitialXPosition;
    public enum shipSpeedStates { stop, normal, fast };
    shipSpeedStates relativeScrollingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        shipRigidbd = GetComponent<Rigidbody>();
        shipSprite= GetComponent<SpriteRenderer>();
        initialPosition = shipRigidbd.position;
        cameraInitialXPosition = mainCamera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, shipFront.position, transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        }
        horizontalMovement = new Vector2(Input.GetAxis("Horizontal"),0);
        verticalMovement = new Vector2(0, Input.GetAxis("Vertical"));

    }

    public shipSpeedStates getRelativeScrollingSpeed()
    {
        return relativeScrollingSpeed;
    }

    void FixedUpdate()
    {
        Vector3 currentCamPosition = mainCamera.transform.position;
        //shipRigidbd.MovePosition(shipRigidbd.position + movement * shipSpeed * Time.fixedDeltaTime);
        if (horizontalMovement.x != 0)
        {
            if(horizontalMovement.x<0)
            {
                if (shipSprite.sprite != towardLeftSprite)
                {
                    shipSprite.sprite = towardLeftSprite;
                    mainCamera.transform.position = Vector3.Lerp(currentCamPosition, new Vector3(currentCamPosition.x - 8f, currentCamPosition.y, currentCamPosition.z), 1);
                }
                
            }
            if (horizontalMovement.x > 0)
            {
                shipSprite.sprite = towardRightSprite;
                
            }


            shipRigidbd.AddForce(horizontalMovement * shipSpeedAmount);

            if (shipRigidbd.position.x - initialPosition.x > 1)
            {
                shipRigidbd.drag = 200;
                relativeScrollingSpeed = shipSpeedStates.fast;             
            }
            else
            {
                relativeScrollingSpeed = shipSpeedStates.normal;
            }
        }
        else
        {
            shipRigidbd.drag = 0.3f;
            if (relativeScrollingSpeed == shipSpeedStates.fast)
            {
                mainCamera.transform.position = Vector3.Lerp(currentCamPosition, new Vector3(currentCamPosition.x + 1f, currentCamPosition.y, currentCamPosition.z), 1);
            }
            relativeScrollingSpeed = shipSpeedStates.stop;
            initialPosition = shipRigidbd.position;


        }

        if (verticalMovement.y != 0)
        {
            shipRigidbd.AddForce(verticalMovement * shipSpeedAmount);
        }
    }
}
