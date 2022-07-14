using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public int currentJumpCount;
    private bool grounded;
    public float playerSpeed;
    public float jumpSpeed;
    public int maxJumpCount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis ("Vertical"));
        rb.MovePosition(transform.position + input * Time.deltaTime *playerSpeed);
        
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            Debug.Log("pressed");
            if (currentJumpCount > 0) {
                Debug.Log("Enough Jumps");
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                currentJumpCount--; 
            }
           
        }
    }
    

    void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.tag =="Floor") {
            grounded = true;
            currentJumpCount = maxJumpCount;
        }
        
    }

    void OnCollisionExit(Collision collision) {
        
        if (collision.gameObject.tag =="Floor") {
            
        }
     }

}
