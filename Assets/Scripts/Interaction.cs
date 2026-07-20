using UnityEngine;

public class Interaction : MonoBehaviour
{

    // LayerMask layerMask;
    [SerializeField] public GameObject holdPoint;
    private GameObject heldObject = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 

        Debug.Log("Held Object: " + heldObject);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
            {
                hit.transform.SetParent(holdPoint.transform, false);
                hit.transform.localPosition = Vector3.zero;
                heldObject = hit.transform.gameObject;
                Debug.Log("Picked up: " + hit.collider.name);
            }
            if ( Input.GetKeyDown(KeyCode.Q) && heldObject != null)
            {
                heldObject.transform.SetParent(null);
                heldObject = null;
                Debug.Log("Dropped object");
            }
        }
        else 
            {
                Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
            }
    }
}
