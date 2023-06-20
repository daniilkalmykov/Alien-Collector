using System.Collections.Generic;
using Blinders;
using UnityEngine;

namespace GameLogic
{
    public sealed class FightingMapBootstrap : MonoBehaviour
    {
        [SerializeField] private List<HealthBlinder> _healthBlinders = new();
        [SerializeField] private ShootersDistributor _shootersDistributor;

        private void Awake()
        {
            foreach (var healthBlinder in _healthBlinders)
                healthBlinder.Init();
            
            _shootersDistributor.Init();
        }
    }
}