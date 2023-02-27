using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float movSpeed;
    
    private void Start()
    {
        
    }
    private void Update()
    {;
        var moveDir = (player.transform.position - transform.position).normalized;
        //transform.forward = moveDir;
        transform.Translate(moveDir * Time.deltaTime * movSpeed,Space.World);
        transform.LookAt(player.transform.position);
    }
}
