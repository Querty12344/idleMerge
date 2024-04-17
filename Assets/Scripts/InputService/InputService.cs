using UnityEngine;

namespace DefaultNamespace.InputService
{
    internal class InputService : IInputService
    {
        public Vector3 GetMouseWorldPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) return hit.point;

            return Vector3.zero;
        }
    }
}