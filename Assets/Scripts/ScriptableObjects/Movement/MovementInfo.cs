using UnityEngine;

[CreateAssetMenu(fileName = "New MovementInfo", menuName = "Info/Movement")]
public class MovementInfo : ScriptableObject
{
    [SerializeField] private float movementSpeed;

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set 
        {
            if (value >= 0)
            {
                movementSpeed = value;
            }
            else
            {
                Debug.LogError("movement speed cannot be lower than 0.");
            }
        }
    }
}
