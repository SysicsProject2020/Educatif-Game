using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollectable : MonoBehaviour
{
    public List<Text> Alltext;
   
    public void GetText(string alphabet)
    {
        foreach (var item in Alltext)
        {
            item.text = alphabet;
        }
    }
}
