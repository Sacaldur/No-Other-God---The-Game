using UnityEngine;
using System.Collections;

public class MosesTrigger : MonoBehaviour
{
    [SerializeField]
    private Moses moses;


    void OnTriggerEnter2D(Collider2D collider)
    {
        this.moses.EnteredVision(collider);
    }
}
