using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public GameObject Mycanvas;
    private void OnEnable()
    {
        PlayerEvents.showcanvas += show;
    }
    private void OnDisable()
    {

        PlayerEvents.showcanvas -= show;

    }

    void show(bool active)
    {
        if (Mycanvas.activeInHierarchy==active)
        {
            return;
        }
        else
        {
        Mycanvas.SetActive(active);

        }
    }

}
