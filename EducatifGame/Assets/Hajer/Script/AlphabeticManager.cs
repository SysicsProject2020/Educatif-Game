using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class AlphabeticManager : MonoBehaviour
{
    public List<Alphabetic> alphabetics;
    // Start is called before the first frame update
    void Start()
    {
        initList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void initList()
    {
        foreach (var item in alphabetics)
        {
            item.Init();
        }
    }

    public void getCollectableObj(ItemCollectable itemCollectable)
    {
        foreach (var item in alphabetics)
        {
          if(  item.objCollectable == null)
            {
                string lettre = itemCollectable._alphabet;
                foreach (var alphabet in GameManager.switchquest.itemPositions)
                {
                    if (lettre == alphabet.text && alphabet.iscollected==false)
                    {
                        itemCollectable.gameObject.SetActive(false);
                        item.obj.SetActive(true);
                        item.objCollectable = itemCollectable.gameObject;
                        item.objText.text = itemCollectable._alphabet;
                        alphabet.iscollected = true;
                        GameManager.switchquest.Checkobj();
                        return;
                    }
                   
                }

               
                return;
           

            }
        }
    }

    public void questInit()
    {
        foreach (var item in alphabetics)
        {
            item.objCollectable = null;
            item.obj.gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class Alphabetic
{
    public GameObject obj;
    public Text objText;
    public GameObject objCollectable;
    
       public void Init() 
    {
        obj.SetActive(false);
        objText.text = "";
        objCollectable = null;
    }
}