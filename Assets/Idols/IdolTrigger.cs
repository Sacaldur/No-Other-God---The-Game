using UnityEngine;
using System.Collections;

public class IdolTrigger : MonoBehaviour
{
    [SerializeField]
    private Idol idol;
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        this.idol.TriggerEntered(collider);
    }
}
