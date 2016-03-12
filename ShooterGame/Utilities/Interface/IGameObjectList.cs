using ShooterGame.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities.Interface
{
    public interface IGameObjectList<T> : IList<T>, ICollection<T>, IEnumerable<T> where T : GameObject
    {
        event EventHandler OnAddOrRemove;
        void AddGameObject(T obj);
        void RemoveGameObject(T obj);
        void AddGameObjectRange(IEnumerable<T> range);
        void AddGameObjectRange(T[] range);
    }
}
