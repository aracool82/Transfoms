using UnityEngine;

public class MixedAction : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 60f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField]private float _scaleSpeed = 100f;
    
    private float _stepScale = 0.01f;
    private Vector3 _startScale;
    private Vector3 _endScale;
    private bool _isScaleUp = true;
    private float _offset = 0.02f;

    private void Awake()
    {
        _startScale = transform.localScale;
        _endScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        transform.Rotate(-Vector3.up * _rotationSpeed * Time.deltaTime);

        if (_isScaleUp)
            Scale(transform.localScale, _endScale);
        else
            Scale(transform.localScale, _startScale);
    }

    private void Scale(Vector3 startScale, Vector3 endScale)
    {
        float distance = Vector3.Distance(startScale, endScale);

        if (distance <= _offset)
            _isScaleUp = !_isScaleUp;

        transform.localScale = Vector3.MoveTowards(startScale, endScale, _stepScale * _scaleSpeed * Time.deltaTime);
    }
}