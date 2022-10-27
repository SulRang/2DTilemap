using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item;
    [SerializeField]
    Image itemicon;
    // Start is called before the first frame update
    void Start()
    {
        itemicon = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertItem(Item _item)
    {
        item = _item;
        itemicon.sprite = _item.GetItemIcon();
        itemicon.enabled = true;
    }
}
