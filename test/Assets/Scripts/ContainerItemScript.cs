using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class ContainerItemScript : MonoBehaviour
{
    public UsersDataBase usersDataBaseScript;
    // public ContainerItem containerItemScript;

    [SerializeField] private int test;
    public Text details;
    [SerializeField] private RectTransform content;
    [SerializeField] private ContainerItem prefab;
    [SerializeField] private List<ContainerItem> someUser = new List<ContainerItem>();

    private void Start()
    {
        usersDataBaseScript = GameObject.Find("UsersDataBase").GetComponent<UsersDataBase>();
        //containerItemScript = GameObject.Find("Test").GetComponent<ContainerItem>();
        prefab = Resources.Load("Prefabs/ItemPrefab", typeof(ContainerItem)) as ContainerItem;
        FillItemsViewFromData();
    }

    public void FillItemsViewFromData()
    {
        foreach (var user in usersDataBaseScript.userDetail)
        {
            test++;
            var item = GameObject.Instantiate(prefab, content) as ContainerItem;
            item.name = user.name;
            item.Init(item, user);
            someUser.Add(item);                    
        }
    }


}
