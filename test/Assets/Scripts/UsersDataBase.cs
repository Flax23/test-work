using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class UsersDataBase : MonoBehaviour
{
    public List<Users> userDetail = new List<Users>();

    private void Start()
    {
        ReadJSON();
        //InstantiatePrefab();
        //FillItemsViewFromData();
    }

    //void InstantiatePrefab()
    //{
    //    foreach (var user in userDetail)
    //    {
    //        var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
    //        instance.transform.SetParent(content, false);
    //        InitializeUserView(instance, user);
    //    }
    //}

    //void InitializeUserView(GameObject viewGameObject, Users user)
    //{
    //    TestUserView view = new TestUserView(viewGameObject.transform);

    //    view.titleText.text = "UserID: " + user.userId;
    //    view.clickButton.GetComponentInChildren<Text>().text = "Show";
    //    view.clickButton.onClick.AddListener(
    //        () =>
    //        {
    //            details.text = "Name: " + user.name  + "\r\nAge: " + user.age + "\r\nRelation: " + user.relation;
    //            //Debug.Log(view.titleText.text + " selected!");
    //        }
    //    );
    //}
    

    

    //public class SomePayload
    //{
    //    public string userName;
    //}

    public void ReadJSON()
    {
        string path = Application.streamingAssetsPath + "/Users.dat";
        string JSONString = File.ReadAllText(path);
        Users[] user = JsonHelper.FromJson<Users>(JSONString);
        for (int i = 0; i < user.Length; i++)
        {
            userDetail.Add(new Users() { userId = i, name = user[i].name, age = user[i].age, relation = user[i].relation });
        }
    }

    [System.Serializable]
    public class Users
    {
        public string name;
        public int age;
        public int relation;
        public int userId;
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.users;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.users = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.users = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] users;
        }
    }
}
