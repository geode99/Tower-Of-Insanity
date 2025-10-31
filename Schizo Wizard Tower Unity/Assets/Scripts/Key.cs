using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
   public enum KeyType
   {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Black,
        White,
        Pink,
        platnium,
        bronze
   }
   
   public KeyType GetKeyType()
    {
        return keyType;
    }
}
