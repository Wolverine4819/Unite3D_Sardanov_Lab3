﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : LivingCreature
{
   public PlayerInventory PlayerInventory { get; private set; }
    protected override void Start()
    {
        base.Start();
        ActionController = new PlayerActionController(this);
        PlayerInventory = new PlayerInventory(this);
    }
}
