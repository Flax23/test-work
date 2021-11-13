using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerItem : MonoBehaviour
{
    //public ContainerItem prefab;

    [SerializeField] private Text initUserName;
    [SerializeField] private Button clickButton;


    public void Init(string payload)
    {
        initUserName.text = payload;
        clickButton.onClick.AddListener(
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
