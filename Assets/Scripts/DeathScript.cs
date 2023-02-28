using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public CameraScript playerMoveScript;
    public Animator deathAnim;
    public bool deathAlive = false;
    public PlayerScript playerScript;

    [SerializeField] float movSpeed;
    
    private void Start()
    {
        playerMoveScript = FindObjectOfType<CameraScript>();
        playerScript = FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (playerScript.GetComponent<PlayerScript>().haveKey && !deathAlive)
        {
            SpawnDeath();
            deathAlive = true;
        }
        var moveDir = (player.transform.position - transform.position).normalized;
        if (deathAlive)
        {
            transform.Translate(moveDir * Time.deltaTime * movSpeed, Space.World);
            transform.LookAt(player.transform.position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMoveScript.GetComponent<CameraScript>().playerCaught = true;
            deathAnim.Play("DeathStrike", 0);
            transform.position = new Vector3(16.5f, -6.8f, -0.8f);
            //Death animation missing 
            player.SetActive(false);
            deathAlive = false;
            playerScript.haveKey = false;
        }
    }
    void SpawnDeath()
    {
        transform.position = new Vector3(5, 0, 29);
    }
}
