using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Transform respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("work");
        if(other.tag == "Player")
        {
            print("work please");
            other.GetComponent<PlayerController>().Respawn(respawn);
        }
    }
}
