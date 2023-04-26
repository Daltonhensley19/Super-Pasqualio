using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;

    [Header("Set in Inspector")]
    public float speed = 30f;
    public float rollMult = -45f;
    public float pitchMult = 30f;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("Set Dynamically")]
    [SerializeField]
    private float _shieldLevel = 1f;
    private GameObject lastTriggerGo = null;
    public float buttonTime = 0.1f;
    float jumpTime;
    bool isJumping;
    public float jumpSize = 0.0001f;
    public bool onGround = true;


    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            // Alert that we tried to create two copies of Hero, only one is allowed!
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        //pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(0, xAxis * rollMult, 0);

        if (Input.GetMouseButtonDown(0))
        {
            TempFire();
        }

        Debug.Log(onGround);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onGround)
                {
                    jumpTime = 0;
                    isJumping = true;
                }
            }
            if (isJumping)
            {

                Rigidbody rigidB = transform.GetComponent<Rigidbody>();

                //update the position for jump
                jumpTime += Time.deltaTime;
                rigidB.velocity = rigidB.velocity + new Vector3(0, jumpSize * jumpTime * 0.06f, 0);

                if (Input.GetKeyUp(KeyCode.Space) || jumpTime > buttonTime)
                {
                    isJumping = false;
                    
                }


            }

        if (!onGround)
        {

            Rigidbody rigidB = transform.GetComponent<Rigidbody>();
            rigidB.velocity = rigidB.velocity + new Vector3(0, -(jumpSize * jumpTime * 0.04f) * 0.2f, 0);
        }

       
    }
    
    void FixedUpdate()
    {
        Rigidbody rigidB = transform.GetComponent<Rigidbody>();
        rigidB.AddForce(Physics.gravity * rigidB.mass); 
    }


    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = ((worldMousePos - transform.position));
        direction.Normalize();

        rigidB.velocity = direction * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        if (other.gameObject.tag == "Platform")
        {
            onGround = true;
        }


        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy")
        {
            shieldLevel--;
            Destroy(go);
        }

       
    }

   void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            onGround = false;
        }

    }


    public float shieldLevel
    {
        get
        {
            return _shieldLevel;
        }

        set
        {
            _shieldLevel = Mathf.Min(value, 4);

            if (value < 0)
            {
                Destroy(this.gameObject);


                Main1.S.DelayedRestart(gameRestartDelay);
            }
        }
    }
}
