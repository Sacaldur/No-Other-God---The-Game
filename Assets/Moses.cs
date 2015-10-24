using UnityEngine;
using System.Collections;

public class Moses : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }


    public void EnteredVision(Collider2D collider)
    {
        Debug.Log("Entered moses vision: " + collider.gameObject + " (type: " + collider.GetType().Name + ")");
    }
}
