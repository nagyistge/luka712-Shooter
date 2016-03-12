using ShooterGame.GameObjects;
using ShooterGame.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities.Implementation
{
    public class GameObjectList<T> : List<T>, IGameObjectList<T> where T : GameObject
    {
        #region Events

        /// <summary>
        /// Raised when AddGameObject is used.
        /// </summary>
        public event EventHandler OnAddOrRemove;

        #endregion

        #region Methods

        /// <summary>
        /// Add new game objects.
        /// </summary>
        public void AddGameObject(T obj)
        {
            Add(obj);
            OnAddedOrRemoved();
        }

        /// <summary>
        /// Removes game object.
        /// </summary>
        public void RemoveGameObject(T obj)
        {
            Remove(obj);
            OnAddedOrRemoved();
        }

        /// <summary>
        /// Add range of game objets. Raised on added or removed.
        /// </summary>
        public void AddGameObjectRange(IEnumerable<T> range)
        {
            AddRange(range);
            OnAddedOrRemoved();
        }

        /// <summary>
        /// Add range of game objets. Raised on added or removed.
        /// </summary>
        public void AddGameObjectRange(T[] range)
        {
            AddRange(range.ToList());
            OnAddedOrRemoved();
        }
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Notify subscribers.
        /// </summary>
        private void OnAddedOrRemoved()
        {
            if(OnAddOrRemove != null)
            {
                OnAddOrRemove(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
