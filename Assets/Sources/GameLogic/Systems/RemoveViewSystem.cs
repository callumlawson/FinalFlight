using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RemoveViewSystem : IMultiReactiveSystem, ISetPool, IEnsureComponents
{
    public TriggerOnEvent[] triggers
    {
        get { return new[] {Matcher.Resource.OnEntityRemoved()};}
    }

    public IMatcher ensureComponents { get { return Matcher.View; } }

    public void SetPool(Pool pool)
    {
        pool.GetGroup(Matcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component)
    {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.GameObject);
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            e.RemoveView();
        }
    }
}

