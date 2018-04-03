using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour {
    [SerializeField] private string itemName;

    private void OnTriggerEnter(Collider other)
    {
        Managers.Inventory.AddItem(itemName);
        Destroy(this.gameObject);
    }

}
