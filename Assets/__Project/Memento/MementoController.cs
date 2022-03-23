using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class MementoController : IMementoController, IUpdate
    {

        private List<IMemento> list;

        public MementoController()
        {
            list = new List<IMemento>();
        }

        public void AddMemento(IMemento memento)
        {
            list.Add(memento);
        }

        public void Save()
        {
            foreach(IMemento memento in list)
            {
                memento.SaveMemento();
            }
        }

        public void Load(int index)
        {
            foreach (IMemento memento in list)
            {
                memento.LoadMemento(index);
            }
        }

        public void LoadPrev()
        {
            foreach (IMemento memento in list)
            {
                memento.LoadPrev();
            }

        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                LoadPrev();
            }
        }
    }
}
