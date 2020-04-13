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
    public List<Pos> Allpos;
    public AlphabeticManager alphabeticManager;
    private void Awake()
    {
        foreach (var item in quests)
        {
            //int index = -1;
            int index = Allpos.FindIndex(d => d.Name == item.MissionName);
            /*for (int i = 0; i < Allpos.Count; i++)
            {
                if (Allpos[i].Name==item.MissionName)
                {
                    index = i;
                }
            }*/
            if (index!=-1)
            {
                for (int i = 0; i < Allpos[index].poss.Count; i++)
                {
                    item.itemPositions[i].position = Allpos[index].poss[i].position;
                }
            }
        }
    }
    void Start()
    {

        foreach (var item in quests)
        {
            item.Init();
        }
    }

    // Update is called once per frame
  

     void SetupCanvas(Quest q)
    {
        switchquest = q;
        MissionImage.sprite = q.icon;
        Title.text = q.MissionName;
        Desc.text = q.Desc;
        alphabeticManager.questInit();
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
                    return;
                }
            }
        }
    }
    public void continueButton()
    {
        switchquest.isprogress = true;
        DialogueCanvas.SetActive(false);
        playerMvt.enabled = true;
        for (int i = 0; i < switchquest.itemPositions.Count; i++)
        {
            GameObject _obj = Instantiate(switchquest.itemPositions[i].obj, switchquest.itemPositions[i].position, Quaternion.identity);
            _obj.GetComponent<ItemCollectable>().GetText(switchquest.itemPositions[i].text);

        }

    }
    private void Update()
    {
       
        
    }
}

//u can see it in inspector without herite from monobehavior
[System.Serializable]
public class Pos
{
    public string Name;
    public List<Transform> poss;

}
