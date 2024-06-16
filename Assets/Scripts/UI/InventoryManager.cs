
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();

    public GameObject InventoryMenu;
    public GameObject Moneycanvas;
    private bool menuActivated;

    public GameObject inventoryGrid; // Reference to the InventoryGrid GameObject
    public GameObject inventorySlotPrefab; // Reference to the InventorySlot prefab

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InventoryMenu.SetActive(false);
        menuActivated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Time.timeScale = 1f;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            Time.timeScale = 0f;
            InventoryMenu.SetActive(true);
            menuActivated = true;
            DisplayInventory(); // Call the method to display inventory when menu is activated
        }
    }

    public void Add(Item item)
    {
        items.Add(item);
        if (menuActivated)
        {
            DisplayInventory(); // Update display if inventory menu is already open
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (menuActivated)
        {
            DisplayInventory(); // Update display if inventory menu is already open
        }
    }

    public void DisplayInventory()
    {
        // Clear existing inventory slots
        foreach (Transform child in inventoryGrid.transform)
        {
            Destroy(child.gameObject);
        }

        // Populate inventory slots
        foreach (Item item in items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryGrid.transform);
            Image icon = slot.GetComponent<Image>();
            icon.sprite = item.icon; // Set the icon for each slot
        }
    }
}