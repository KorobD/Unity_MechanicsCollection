using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> where T : PooledObject
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private Stack<T> pool;


    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;
        
        this.CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        
        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new Stack<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createObject = Object.Instantiate(this.prefab, this.container);
        createObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Push(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }

        if (this.autoExpand)
        {
            return this.CreateObject(isActiveByDefault: true);
        }

        throw new Exception($"There is no free elements in pool of type{typeof(T)}");
    }
}
