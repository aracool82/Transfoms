using UnityEngine;

public class LoopMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _step;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool _isMovingFarward = true;
    private float _offset = 0.03f;

    private void Awake()
    {
        _startPosition = transform.position - Vector3.forward;
        _endPosition = transform.position + Vector3.forward;
        transform.position = _startPosition;
    }

    private void Update()
    {
        if (_isMovingFarward)
            Move(transform.position, _endPosition);
        else
            Move(transform.position, _startPosition);
    }

    private void Move(Vector3 startPosition, Vector3 endPosition)
    {
        float distance = Vector3.Distance(startPosition, endPosition);

        if (distance <= _offset)
            _isMovingFarward = !_isMovingFarward;

        transform.position = Vector3.MoveTowards(startPosition, endPosition, _step * _moveSpeed * Time.deltaTime);
    }
}