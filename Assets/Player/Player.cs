using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    private AudioSource audioSource;
    [SerializeField]
    private Transform idolParent;

    [SerializeField]
    [Tooltip("The players id, starting at 0.\nIs used to determine the players input axes.")]
    private int playerId = 0;
    [SerializeField]
    private int _team = 0;
    public int team
    {
        get
        {
            return this._team;
        }
    }

    [SerializeField]
    private float movementSpeed = 5;

    public Idol carriedIdol
    {
        get
        {
            return this._carriedIdol;
        }
        private set
        {
            if(this._carriedIdol)
            {
                this._carriedIdol.transform.parent = null;
                this._carriedIdol.transform.position = this.transform.position;
                this._carriedIdol.isCarried = false;
            }

            this._carriedIdol = value;
            if (this._carriedIdol)
            {
                this._carriedIdol.isCarried = true;
                this._carriedIdol.transform.parent = this.idolParent;
                this._carriedIdol.transform.localPosition = Vector3.zero;
            }
        }
    }
    private Idol _carriedIdol;


    [SerializeField]
    private AudioClip idolGrabSound;
    [SerializeField]
    private AudioClip idolDropSound;
    [SerializeField]
    private AudioClip idolStoreSound;
    [SerializeField]
    private AudioClip gotPunishedSound;



    void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
        this.audioSource = this.GetComponent<AudioSource>();
    }

    void Start()
    {

    }
    
    void Update()
    {
        Vector2 movementInput = this.GetMovementInput();

        this.rigidbody.velocity = movementInput * this.movementSpeed;

        if(movementInput.sqrMagnitude >= 0.0625 * 0.0625)
        {
            Vector3 rotation = this.transform.eulerAngles;
            float angle = Vector2.Angle(Vector2.up, movementInput);
            if(Vector2.Dot(Vector2.right, movementInput) > 0)
            {
                angle = -angle;
            }
            rotation.z = angle;
            this.transform.eulerAngles = rotation;
            this.idolParent.localEulerAngles = new Vector3(0, 0, -angle);
        }
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
            this.PlaySound(this.idolGrabSound);
        }
    }

    public void StorageEntered(Storage storage)
    {
        if(storage.team == this.team && this.carriedIdol)
        {
            Idol idol = this.carriedIdol;
            this.carriedIdol = null;
            storage.StoreIdol(idol);
        }
    }

    private void PlaySound(AudioClip sound)
    {
        if (sound)
        {
            if (this.audioSource)
            {
                this.audioSource.PlayOneShot(sound);
            }
        }
    }


    public void PunishForCarrying()
    {
        Idol idol = this.carriedIdol;
        this.carriedIdol = null;
        Object.Destroy(idol.gameObject);

        Debug.Log("TODO: implement player punishment");
    }
}
