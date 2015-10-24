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
    private bool _isStored = false;
    public bool isStored
    {
        get
        {
            return this._isStored;
        }
        set
        {
            this._isStored = value;
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
        if (!this.isCarried && !this.isStored)
        {
            Player player = collider.GetComponent<Player>();
            if (player)
            {
                player.IdolTouched(this);
            }
        }
    }
}
