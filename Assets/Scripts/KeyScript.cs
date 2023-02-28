using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] bool keyPresent = false;
    public GameObject keyPrefab;
    public PlayerScript playerScript;

    GameObject keyInstance;

    private List<Vector3> keyHidouts = new List<Vector3> {new Vector3(25.3f, 0.41f, 29) , new Vector3(38.65f, 0.6f, 50.8f), 
                                                          new Vector3(16.8f,0.11f,51.67f) , new Vector3(14.8f,0.13f,30)};


    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }
    private void Update()
    {
        if (!keyPresent && !playerScript.GetComponent<PlayerScript>().haveKey)
        {
            SpawnKey();
        }
        if (playerScript.GetComponent<PlayerScript>().haveKey)
        {
            Destroy(keyInstance);
        }
    }
    void SpawnKey()
    {
        int randomIndex = Random.Range(0, keyHidouts.Count);
        keyInstance = Instantiate(keyPrefab,keyHidouts[randomIndex],keyPrefab.transform.rotation);
        keyPresent = true;
    }
}
