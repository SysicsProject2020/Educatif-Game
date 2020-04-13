using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My items/Quest")]
public class Quest : ScriptableObject
{

    public string MissionName;
    public string Desc;
    public Sprite icon;
    public bool isprogress;
    public bool isfinished;
    public List<ItemPositions> itemPositions;

    public void Init()
    {
        isprogress = false;
        isfinished = false;
        foreach (var _itemPositions in itemPositions)
        {
            _itemPositions.iscollected = false;
        }
    }

    public void Checkobj()
    {
        int j = 0;
        for (int i = 0; i < itemPositions.Count; i++)
        {
            if (itemPositions[i].iscollected==true)
            {
                j++;
            }
            if (j== itemPositions.Count)
            {
                isprogress = false;
                isfinished = true;
            }
        }
    }
}

[System.Serializable]
public class ItemPositions
{
    public Vector3 position;
    public GameObject obj;
    public string text;
    public bool iscollected;
}