using System.Collections.Generic;
using Assets.Sources.Scripts;
using Entitas;
using UnityEngine;
 
namespace Assets.Sources.GameLogic
{
    //TODO: Add logic for the removal of an entity (not just add/update)
    class TableViewSystem : IInitializeSystem, IReactiveSystem
    {
        public TriggerOnEvent trigger { get { return Matcher.AnyOf(Matcher.Mood, Matcher.Name, Matcher.Health).OnEntityAdded(); } }

        private Dictionary<int, PilotTableEntryVisualizer> tableContents; 
        private RectTransform pilotsGrid;
        private GameObject pilotTableEntry;
        private Pool pool;

        public void Initialize()
        {
            pilotsGrid = UIDirectory.GetInstace().PilotsGrid;
            pilotTableEntry = Resources.Load<GameObject>("PilotEntry");
            tableContents = new Dictionary<int, PilotTableEntryVisualizer>();
        }

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                if (tableContents.ContainsKey(entity.creationIndex))
                {
                    tableContents[entity.creationIndex].UpdatePilotEntry(entity.name.Name, entity.health.Health, entity.mood.Mood);
                }
                else
                {
                    var pilotEntry = GameObject.Instantiate(pilotTableEntry);
                    pilotEntry.transform.SetParent(pilotsGrid.transform);
                    var pilotEntryVisualizer = pilotEntry.GetComponent<PilotTableEntryVisualizer>();
                    pilotEntryVisualizer.UpdatePilotEntry(entity.name.Name, entity.health.Health, entity.mood.Mood);
                    tableContents.Add(entity.creationIndex, pilotEntryVisualizer);
                }
            }
        }
    }
}
