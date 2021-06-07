using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInterectable : Interectable
{
   [SerializeField] private Item _thisItem;
    protected override void Interect()
    {
        base.Interect();
        _thisItem.Destroy(_player);
    }
}
