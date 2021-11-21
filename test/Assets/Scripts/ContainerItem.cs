using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerItem : MonoBehaviour
{
    //public ContainerItem prefab;

    //[SerializeField] private Text initUserName;
    //[SerializeField] private Button clickButton;

    public ContainerItemScript ContainerItemScript;

    private void Start()
    {       
        ContainerItemScript = GameObject.Find("Content").GetComponent<ContainerItemScript>();
    }
    public void Init(ContainerItem payload, UsersDataBase.Users users)
    {
        Payload view = new Payload(payload.transform);

        //initUserName = GameObject.Find("TitleText").GetComponent<Text>();
        //clickButton = GameObject.Find("ClickButton").GetComponent<Button>();

        view.initUserName.text = users.name;
        view.clickButton.onClick.AddListener(
        () =>
        {                         
             ContainerItemScript.details.text = "Name: " + users.name + "\r\nAge: " + users.age + "\r\nRelation: " + users.relation;           
        }
        );
    }

    public class Payload
    {
        public Text initUserName;
        public Button clickButton;

        public Payload(Transform rootView)
        {
            initUserName = rootView.Find("TitleText").GetComponent<Text>();
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
        }
    }
}
