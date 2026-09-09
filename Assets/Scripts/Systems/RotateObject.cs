using UnityEngine;

/// <summary>
/// Continuously rotates a GameObject around the world Y axis.
/// </summary>
public sealed class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f;

    private void Update()
    {
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.World);
    }
}
