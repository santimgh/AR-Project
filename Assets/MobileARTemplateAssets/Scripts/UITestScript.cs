using UnityEngine;

public class UITestScript : MonoBehaviour
{
    public ScanUIManager scanUIManager;  // Reference to the ScanUIManager

    void Update()
    {
        // Test scanning a chair when the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            scanUIManager.OnItemScanned("Chair");
        }

        // Test scanning a sofa when the "S" key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            scanUIManager.OnItemScanned("Sofa");
        }
    }
}
