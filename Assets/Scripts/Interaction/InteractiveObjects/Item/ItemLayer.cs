using UnityEngine;

namespace Interaction.InteractiveObjects.Item
{
    public class ItemLayer : MonoBehaviour
    {
        private Transform[] _childs;
        private int _defaultLayer, _topLayer;

        private void Awake()
        {
            _childs = GetComponentsInChildren<Transform>();
            _defaultLayer = LayerMask.NameToLayer("Default");
            _topLayer = LayerMask.NameToLayer("TopLayer");
        }

        public void ChangeLayer(bool inHand)
        {
            int newLayer = inHand ? _topLayer : _defaultLayer;
            gameObject.layer = newLayer;
            foreach (var child in _childs)
                child.gameObject.layer = newLayer;
        }
    }
}