using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
       get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    instance = go.AddComponent<T>();
                }
            }

            return instance;
        }
    }
    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            print("Instance class name :"+typeof(T).Name);
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
}
