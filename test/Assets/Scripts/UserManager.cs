using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserManager : MonoBehaviour
{
    public TextMeshProUGUI output;
    private Button button;
    public GameObject buttonPrefab;
    public DataBase dataBase;

    // Start is called before the first frame update
    void Start()
    {
        dataBase = GameObject.Find("Load Data").GetComponent<DataBase>();
        button = GetComponent<Button>();
        //button.onClick.AddListener(SetUser);
        ButtonPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUser()
    {
        foreach (var detail in dataBase.userDetail)
        {   if (detail.userId == 0)
            {
                output.text = "Name: " + detail.name + "\r\n" + "Age: " + detail.age + "\r\n"
                + "Relation: " + detail.relation;
            }
            if (detail.userId == 1)
            {
                output.text = "Name: " + detail.name + "\r\n" + "Age: " + detail.age + "\r\n"
                + "Relation: " + detail.relation;
            }
        }
    }

    void ButtonPrefab()
    {
        Instantiate(buttonPrefab, transform.position - new Vector3(0, -50.0f, 0), buttonPrefab.transform.rotation);
    }

}
