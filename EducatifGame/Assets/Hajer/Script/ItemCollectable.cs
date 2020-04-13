using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollectable : MonoBehaviour
{
    public List<Text> Alltext;
    public string _alphabet;
    public void GetText(string alphabet)
    {
        _alphabet = alphabet;
        foreach (var item in Alltext)
        {
            item.text = alphabet;
        }
    }
}
