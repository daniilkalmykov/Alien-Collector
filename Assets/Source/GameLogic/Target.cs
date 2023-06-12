using UnityEngine;

namespace GameLogic
{
    public sealed class Target : MonoBehaviour
    {
        [field: SerializeField] public int Id { get; private set; }
    }
}