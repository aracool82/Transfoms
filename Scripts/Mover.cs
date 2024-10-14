using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed = 6f;

    private void Update() =>
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
}