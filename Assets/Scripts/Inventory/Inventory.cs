using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> itemList;
    [SerializeField]
    GameObject slotGrid;
    Slot[] slotList;

    // Start is called before the first frame update
    void Start()
    {
        slotList = slotGrid.transform.GetComponentsInChildren<Slot>();
        reloadSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void reloadSlot()
    {
        for(int i=0;i<slotList.Length && i<itemList.Count; i++)
        {
            slotList[i].InsertItem(itemList[i]);
        }
    }

    public void AddItem(Item _item)
    {
        if (itemList.Count < slotList.Length)
        {
            itemList.Add(_item);
            reloadSlot();
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }
}
