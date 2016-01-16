using System.Collections.Generic;
using Assets.Sources.GameLogic.Interfaces;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Scripts
{
    public abstract class TableViewVisualizer : UnityEngine.MonoBehaviour
    {
        public RectTransform TableGridTransform;
        public GameObject TableEntryGameObject;

        public IMatcher EntitysToBeViewed;

        private Pool pool;
        private Dictionary<int, GameObject> tableContents;

        public void Start()
        {
            pool = Pools.pool;
            pool.GetGroup(EntitysToBeViewed).
                OnEntityAdded += (group, entity, index, component) => OnPilotAdded(entity);

            pool.GetGroup(EntitysToBeViewed).
                OnEntityRemoved += (group, entity, index, component) => OnPilotRemoved(entity);

            tableContents = new Dictionary<int, GameObject>();
        }

        private void OnPilotAdded(Entity entity)
        {
            if (tableContents.ContainsKey(entity.creationIndex))
            {
                tableContents[entity.creationIndex].GetComponent<IEntityVisualizer>().EntityUpdated(entity);
            }
            else
            {
                var tableEntryObject = Instantiate(TableEntryGameObject);
                tableEntryObject.transform.SetParent(TableGridTransform.transform);
                tableEntryObject.GetComponent<IEntityVisualizer>().EntityUpdated(entity);
                tableContents.Add(entity.creationIndex, tableEntryObject);
            }
        }

        private void OnPilotRemoved(Entity entity)
        {
            if (tableContents.ContainsKey(entity.creationIndex))
            {
                var entryToRemove = tableContents[entity.creationIndex];
                Destroy(entryToRemove.gameObject);
            }
        }
    }
}