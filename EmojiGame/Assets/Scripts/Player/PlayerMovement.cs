using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    // Components
    public Rigidbody playerRb;

    // Velocity
    private Vector3 constVelocity = new Vector3(0, 3, 0);
    private Vector3 gravity = new Vector3 (400,0,0);
    [HideInInspector] public int gravityDirection;
    private bool screenTouched;

    public Vector3 playerPosition;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        GravitySwitch();
    }

    void LateUpdate()
    {
        //Applies the const forward velocity
        playerRb.velocity = constVelocity;
    }


    private void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x > (Screen.width / 2))
                    {
                        gravityDirection = 1;
                    }
                    else
                    {
                        gravityDirection = -1;
                    }
                    screenTouched = true;
                    break;

            }
        }
    }

    // Flips gravity direction
    private void GravitySwitch()
    {
        if (screenTouched)
        {
            Physics.gravity = gravity * gravityDirection;
            screenTouched = false;
        }
    }
}


