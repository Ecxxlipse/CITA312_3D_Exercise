using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarTester : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 10f;

    public InputAction moveforward;
    public InputAction turn;
    void Start()
    {
        Debug.Log("My awesome car is ready! Hello from " + gameObject.name);
    }

    void OnEnable()
    {
        moveforward.Enable();
        turn.Enable();

    }
        void OnDisable()
    {
        moveforward.Disable();
        turn.Disable();

    }
    void Update()
    {
        MoveVehicle();
        TurnVehicle();

    }
    
    void MoveVehicle()
    {
        float movement = moveforward.ReadValue<float>();

        //If vehicle is moving Forward, it will display a message
        if (movement != 0)
        {
            Debug.Log("Vehicle is Accelerating.");
        }

        //If vehicle is moving Backwards, it will display a message
        if (movement < 0)
        {
        Debug.Log("Vehicle is reversing.");
        }
        
        transform.Translate(Vector3.forward * movement * moveSpeed * Time.deltaTime);
    }

    void TurnVehicle()
    {
        float turning = turn.ReadValue<float>();
        transform.Rotate(Vector3.up * turning * turnSpeed * Time.deltaTime);
    }
}
