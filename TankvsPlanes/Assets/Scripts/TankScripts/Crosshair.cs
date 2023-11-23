using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshairPrefab;


    private GameObject crosshairInstance;

    private void Start()
    {
        if (crosshairPrefab == null)
        {
            Debug.LogError("Crosshair prefab not assigned!");
            return;
        }

      
        crosshairInstance = Instantiate(crosshairPrefab);
    }

    private void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        crosshairInstance.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
