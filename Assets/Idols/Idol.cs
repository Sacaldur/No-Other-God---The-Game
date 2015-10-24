using UnityEngine;
using System.Collections;

public class Idol : MonoBehaviour
{
    public bool isCarried = false;

    
    void Start()
    {

    }
    
    void Update()
    {

    }


    public void TriggerEntered(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player)
        {
            player.IdolTouched(this);
        }
    }
}
