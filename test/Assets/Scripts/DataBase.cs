using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataBase : MonoBehaviour
{
    public List<Users> userDetail = new List<Users>();
    

    // Start is called before the first frame update
    void Start()
    {
        ReadJSON();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    [System.Serializable]
    public class Users
    {
        public string name;
        public int age;
        public int relation;
        public int userId;
    }

    public void ReadJSON()
     {
        string path = Application.streamingAssetsPath + "/Users.dat";
        string JSONString = File.ReadAllText(path);      
        Users[] user = JsonHelper.FromJson<Users>(JSONString);
        
 
        for (int i = 0; i < user.Length; i++)
        {
            userDetail.Add(new Users() {userId = i, name = user[i].name, age = user[i].age, relation = user[i].relation });
            
        }

        
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
