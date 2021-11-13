using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerItemScript : MonoBehaviour
{
    public UsersDataBase usersDataBaseScript;
   // public ContainerItem containerItemScript;

    public Text details;
    [SerializeField] private RectTransform content;
    [SerializeField] private ContainerItem prefab;
    [SerializeField] private List<ContainerItem> someUser = new List<ContainerItem>();

    private void Start()
    {
        usersDataBaseScript = GameObject.Find("UsersDataBase").GetComponent<UsersDataBase>();
       // containerItemScript = GameObject.Find("Test").GetComponent<ContainerItem>();
        prefab = Resources.Load("Prefabs/ItemPrefab", typeof(ContainerItem)) as ContainerItem;
        FillItemsViewFromData();
    }

    private void FillItemsViewFromData()
    {
        foreach (var user in usersDataBaseScript.userDetail)
        {
            var item = GameObject.Instantiate(prefab, content) as ContainerItem;
            item.Init(user.name);
            someUser.Add(item);         
        }
    }
}
