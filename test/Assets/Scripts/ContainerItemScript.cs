using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerItemScript : MonoBehaviour
{
    private UsersDataBase UsersDataBaseScript;

    [SerializeField] private Text details;
    [SerializeField] private RectTransform content;
    [SerializeField] private ContainerItem prefab;
    [SerializeField] private List<ContainerItem> someUser = new List<ContainerItem>();

    private void Start()
    {
        UsersDataBaseScript = GameObject.Find("UsersDataBase").GetComponent<UsersDataBase>();
        prefab = Resources.Load("ItemPrefab", typeof(ContainerItem)) as ContainerItem;
        FillItemsViewFromData();
    }

    private void FillItemsViewFromData()
    {
        foreach (var user in UsersDataBaseScript.userDetail)
        {
            var item = GameObject.Instantiate(prefab, content) as ContainerItem;
            item.Init(user.name);
            someUser.Add(item);
            
        }
    }

    public class ContainerItem : MonoBehaviour
    {
        [SerializeField] private Text initUserName;
        [SerializeField] private Button clickButton;

        public void Init(string payload)
        {
            initUserName.text = payload;
            clickButton.onClick.AddListener(
            () =>
            {
                
                //GetComponent<ContainerItemScript>().details.text = "Name: " + user.name + "\r\nAge: " + user.age + "\r\nRelation: " + user.relation;              
            }
            );
        }
    }
}
