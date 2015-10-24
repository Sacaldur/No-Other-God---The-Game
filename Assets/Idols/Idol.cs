using UnityEngine;
using System.Collections;

public class Idol : MonoBehaviour
{
    private bool _isCarried = false;
    public bool isCarried
    {
        get
        {
            return this._isCarried;
        }
        set
        {
            this._isCarried = value;
        }
    }


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
