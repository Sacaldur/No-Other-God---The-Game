using UnityEngine;
using System.Collections;

public class StorageTrigger : MonoBehaviour
{
    [SerializeField]
    private Storage storage;
    
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        this.storage.TriggerEntered(collider);
    }
}
