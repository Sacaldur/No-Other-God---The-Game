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
        Idol idol = collider.GetComponent<Idol>();
        if(idol && !idol.isCarried)
        {
            Object.Destroy(idol.gameObject);
            Debug.Log("TODO: implement idol destruction");
        }
        Player player = collider.GetComponent<Player>();
        if(player && player.carriedIdol)
        {
            player.PunishForCarrying();
        }
    }
}
