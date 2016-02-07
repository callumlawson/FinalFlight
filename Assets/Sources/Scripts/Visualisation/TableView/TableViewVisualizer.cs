using System.Collections.Generic;
using Assets.Sources.GameLogic.Interfaces;
using Assets.Sources.GameLogic.Meta;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Scripts
{
    public abstract class TableViewVisualizer : UnityEngine.MonoBehaviour
    {
        //Configured in Unity
        public GameObject TopLevelOfVisibleUI;
        public RectTransform TableGridTransform;
        public GameObject TableEntryGameObject;
        //Configured in Unity

        public IMatcher EntitysToBeViewed;
        public GameState GameStateWhenVisible;

        private Pool pool;
        private Dictionary<int, GameObject> tableContents;

        public void Start()
        {
            pool = Pools.pool;

            pool.GetGroup(EntitysToBeViewed).OnEntityAdded += (group, entity, index, component) => OnEntityAdded(entity);

            pool.GetGroup(EntitysToBeViewed).OnEntityRemoved +=
                (group, entity, index, component) => OnEntityRemoved(entity);

            pool.GetGroup(Matcher.GameState).OnEntityAdded +=
                (group, entity, index, component) => OnGameStateUpdated(entity.gameState.GameState);

            tableContents = new Dictionary<int, GameObject>();
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            TopLevelOfVisibleUI.SetActive(gameState == GameStateWhenVisible);
        }

        private void OnEntityAdded(Entity entity)
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

        private void OnEntityRemoved(Entity entity)
        {
            if (tableContents.ContainsKey(entity.creationIndex))
            {
                var entryToRemove = tableContents[entity.creationIndex];
                Destroy(entryToRemove.gameObject);
                tableContents.Remove(entity.creationIndex);
            }
        }
    }
}