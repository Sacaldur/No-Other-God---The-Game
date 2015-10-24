using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    [SerializeField]
    private Transform idolParent;

    [SerializeField]
    [Tooltip("The players id, starting at 0.\nIs used to determine the players input axes.")]
    private int playerId = 0;
    [SerializeField]
    private float movementSpeed = 5;

    private Idol carriedIdol
    {
        get
        {
            return this._carriedIdol;
        }
        set
        {
            if(this._carriedIdol)
            {
                this._carriedIdol.transform.parent = null;
                this._carriedIdol.transform.position = this.transform.position;
                this._carriedIdol.isCarried = false;
            }

            this._carriedIdol = value;
            this._carriedIdol.isCarried = true;
            this._carriedIdol.transform.parent = this.idolParent;
            this._carriedIdol.transform.localPosition = Vector3.zero;
        }
    }
    private Idol _carriedIdol;


    void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }
    
    void Update()
    {
        Vector2 movementInput = this.GetMovementInput();

        this.rigidbody.velocity = movementInput * this.movementSpeed;
    }

    private Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal" + this.playerId), Input.GetAxis("Vertical" + this.playerId));
    }


    public void IdolTouched(Idol idol)
    {
        if(!this.carriedIdol)
        {
            this.carriedIdol = idol;
        }
    }
}
