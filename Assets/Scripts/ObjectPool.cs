using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : IPoolableObject
{
    private readonly Queue<T> _prefabs;
    private readonly T _prefab;

    public ObjectPool(T prefab)
    {
        _prefabs = new Queue<T>();
        _prefab = prefab;
    }

    public void CreateStartPrefabs(int amount)
    {
        for (int i = 0; i < amount; i++)
            Push(GetNew());
    }

    public T Pull()
    {
        if (_prefabs.Count == 0)
            return GetNew();

        T prefab = _prefabs.Dequeue();
        prefab.Enable();

        return prefab;
    }

    public void Push(T obj)
    {
        obj.Disable();
        _prefabs.Enqueue(obj);
    }

    public void SubscribeReturnEvent(T obj)
    {
        obj.ReturnConditionReached += OnReturnConditionReached;
    }

    private void OnReturnConditionReached(IPoolableObject obj)
    {
        obj.ReturnConditionReached -= OnReturnConditionReached;
        Push((T)obj);
    }

    private T GetNew()
    {
        return (T)_prefab.Instantiate();
    }
}

public interface IPoolableObject
{
    public event Action<IPoolableObject> ReturnConditionReached;

    public void Enable();

    public void Disable();

    public IPoolableObject Instantiate();
}