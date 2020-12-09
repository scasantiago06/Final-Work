using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Transform spawn;
    static Transform playerTransform;

    private Rigidbody rb;

    public float speed;

    static PlayerStates playerState;

    IReactableObject reactObj;

    /// <summary>
    /// This property return a variable responsible for save the player position
    /// </summary>
    public static Vector3 Pos
    {
        get
        {
            return playerTransform.position;
        }
        set
        {
            playerTransform.position = value;
        }
    }

    /// <summary>
    /// This property return a variable responsible for save the player states
    /// </summary>
    public static PlayerStates States
    {
        get
        {
            return playerState;
        }
        set
        {
            playerState = value;
        }
    }

    /// <summary>
    /// Some variables are initialized in the function
    /// </summary>
    void Awake()
    {
        spawn = GameObject.Find("Spawn").transform;

        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Is assigned the initial State and the transform variable, and is called a corountine
    /// </summary>
    private void Start()
    {
        playerState = PlayerStates.Die;

        playerTransform = transform;

        StartCoroutine(Move());
    }

    /// <summary>
    /// The rigidbody is wake up constantly
    /// </summary>
    private void Update()
    {
        if(rb.IsSleeping())
            rb.WakeUp();
    }

    /// <summary>
    /// The FixedUpdate controls the movement whit the rigidbody, adding force to the player at the
    /// corresponding addres
    /// </summary>     
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (playerState == PlayerStates.Die)
            rb.MovePosition(spawn.position);

        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// In this function is verified the player collision with an obstacle
    /// </summary>   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<IReactableObject>() != null)
        {
            reactObj = collision.collider.GetComponent<IReactableObject>();
            reactObj.React();

            UIManager.Instance.ModifyDeathText(PlayerInfo.TotalDeaths);

            StopCoroutine(Move());
            StartCoroutine(Move());
        }
    }

    /// <summary>
    /// In this function is verified the player collision with a star
    /// </summary>   
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IReactableObject>() != null)
        {
            reactObj = other.GetComponent<IReactableObject>();
            reactObj.React();

            UIManager.Instance.ModifyCollectablesText(PlayerInfo.TotalStars);
        }
        if (other.name == "CheckPoint")
        {
            spawn.position = other.transform.position;

            other.gameObject.SetActive(false);
        }
    }
    
    /// <summary>
    /// This coroutine keep the player in a position when dies while controlling the momentum
    /// </summary>   
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);

        playerState = PlayerStates.Moving;
    }
}

/// <summary>
/// An enum for the player states
/// </summary>   
public enum PlayerStates
{
    Moving,
    Die
}
