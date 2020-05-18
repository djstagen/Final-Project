using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    public GameObject escapeCanvas;
    public GameObject menu;

    // Start is called before the first frame update
    private void Start()
    {
        escapeCanvas.SetActive(false);
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            escapeCanvas.SetActive(true);
            menu.SetActive(true);
        }
    }
}
