using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp || bndCheck.offDown || bndCheck.offRight || bndCheck.offLeft)
        {
            Destroy(gameObject);
        }
    }

    // Destroy projectile if it hits a platform
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
