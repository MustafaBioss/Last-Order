using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") + 
            transform.right * Input.GetAxis("Horizontal");

        move.Normalize();

        transform.position += move * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }
}
