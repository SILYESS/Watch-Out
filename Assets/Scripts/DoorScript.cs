using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] bool open = false;
    [SerializeField] bool enter = false;
    [SerializeField] float openAngle = 90f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            if (open)
            {
                transform.Rotate(new Vector3(transform.rotation.x, (transform.rotation.y - openAngle), transform.rotation.z));
                open = false;
            }
            else
            {
                transform.Rotate(new Vector3(transform.rotation.x, (transform.rotation.y + openAngle), transform.rotation.z));
                open = true;
            }
        }
    }
    void OnGUI()
    {
        if (enter)
        {
            //GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to interact");
        }
    }
    //

    // Activate the Main function when Player enter the trigger area
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enter = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
