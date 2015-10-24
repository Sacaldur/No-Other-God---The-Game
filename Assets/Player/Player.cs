using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    [SerializeField]
    [Tooltip("The players id, starting at 0.\nIs used to determine the players input axes.")]
    private int playerId = 0;
    [SerializeField]
    private float movementSpeed = 5;


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
}
