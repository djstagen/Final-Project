using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject panel;

    private void Start()
    {
        uiObject.SetActive(false);
        panel.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        uiObject.SetActive(true);
        panel.SetActive(true);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        uiObject.SetActive(false);
        panel.SetActive(false);
    }
}
