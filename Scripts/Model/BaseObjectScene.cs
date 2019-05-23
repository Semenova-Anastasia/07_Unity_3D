using UnityEngine;

namespace GeekBrains
{
    /// <summary>
    /// Базовый класс всех объектов на сцене.
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        private int _layer;

        /// <summary>
        /// Физическое свойство объекта
        /// </summary>
        public Rigidbody Rigidbody { get; private set; }

        /// <summary>
        /// Transform объекта
        /// </summary>
        public Transform Transform { get; private set; }

        /// <summary>
        /// Слой объекта.
        /// </summary>
        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }

        /// <summary>
        /// Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="layer">Слой</param>
        private void AskLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount <= 0) return;

            foreach (Transform child in obj)
            {
                AskLayer(child, layer);
            }
        }

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
        }
    }
}
