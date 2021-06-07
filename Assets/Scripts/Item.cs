using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    [SerializeField] private MeshRenderer _itemMeshRenderer;
    [SerializeField] private MeshFilter _itemMeshFilter;
    [SerializeField] private Collider _itemCollider;

    [SerializeField] private ItemParams _itemParams;
    public void Init(Mesh itemMesh, Material itemMaterial, ItemParams itemParams)
    {
        _itemMeshRenderer.material = itemMaterial;
        _itemMeshFilter.mesh = itemMesh;
        _itemParams = itemParams;

    }
    public void Destroy(PlayerCreature player)
    {
        if (player.PlayerInventory.AddItemToInvenory(_itemParams))
        {
            Destroy(gameObject);
        }
        Debug.Log(player);
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
