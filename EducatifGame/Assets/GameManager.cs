using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<Quest> quests;

    public Image MissionImage;
    public Text Title;
    public Text Desc;
    public GameObject DialogueCanvas;
    public static Quest switchquest;
    public PlayerMvt playerMvt;
    void Start()
    {
        foreach (var item in quests)
        {
            item.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void SetupCanvas(Quest q)
    {
        switchquest = q;
        MissionImage.sprite = q.icon;
        Title.text = q.MissionName;
        Desc.text = q.Desc;

    }


    public void SetQuest()
    {
        foreach (var item in quests)
        {
            if (!item.isfinished)
            {
                if (item.isprogress)
                {
                    return;
                }
                else
                {
                    DialogueCanvas.SetActive(true);
                    SetupCanvas(item);
                }
            }
        }
    }
    public void continueButton()
    {
        switchquest.isprogress = true;
        DialogueCanvas.SetActive(false);
        playerMvt.enabled = true;

    }
}
