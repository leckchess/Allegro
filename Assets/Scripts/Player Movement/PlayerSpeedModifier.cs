using UnityEngine;

public class PlayerSpeedModifier : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetResistanceSpeed(_speed);
        }
        if (other.TryGetComponent(out FirstPerson firstPerson))
        {
            firstPerson.SetResistanceSpeed(_speed);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetResistanceSpeed(0);
        }
        
        if (other.TryGetComponent(out FirstPerson firstPerson))
        {
            firstPerson.SetResistanceSpeed(0);
        }
    }
}
