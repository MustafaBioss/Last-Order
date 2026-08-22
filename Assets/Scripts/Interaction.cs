using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    // LayerMask layerMask;
    [SerializeField] public GameObject holdPoint;
    private GameObject heldObject = null;
    private string hitName;

    [SerializeField] public RawImage crosshair;

    public string[] holdableObjects = { "Knife", "Tomato", "Lettuce", "Cheese", "Bread", "Meat", "BoardMesh" };
    
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
            if (hit.collider.CompareTag("Holdable"))
            {
                crosshair.color = Color.green;
                hitName = hit.collider.name;
                StartCoroutine(Log());
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            }
            else
            {
                crosshair.color = Color.white;
            }
            
            hitName = hit.collider.name;
            StartCoroutine(Log());
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            
            if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
            {
                
                if (hit.collider.CompareTag("Holdable"))
                {
                    CuttingBoard cuttingBoard = hit.transform.GetComponent<CuttingBoard>();

                    if (cuttingBoard != null)
                    {
                        GameObject board = cuttingBoard.transform.parent.gameObject;


                        board.transform.rotation = Quaternion.identity;
                        board.transform.SetParent(holdPoint.transform, false);
                        board.transform.localPosition = Vector3.zero;


                        heldObject = board;
                    }
                    else 
                    {

                        heldObject = hit.transform.gameObject;
                        heldObject.transform.rotation = Quaternion.identity;

                        hit.transform.SetParent(holdPoint.transform, false);
                        hit.transform.localPosition = Vector3.zero;

                        Debug.Log("Picked up: " + hit.collider.name);
                    }
                }
                else
                {
                    Debug.Log("Cannot pick up: " + hit.collider.name);
                    return;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
            {
                if (hit.transform.name == "BoardMesh")
                {
                    CuttingBoard cuttingBoard = hit.transform.GetComponent<CuttingBoard>();

                    GameObject board = cuttingBoard.transform.parent.gameObject;

                    cuttingBoard.OnDropItem(heldObject);

                    board.transform.rotation = Quaternion.identity;
                    heldObject = null;

                    Debug.Log("Dropped object on Cutting Board");
                }
                else
                {
                    heldObject.transform.rotation = Quaternion.identity;
                    heldObject.transform.SetParent(null);
                    heldObject = null;
                    Debug.Log("Dropped object");
                }
            }
        }
        else 
            {
                Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
                crosshair.color = Color.white;
            }
    }

    IEnumerator Log()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Looking at: " + hitName);
    }
}
