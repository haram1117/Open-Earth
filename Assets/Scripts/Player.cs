using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float hp = 100;
    [Header("Player_Screen")]
    public Image PlayerHP;

    [Header("Item_Screen")]
    public GameObject Item_UI;
    

    [Header("Items")]
    public Sprite bullet_icon;
    public Sprite potion_icon;

    bool[] item_using = new bool[10];
    private int item_count = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
            OpenInventory();
        else if (Input.GetKeyUp(KeyCode.Tab))
            CloseInventory();
    }
    void OpenInventory()
    {
        Item_UI.SetActive(true);
    }
    
    void CloseInventory()
    {
        Item_UI.SetActive(false);
    }

  

}