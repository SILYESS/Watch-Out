using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody playerRb;
    public bool playerCaught = false;


    [SerializeField] float rotSpeed;
    [SerializeField] float movSpeed;
    Vector3 inputDir;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerCaught)
        {
            //Rotate Orientation
            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir;

            //Rotate player
            float vertInput = Input.GetAxisRaw("Vertical");
            float horizInput = Input.GetAxisRaw("Horizontal");
            inputDir = orientation.forward * vertInput + orientation.right * horizInput;
        }

        if(inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotSpeed);
        }
    }
    private void FixedUpdate()
    {
        if (!playerCaught)
        {
            player.Translate(inputDir.normalized * movSpeed * Time.deltaTime);
        }
    }
}
