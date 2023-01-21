using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent<Mineral> OnMineralExtracted = new UnityEvent<Mineral>();
}
