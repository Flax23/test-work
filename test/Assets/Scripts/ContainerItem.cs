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

    public ContainerItemScript ContainerItemScript;

    private void Start()
    {       
        ContainerItemScript = GameObject.Find("Content").GetComponent<ContainerItemScript>();
    }
    public void Init(string payload, UsersDataBase.Users users)
    {
        testName = payload;

        this.initUserName = GameObject.Find("TitleText").GetComponent<Text>();
        this.clickButton = GameObject.Find("ClickButton").GetComponent<Button>();

        this.initUserName.text = payload;
        this.clickButton.onClick.AddListener(
        () =>
        {                         
             ContainerItemScript.details.text = "Name: " + users.name + "\r\nAge: " + users.age + "\r\nRelation: " + users.relation;           
        }
        );
    }
}
