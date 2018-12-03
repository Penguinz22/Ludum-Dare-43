using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandSlot : MonoBehaviour, IPointerClickHandler {

    public Inventory inv;

    private ItemType item;
    private bool real;

	void Start ()
    {
        item = ItemType.EMPTY;
        real = false;
	}
	
	public void SetItem(ItemType item, bool real)
    {
        this.item = item;
        this.real = real;

        string name = item.ToString().ToLower();

        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + name);

        if (real)
            gameObject.GetComponent<Image>().color = Color.white;
        else
            gameObject.GetComponent<Image>().color = Color.gray;
    }

    public void OnPointerClick(PointerEventData data)
    {
        inv.RemoveItem(item);
    }

    public ItemType GetItemType()
    {
        return item;
    }

    public bool IsItemReal()
    {
        return real;
    }
}
