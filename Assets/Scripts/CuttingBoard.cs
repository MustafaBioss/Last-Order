using UnityEngine;

public class CuttingBoard : MonoBehaviour
{

    [SerializeField] public GameObject[] holdPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDropItem(GameObject item)
    {
        foreach (GameObject holdPoint in holdPoints)
        {
            if (holdPoint.transform.childCount == 0)
            {
                item.transform.SetParent(holdPoint.transform, false);
                item.transform.localPosition = Vector3.zero;
                Debug.Log("Dropped item on cutting board: " + item.name);
                return;
            }
        }
        Debug.Log("No available hold points on cutting board for item: " + item.name);
    }
}
