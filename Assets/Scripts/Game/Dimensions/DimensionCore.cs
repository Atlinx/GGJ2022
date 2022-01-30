using System;
using Game.Player;
using UnityEngine;

namespace Game.Dimensions
{
    public class DimensionCore : MonoBehaviour
    {
        //Did not want to do this, but timeeee
        public static DimensionCore _instance;

        public void Start()
        {
            _instance = this;
        }


        public void SwapDimension(PlayerCore player)
        {
            Debug.Log("Swapping Dimensions for " + player.name);
            player.SwapDimension();
            
            //Maybe keep this wrapper open for events, so on swap play sound fx?
        }
    }
}
