using System;
using System.Collections;
using DefaultNamespace.Constants;
using DefaultNamespace.Field;
using DefaultNamespace.InputService;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.GamePlay.Ore.WorkerComponents
{
    public class WorkerMover : MonoBehaviour
    {
        [SerializeField] private WorkerFacade _workerFacade;
        private FieldCell _cell;
        private MiningField _field;
        private IInputService _input;
        private Vector3 _mouseStartPosition;
        private float _startDragY;
        private bool _isDragging;
        public bool IsFlying { get; private set; }
        private Vector3 _offset;

        public void Construct(MiningField field, FieldCell cell, IInputService input)
        {
            _input = input;
            _field = field;
            _cell = cell;
        }

        private void Update()
        {
            if (_isDragging)
            {
                gameObject.layer = 2;
                var targetPosition = _input.GetMouseWorldPosition() + _offset;
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(targetPosition.x, _startDragY + GameConstants.FlyHeight, targetPosition.z),
                    GameConstants.DragLerp);
            }
            else
            {
                gameObject.layer = 0;
            }
        }

        private void OnMouseDown()
        {
            IsFlying = true;
            _workerFacade.OnFly();
            StopAllCoroutines();
            _isDragging = true;
            _offset = transform.position - _input.GetMouseWorldPosition();
            _startDragY = transform.position.y;
        }


        private void OnMouseUp()
        {
            _isDragging = false;
            StopAllCoroutines();
            var cell = _field.FindNearestFree(transform.position, true);
            if (cell.HasWorker())
            {
                if (cell.TryMerge(_workerFacade))
                {
                    return;
                }
                else
                {
                    cell = _field.FindNearestFree(transform.position, false);
                    EnterCell(cell);
                }
            }
            else
            {
                EnterCell(cell);
            }

            StartCoroutine(MoveTo(_cell.GetRoot().position , _workerFacade.OnGrounded));
        }

        private void EnterCell(FieldCell cell)
        {
            _cell.Free();
            _cell = cell;
            _cell.Fill(_workerFacade);
            StartCoroutine(MoveTo(_cell.GetRoot().position , _workerFacade.OnGrounded));
        }

        private IEnumerator MoveTo(Vector3 target , Action callback  = null)
        {
            float progress = 0;
            while (progress < 1f)
            {
                transform.position = Vector3.Lerp(transform.position, target, progress);
                progress += GameConstants.BaseMoveLerpCof;
                yield return new WaitForFixedUpdate();
            }
            IsFlying = false;
            callback?.Invoke();
        }
    }
}