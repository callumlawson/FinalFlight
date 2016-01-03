using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem
{
    public TriggerOnEvent trigger { get { return Matcher.Resource.OnEntityAdded(); } }

    readonly Transform viewContainer = new GameObject("Views").transform;

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            var possibleResource = Resources.Load<GameObject>(e.resource.Name);

            if (possibleResource)
            {
                GameObject gameObject = null;
                try
                {
                    gameObject = UnityEngine.Object.Instantiate(possibleResource);
                }
                catch (Exception)
                {
                    Debug.LogError("Cannot instantiate " + possibleResource);
                }

                if (gameObject != null)
                {
                    gameObject.transform.parent = viewContainer;
                    e.AddView(gameObject);
                }
            }
            else
            {
                Debug.LogError("Couldn't load resource with name: " + e.resource.Name);       
            }
        }
    }
}