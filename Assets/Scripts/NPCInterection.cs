using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInterection : Interectable
{
     [SerializeField] GameObject _messageWindow;
    private Interectable interectable;
   
    protected override void Interect()
    {
            base.Interect();
      
            _messageWindow.SetActive(true);
        
    }
    
}
