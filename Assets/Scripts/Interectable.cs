using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class Interectable : MonoBehaviour
{
    protected PlayerCreature _player;
    private bool _isFocused;
    private bool _hasInterected;
    [SerializeField] private float _interctionDistance;
  
    public virtual float StoppingDistance { get { return _interctionDistance * 0.7f; } }
    public void OnFocus(PlayerCreature player)
    {
        _isFocused = true;
        _player = player;
    }
    public  void OnUnFocus()
    {
        _isFocused = false;
        _hasInterected = false;
    }
  
    void Update()
    {
        if (_isFocused && _player != null)
        {
            Vector3 centrePoint = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
            if (Vector3.Distance(centrePoint, _player.transform.position) < _interctionDistance && !_hasInterected)
            {
                Interect();
            }
           
        }
    }
    protected virtual  void Interect()
    {
        _hasInterected = true;
    
        Debug.Log("Interectation" + gameObject);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interctionDistance);
    }
}
