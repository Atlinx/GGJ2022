using System;
using System.Collections.Generic;
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

        public List<PlayerCore> players;
        
        public UnityEvent OnPlayerDimensionSwap;
        public UnityEvent OnPlayersInDim1Swap;
        public UnityEvent OnPlayersInDim2Swap;
        public UnityEvent OnPlayersMixed;

        public Transform RespawnLocations;
        public void Start()
        {
            OnPlayersInDim1Swap?.Invoke();
            _instance = this;
        }
        
        
        public void SwapDimension(PlayerCore player)
        {
            
            player.SwapDimension();
            OnPlayerDimensionSwap?.Invoke();


            int currentDimension = players[0].dimensionID;
            
            foreach(var _player in players)
            {
                if (currentDimension != _player.dimensionID)
                {
                    //OnPlayersMixed?.Invoke();
                    return;
                }
            }

            if (currentDimension == 0)
            {
                OnPlayersInDim1Swap?.Invoke();
            }else if (currentDimension == 1)
            {
                OnPlayersInDim2Swap?.Invoke();
            }

            //Maybe keep this wrapper open for events, so on swap play sound fx?
        }


        public Vector3 GetRandomRespawnPoint()
        {
            int child = Random.Range(0, RespawnLocations.childCount);

            return RespawnLocations.GetChild(child).position;
        }
    }
}
