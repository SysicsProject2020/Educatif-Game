using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public InputField pseudo;
    public AudioSource source;
    public Slider VolumeSlider;
    public Button submitButton;
    public static string PlayerName;
    public GameObject AuthMenu;
    public GameObject MenuPlay;
    public bool delatePrefs;
    private void Awake()
    {
        if (delatePrefs == true)
        {
            PlayerPrefs.DeleteAll();
        }
        if (PlayerPrefs.GetString("name")!="")
        {
            PlayerName = PlayerPrefs.GetString("name");
            AuthMenu.SetActive(false);
            MenuPlay.SetActive(true);
        }
        if (PlayerPrefs.HasKey("volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("volume");
            source.volume = VolumeSlider.value;
        }
        else
        {
            AuthMenu.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pseudo.text.Length>2)
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;

        }
    }

    public void SubmitButton()
    {
        PlayerPrefs.SetString("name", pseudo.text);
        PlayerName = pseudo.text;
    }

    public void changeSoundValue(Slider s)
    {
        source.volume = s.value;
        PlayerPrefs.SetFloat("volume",s.value);
        
    }
}
