using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public ItemType type;
    public Inventory inv;

    private bool inTrigger = false;

	void Start () {}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
            inv.AddItem(type, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
