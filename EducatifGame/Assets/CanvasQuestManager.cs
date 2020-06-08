using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityLibrary;
public class CanvasQuestManager : MonoBehaviour
{
    public string stringQuest ;
    public string Playercollect;
    public GameManager gameManager;
    public AlphabeticManager alphabeticManager;
    public List<GameObject> AllButtons;
    public string switcha;
    public string switchb;

    public List<Text> alltext;

    public List<RawImage> SystemReact;

    public List<GameObject> objToclose;
    // Start is called before the first frame update

    private void OnEnable()
    {
        foreach (var item in objToclose)
        {
            item.SetActive(false);
        }
        stringQuest = GameManager.switchquest.MissionName;
        Playercollect = "";
        foreach (var item in alphabeticManager.alphabetics)
        {
            if (item.obj.activeInHierarchy)
            {
                Playercollect += item.objText.text;
            }
           
        }
        foreach (var item in SystemReact)
        {
            item.gameObject.SetActive(false);
        }
        SystemReact[0].gameObject.SetActive(true);
        foreach (var item in AllButtons)
        {
            item.SetActive(false);
        }
        StartCoroutine(openalphabitics());
      
    }
    void Start()
    {
        
    }
    IEnumerator openalphabitics()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Playercollect.Length; i++)
        {
            AllButtons[i].SetActive(true);
            AllButtons[i].GetComponentInChildren<Text>().text = Playercollect[i].ToString();
            yield return new WaitForSeconds(0.2f)
;        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onswitch(Text text)
    {
        if (alltext.Count==0)
        {
            switcha = text.text;
            alltext.Add(text);
            return;
        }
        if (alltext.Count==1)
        {
            switchb = text.text;
            alltext.Add(text);

        }
        if (alltext.Count==2)
        {
            alltext[0].text = switchb;
            alltext[1].text = switcha;
            alltext.Clear();
           EventSystem.current.SetSelectedGameObject(null);
        }
    }

    IEnumerator talk()
    {
        yield return new WaitForSeconds(0.5f);
        Speech.instance.Say(stringQuest, TTSCallback);
        

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

    public void validateQuest()
    {
        string v = "";
        foreach (var item in SystemReact)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < AllButtons.Count; i++)
        {
            
            v += AllButtons[i].GetComponentInChildren<Text>().text;
            if (i==stringQuest.Length-1)
            {
                if (v==stringQuest)
                {
                    Debug.Log("gooood job");
                    SystemReact[2].gameObject.SetActive(true);
                    StartCoroutine(Backtogame());
                }
                else
                {
                    Debug.Log("try again");
                    SystemReact[1].gameObject.SetActive(true);
                    StartCoroutine(talk());


                }
                return;
            }
        }
        

    }

    IEnumerator Backtogame()
    {
        yield return new WaitForSeconds(2);
        foreach (var item in objToclose)
        {
            item.SetActive(true);
        }
        alphabeticManager.questInit();
        this.gameObject.SetActive(false);
    }

}


