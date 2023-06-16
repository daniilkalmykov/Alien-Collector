using UnityEngine;

namespace Models
{
    public sealed class RaycastCreator
    {
        private readonly Camera _camera;
        private readonly LayerMask _layerMask;
        
        public RaycastCreator(Camera camera, LayerMask layerMask)
        {
            _camera = camera;
            _layerMask = layerMask;
        }
        
        public bool TryCreate(Vector3 position, out RaycastHit hit)
        {
            var ray = _camera.ScreenPointToRay(position);

            return Physics.Raycast(ray, out hit, _layerMask);
        }
    }
}