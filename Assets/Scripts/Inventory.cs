using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private HandSlot[] slots = new HandSlot[4];

    public Text text;

    private int eatenLettuce = 0;

	void Start ()
    {
        for(int i = 0; i < slots.Length; i++)
            slots[i] = transform.GetChild(i).gameObject.GetComponent<HandSlot>();
	}
	
	void Update ()
    {
        text.text = eatenLettuce.ToString();
    }

    public void AddItem(ItemType item, int size) {
        int emptyCount = 0;
        for (int i = 0; i < slots.Length; i++)
            if (slots[i].GetItemType().Equals(ItemType.EMPTY))
                emptyCount++;
        if(size > emptyCount)
        {
            print("Inventory is full");
            return;
        }
        if(size == 1)
        {
            for (int i = 0; i < slots.Length; i++)
                if (slots[i].GetItemType().Equals(ItemType.EMPTY))
                {
                    slots[i].SetItem(item, true);
                    return;
                }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
                if (slots[i].GetItemType().Equals(ItemType.EMPTY))
                {
                    slots[i].SetItem(item, true);
                    for (int j = 1; j < size; j++)
                    {
                        slots[i+j].SetItem(item, false);
                    }
                    return;
                }
        }
    }

    public void RemoveItem(ItemType item)
    {
        if (item.Equals(ItemType.LETTUCE))
            eatenLettuce++;

        for (int i = 0; i < slots.Length; i++)
            if (slots[i].GetItemType().Equals(item))
            {
                slots[i].SetItem(ItemType.EMPTY, true);
                if (i + 1 == slots.Length)
                    return;
                while (slots[i + 1].IsItemReal() == false)
                {
                    slots[i + 1].SetItem(ItemType.EMPTY, true);
                    i += 1;
                    if (i + 1 == slots.Length)
                        return;
                }
                return;
            }
    }
}
