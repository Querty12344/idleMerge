using UnityEngine;

namespace DefaultNamespace.GamePlay.Ore
{
    public class FieldRaycast : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        private Vector3 _mouseOnFieldPosition;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) _mouseOnFieldPosition = hit.point;
        }

        public Vector3 GetMousePosition()
        {
            return _mouseOnFieldPosition;
        }
    }
}