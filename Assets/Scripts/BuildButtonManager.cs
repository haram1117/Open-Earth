using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonManager : MonoBehaviour
{
    public GameObject blueprint_tree3;
    public GameObject BuildPanel;
    bool BuildButtonOn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (BuildButtonOn)
            {
                BuildPanel.SetActive(false);
                BuildButtonOn = false;
            }
            else
            {
                BuildPanel.SetActive(true);
                BuildButtonOn = true;
            }
            
        }
        Debug.Log(BuildButtonOn);
    }
    public void BuildTree()
    {
        Instantiate(blueprint_tree3);
    }
}
