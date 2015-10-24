using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Storage : MonoBehaviour
{
    [SerializeField]
    private int _team = 0;
    public int team
    {
        get
        {
            return this._team;
        }
    }

    private List<Idol> storedIdols = new List<Idol>();


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
            player.StorageEntered(this);
        }
    }

    public void StoreIdol(Idol idol)
    {
        this.storedIdols.Add(idol);
        idol.isStored = true;
        idol.transform.position = this.transform.position + new Vector3(0,0,-2);
    }
}
