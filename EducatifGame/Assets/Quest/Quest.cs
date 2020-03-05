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
    }

    
}

[System.Serializable]
public class ItemPositions
{
    public Vector3 position;
    public GameObject obj;
    public string text;
}