using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    int itemId;
    [SerializeField]
    string itemName;
    [SerializeField]
    string itemLore;
    [SerializeField]
    Sprite itemIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }
}
