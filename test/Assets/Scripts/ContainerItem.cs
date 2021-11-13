using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerItem : MonoBehaviour
{
    //public ContainerItem prefab;

    [SerializeField] private Text initUserName;
    [SerializeField] private Button clickButton;
    [SerializeField] private string testName;

    public void Init(string payload)
    {
        testName = payload;
        this.initUserName.text = payload;
        this.clickButton.onClick.AddListener(
        () =>
        {
            foreach (var user in GetComponent<ContainerItemScript>().usersDataBaseScript.userDetail)
            {
                GetComponent<ContainerItemScript>().details.text = "Name: " + user.name + "\r\nAge: " + user.age + "\r\nRelation: " + user.relation;
            }
        }
        );
    }
}
