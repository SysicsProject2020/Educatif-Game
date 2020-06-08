using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;
public class PlayerEvents : MonoBehaviour
{
    public delegate void ShowCanvas(bool isactive);
    public static event ShowCanvas showcanvas;
    bool iscollisionwithmaster;
    public GameManager gameManager;
    public AlphabeticManager alphabeticManager;
    public GameObject MasterCam;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Master")
        {
            Debug.Log("hi i'm the master");
            //Show Press E menu
            if (showcanvas != null)
            {
                showcanvas(true);
                collision.transform.gameObject.GetComponentInChildren<Animator>().SetBool("talking", true);
                MasterCam.SetActive(true);
                iscollisionwithmaster = true;

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ItemCollectable>()!=null)
        {
            alphabeticManager.getCollectableObj(collision.gameObject.GetComponent<ItemCollectable>());
            Speech.instance.Say(collision.gameObject.GetComponent<ItemCollectable>()._alphabet, TTSCallback);
        }
    }
    void TTSCallback(string message, AudioClip audio)
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }

        source.clip = audio;
        source.Play();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Master")
        {
            //we are out
            //so disable Press E menu
            if (showcanvas != null)
            {
                collision.transform.gameObject.GetComponentInChildren<Animator>().SetBool("talking", false);
                MasterCam.SetActive(false);

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
