using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void ShowCanvas(bool isactive);
    public static event ShowCanvas showcanvas;
    bool iscollisionwithmaster;
    public GameManager gameManager;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Master")
        {
            Debug.Log("hi i'm the master");
            //Show Press E menu
            if (showcanvas != null)
            {
                showcanvas(true);
                iscollisionwithmaster = true;

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Master")
        {
            //we are out
            //so disable Press E menu
            if (showcanvas != null)
            {
                showcanvas(false);
                iscollisionwithmaster = false;


            }
        }
    }
    private void Update()
    {
        if (iscollisionwithmaster)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //Disable Movement
                GetComponent<PlayerMvt>().enabled = false;
                gameManager.SetQuest();
                //Disable E
                //show New Menu
            }
        }
    }
}
