﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : LivingCreatureActionController

{
    private PlayerCreature _playerCreature;
    private Interectable _lastTarget;
   
    public PlayerActionController(PlayerCreature player) : base(player)
    {
        _playerCreature = player;

        _playerCreature.ServiceManager.InputController.LeftPointerClikHandler += OnLeftPonterClicked;
    }

    private void OnLeftPonterClicked(Vector3 destenstion, Collider collider)
    {
        if(_lastTarget != null)
        {
            _lastTarget.OnUnFocus();
           
        }
        if (collider != null)
        {
            _lastTarget = collider.GetComponent<Interectable>();
            if(_lastTarget != null)
            {
                _lastTarget.OnFocus(_playerCreature);
                Vector3 centrePoint = new Vector3(_lastTarget.transform.position.x, _playerCreature.transform.position.y, _lastTarget.transform.position.z);
                Move(centrePoint, _lastTarget.StoppingDistance);
                return;
            }
        }
            

        Move(destenstion);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        _playerCreature.ServiceManager.InputController.LeftPointerClikHandler -= OnLeftPonterClicked;
    }
   
   
}
