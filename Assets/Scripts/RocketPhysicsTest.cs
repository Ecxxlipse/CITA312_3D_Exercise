using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketPhysicsTest : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float Thrust = 50f;
    [SerializeField] float strongThrust = 100f;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Press space for a normal thurst
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyThrust();
        }
        //Press shift for a stronger thrust
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ApplyStrongThrust();
        }
    }

    //Q1: Which Combination feels easiest to control?
    
    //Ans: A lower mass with moderate linear damping felt easiest to control 
    //because the rocket responded more quickly to thrust while the damping 
    //helped reduce excessive movement.


    //Q2: why physics tuning is an important part of game design

    //Ans: Physics tuning is important because it controls how objects feel 
    //when the player interacts with them. Adjusting mass, damping, and force 
    //can make movement feel responsive and easier to control.


    void ApplyThrust()
    {
        rb.AddRelativeForce(Vector3.up * Thrust);
    }
    void ApplyStrongThrust()
    {
        rb.AddRelativeForce(Vector3.up * strongThrust);
    }
}
