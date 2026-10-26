using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour
{
    protected virtual void Start()
    {
        Debug.Log(name + "Created");
    }
    protected virtual void OnDestroy() 
    {
        Debug.Log(name + "Destroyed");
    }
    protected virtual void Remove()
    {
        Destroy(gameObject);        
    }
}

