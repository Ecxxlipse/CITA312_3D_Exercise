using UnityEngine;
using UnityEngine.UIElements;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] float pushforce = 5f;
    [SerializeField] float bouncefource = 5f;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = 2f;
        rb.AddForce(Vector3.forward * pushforce, ForceMode.Impulse); 
        Debug.Log("Player Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("The player collided with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Obj"))
        {
            Debug.Log("Obstacle detected");
            Debug.Log(collision.gameObject.name);
            Debug.Log("Collision time" + Time.time);
            rb.AddForce(Vector3.left * pushforce, ForceMode.Impulse); 
        }
    }
}
