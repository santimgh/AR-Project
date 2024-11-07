using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScanUIManager : MonoBehaviour {
    public GameObject itemBoxPrefab;  // Reference to the prefab
    public Transform contentTransform; // Reference to the Content transform
    public GameObject scanMessage;     // Reference to the ScanMessage text
    public GameObject itemScrollView;  // Reference to the Scroll View

    // Dictionary to hold furniture type and images
    private Dictionary<string, Sprite> furnitureImages;

    // References to furniture images
    public Sprite chairImage;
    public Sprite sofaImage;
    // Add other furniture images as needed

    void Start() {
        furnitureImages = new Dictionary<string, Sprite> {
            { "Chair", chairImage },
            { "Sofa", sofaImage }
            // Add other furniture types as needed
        };
        scanMessage.SetActive(true);
        itemScrollView.SetActive(false);
    }

    public void OnItemScanned(string furnitureType) {
        if (scanMessage.activeSelf) {
            scanMessage.SetActive(false);       // Hide initial message
            itemScrollView.SetActive(true);     // Show the scroll view
        }

        if (furnitureImages.ContainsKey(furnitureType)) {
            AddItemToScroll(furnitureType);
        }
    }

    void AddItemToScroll(string furnitureType) {
    if (itemBoxPrefab == null) {
        Debug.LogError("itemBoxPrefab is not assigned!");
        return;
    }

    if (contentTransform == null) {
        Debug.LogError("contentTransform is not assigned!");
        return;
    }

    GameObject newItemBox = Instantiate(itemBoxPrefab, contentTransform);
    Image itemImage = newItemBox.transform.Find("FurnitureImage")?.GetComponent<Image>();

    if (itemImage == null) {
        Debug.LogError("FurnitureImage not found in itemBoxPrefab!");
        return;
    }

    if (!furnitureImages.ContainsKey(furnitureType)) {
        Debug.LogError($"furnitureImages does not contain an entry for {furnitureType}!");
        return;
    }

    itemImage.sprite = furnitureImages[furnitureType];
}

}
