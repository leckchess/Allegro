using UnityEngine;

public class PlayerSpeedModifier : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetResistanceSpeed(_speed);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetResistanceSpeed(0);
        }
    }
}
