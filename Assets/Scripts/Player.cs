using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float hp = 100;
    [Header("Player_Screen")]
    public Image hp_image;

    [Header("Item_Screen")]
    public GameObject Item_UI;
    public Image item_1;
    public Image item_2;
    public Image item_3;
    public Image item_4;
    public Image item_5;
    public Image item_6;
    public Image item_7;
    public Image item_8;
    public Image item_9;
    public Image item_10;

    public Text count_1;
    public Text count_2;
    public Text count_3;
    public Text count_4;
    public Text count_5;
    public Text count_6;
    public Text count_7;
    public Text count_8;
    public Text count_9;
    public Text count_10;

    [Header("Items")]
    public Sprite bullet_icon;
    public Sprite potion_icon;

    Item[] player_item = new Item[10];
    bool[] item_using = new bool[10];
    private int item_count = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp_image.fillAmount = hp / 100;
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
    public void Item_Use(int index)
    {

    }
    public void Item_remove(int i)
    {
        Item empty = new Item(0);
        player_item[i] = empty;
        var tempColor = item_1.color;
        tempColor.a = 0;
        
    }
    public void BulletItemPush()
    {
        if(item_count < 10)
        {
            Item bullet = new Item(1, 10);
            var tempColor = item_1.color;
            tempColor.a = 1f;
            player_item[item_count] = bullet;
            switch (item_count)
            {
                case 0:
                    item_1.GetComponent<Image>().sprite = bullet_icon;
                    item_1.color = tempColor;
                    count_1.text = bullet.Item_count.ToString();
                    item_using[0] = true;
                    break;
                case 1:
                    item_2.GetComponent<Image>().sprite = bullet_icon;
                    item_2.color = tempColor;
                    count_2.text = bullet.Item_count.ToString();
                    item_using[1] = true;
                    break;
                case 2:
                    item_3.GetComponent<Image>().sprite = bullet_icon;
                    item_3.color = tempColor;
                    count_3.text = bullet.Item_count.ToString();
                    item_using[2] = true;
                    break;
                case 3:
                    item_4.GetComponent<Image>().sprite = bullet_icon;
                    item_4.color = tempColor;
                    count_4.text = bullet.Item_count.ToString();
                    item_using[3] = true;
                    break;
                case 4:
                    item_5.GetComponent<Image>().sprite = bullet_icon;
                    item_5.color = tempColor;
                    count_5.text = bullet.Item_count.ToString();
                    item_using[4] = true;
                    break;
                case 5:
                    item_6.GetComponent<Image>().sprite = bullet_icon;
                    item_6.color = tempColor;
                    count_6.text = bullet.Item_count.ToString();
                    item_using[5] = true;
                    break;
                case 6:
                    item_7.GetComponent<Image>().sprite = bullet_icon;
                    item_7.color = tempColor;
                    count_7.text = bullet.Item_count.ToString();
                    item_using[6] = true;
                    break;
                case 7:
                    item_8.GetComponent<Image>().sprite = bullet_icon;
                    item_8.color = tempColor;
                    count_8.text = bullet.Item_count.ToString();
                    item_using[7] = true;
                    break;
                case 8:
                    item_9.GetComponent<Image>().sprite = bullet_icon;
                    item_9.color = tempColor;
                    count_9.text = bullet.Item_count.ToString();
                    item_using[8] = true;
                    break;
                case 9:
                    item_10.GetComponent<Image>().sprite = bullet_icon;
                    item_10.color = tempColor;
                    count_10.text = bullet.Item_count.ToString();
                    item_using[9] = true;
                    break;
            }
            item_count++;
        }
        else
        {
            Debug.Log("공간 부족!!");
        }
    }
    public void PotionItemPush()
    {
        if (item_count < 10)
        {
            Item potion = new Item(2);
            var tempColor = item_1.color;
            tempColor.a = 1f;
            player_item[item_count] = potion;
            switch (item_count)
            {
                case 0:
                    item_1.GetComponent<Image>().sprite = potion_icon;
                    item_1.color = tempColor;
                    count_1.text = potion.Item_count.ToString();
                    break;
                case 1:
                    item_2.GetComponent<Image>().sprite = potion_icon;
                    item_2.color = tempColor;
                    count_2.text = potion.Item_count.ToString();
                    break;
                case 2:
                    item_3.GetComponent<Image>().sprite = potion_icon;
                    item_3.color = tempColor;
                    count_3.text = potion.Item_count.ToString();
                    break;
                case 3:
                    item_4.GetComponent<Image>().sprite = potion_icon;
                    item_4.color = tempColor;
                    count_4.text = potion.Item_count.ToString();
                    break;
                case 4:
                    item_5.GetComponent<Image>().sprite = potion_icon;
                    item_5.color = tempColor;
                    count_5.text = potion.Item_count.ToString();
                    break;
                case 5:
                    item_6.GetComponent<Image>().sprite = potion_icon;
                    item_6.color = tempColor;
                    count_6.text = potion.Item_count.ToString();
                    break;
                case 6:
                    item_7.GetComponent<Image>().sprite = potion_icon;
                    item_7.color = tempColor;
                    count_7.text = potion.Item_count.ToString();
                    break;
                case 7:
                    item_8.GetComponent<Image>().sprite = potion_icon;
                    item_8.color = tempColor;
                    count_8.text = potion.Item_count.ToString();
                    break;
                case 8:
                    item_9.GetComponent<Image>().sprite = potion_icon;
                    item_9.color = tempColor;
                    count_9.text = potion.Item_count.ToString();
                    break;
                case 9:
                    item_10.GetComponent<Image>().sprite = potion_icon;
                    item_10.color = tempColor;
                    count_10.text = potion.Item_count.ToString();
                    break;
            }
            item_count++;
        }
        else
        {
            Debug.Log("공간 부족!!");
        }

    }
}

public class Item
{
    int Item_code; // 0: empty, 1: bullet, 2: potion
    public int Item_count;
    public Item(int _itemcode) 
    {
        if(_itemcode == 0) // empty
        {
            Item_code = _itemcode;
            Item_count = 0;
        }
        else //potion
        {
            Item_code = _itemcode;
            Item_count = 1;
        }
    }
    public Item(int _itemcode, int howmany) //bullet
    {
        if(_itemcode == 1)
        {
            Item_code = _itemcode;
            Item_count = howmany;
        }
    }
}