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

    void Awake()
    {
        spawn = GameObject.Find("Spawn").transform;
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        playerState = PlayerStates.Die;
        playerTransform = transform;
        StartCoroutine(Move());
    }

    private void Update()
    {
        if(rb.IsSleeping())
        {
            rb.WakeUp();
        }
    //    if(transform.position.y <= -5)
    //    {
    //        StopCoroutine(Move());
    //        StartCoroutine(Move());
    //    }
    }

        

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (playerState == PlayerStates.Die)
            rb.MovePosition(spawn.position);

        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<IReactableObject>() != null)
        {
            reactObj = collision.collider.GetComponent<IReactableObject>();
            reactObj.React();
            UIManager.ModifyDeathText(PlayerInfo.TotalDeaths);
            StopCoroutine(Move());
            StartCoroutine(Move());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IReactableObject>() != null)
        {
            reactObj = other.GetComponent<IReactableObject>();
            reactObj.React();
            UIManager.ModifyCollectablesText(PlayerInfo.TotalCubies, PlayerInfo.TotalStars);
        }
    }
    
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);
        playerState = PlayerStates.Moving;
    }
}

public enum PlayerStates
{
    Moving,
    Die
}