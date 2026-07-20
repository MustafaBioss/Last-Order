using UnityEngine;

public class Interaction : MonoBehaviour
{

    // LayerMask layerMask;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            Debug.Log("Hit an interactable object: " + hit.collider.name);
        }
        else 
            {
                Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
                Debug.Log("No Hits");
            }
    }
}
