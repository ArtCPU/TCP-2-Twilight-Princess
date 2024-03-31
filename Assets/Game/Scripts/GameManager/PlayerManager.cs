using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    [field:SerializeField] public GameObject Player { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

}
