using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{

    // LayerMask layerMask;
    [SerializeField] public GameObject holdPoint;
    private GameObject heldObject = null;
    private string hitName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 

        // Debug.Log("Held Object: " + heldObject);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            hitName = hit.collider.name;
            StartCoroutine(Log());
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            
            if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
            {

                CuttingBoard cuttingBoard = hit.transform.GetComponent<CuttingBoard>();

                if (cuttingBoard != null)
                {
                    GameObject board = cuttingBoard.transform.parent.gameObject;

                    board.transform.SetParent(holdPoint.transform, false);
                    board.transform.localPosition = Vector3.zero;


                    heldObject = board;
                }
                else 
                {
                    hit.transform.SetParent(holdPoint.transform, false);
                    hit.transform.localPosition = Vector3.zero;

                    heldObject = hit.transform.gameObject;
                    Debug.Log("Picked up: " + hit.collider.name);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
            {
                if (hit.transform.name == "BoardMesh")
                {
                    CuttingBoard cuttingBoard = hit.transform.GetComponent<CuttingBoard>();
                    cuttingBoard.OnDropItem(heldObject);

                    heldObject = null;

                    Debug.Log("Dropped object on Cutting Board");
                }
                else
                {
                    heldObject.transform.SetParent(null);
                    heldObject = null;
                    Debug.Log("Dropped object");
                }
            }
        }
        else 
            {
                Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
            }
    }

    IEnumerator Log()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Looking at: " + hitName);
    }
}
