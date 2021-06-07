using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInterectable :Interectable
{
    [SerializeField] GameObject _messageWindow;
    private Interectable interectable;
    protected override void Interect()
    {
        base.Interect();
        _messageWindow.SetActive(true);

    }
}
