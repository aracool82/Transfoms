using UnityEngine;

public class LoopScaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _step;
    
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
        if (_isScaleUp)
            Scale(transform.localScale,_endScale);
        else
            Scale(transform.localScale,_startScale);
    }

    private void Scale(Vector3 startScale, Vector3 endScale)
    {
        float distance = Vector3.Distance(startScale, endScale);

        if (distance <= _offset)
            _isScaleUp = !_isScaleUp;

        transform.localScale = Vector3.MoveTowards(startScale, endScale, _step * _scaleSpeed * Time.deltaTime);
    }
}
