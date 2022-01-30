using System;
using Game.Player;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Game.Dimensions
{
    public class DimensionCore : MonoBehaviour
    {
        //Did not want to do this, but timeeee
        public static DimensionCore _instance;

        public UnityEvent OnPlayerDimensionSwap;

        public Transform RespawnLocations;
        public void Start()
        {
            _instance = this;
        }
        
        
        public void SwapDimension(PlayerCore player)
        {
            
            player.SwapDimension();
            OnPlayerDimensionSwap?.Invoke();
            
            //Maybe keep this wrapper open for events, so on swap play sound fx?
        }


        public Vector3 GetRandomRespawnPoint()
        {
            int child = Random.Range(0, RespawnLocations.childCount);

            return RespawnLocations.GetChild(child).position;
        }
    }
}
