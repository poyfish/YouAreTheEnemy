using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public List<InventorySlot> inventorySlots;

    public int currentSlot = 0;

    private void Start()
    {
        OnSlotSelected();
    }

     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inventorySlots[currentSlot].OnDeselected();

            currentSlot++;
            OnSlotSelected();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inventorySlots[currentSlot].OnDeselected();

            currentSlot--;
            OnSlotSelected();
        }
    }

    private void OnSlotSelected()
    {
        if (currentSlot < 0) currentSlot = inventorySlots.Count - 1;

        if (currentSlot > inventorySlots.Count - 1) currentSlot = 0;

        inventorySlots[currentSlot].OnSelcted();
    }
    
}
