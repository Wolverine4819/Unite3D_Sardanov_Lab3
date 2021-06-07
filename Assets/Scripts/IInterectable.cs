using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterectable
{
    IntetectionController IntetectionController { get; }

    float IntercionDistance { get; }

    float StoppingDistance { get; }

    Transform Body { get; }

}
public abstract class IntetectionController
{
    private PlayerCreature _player;
    private bool _isFocused;
    private bool _hasInterected;
    private IInterectable _thisInterctable;

    public IntetectionController(IInterectable interectable)
    {
        _thisInterctable = interectable;
        ServiceManager.Instance.UpdateHandler += OnUpdate;
    }
    public void OnFocus(PlayerCreature player)
    {
        _isFocused = true;
        _player = player;
    }
    public void OnUnFocus()
    {
        _isFocused = false;
        _hasInterected = false;
    }

  private  void OnUpdate()
    {
        if (_isFocused && _player != null)
        {
            if (Vector3.Distance(_thisInterctable.Body.position, _player.transform.position) < _thisInterctable.IntercionDistance && !_hasInterected)
            {
                Interect();
            }
        }
    }
    private void Interect()
    {
        _hasInterected = true;
        Debug.Log("Interectation" + _thisInterctable.Body);
    }
    public  void Destroy()
    {
        ServiceManager.Instance.UpdateHandler -= OnUpdate;
    }
   
}
public class NPCIntetectionController : IntetectionController 
{ 
    public NPCIntetectionController(IInterectable interectable):base(interectable)
    {

    }
}
