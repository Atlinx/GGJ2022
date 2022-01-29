using Game.Player;
using UnityEngine;

namespace Game.Dimensions
{
    public class DimensionCore : MonoBehaviour
    {
        public void SwapDimension(PlayerCore player)
        {
            player.SwapDimension();
            
            //Maybe keep this wrapper open for events, so on swap play sound fx?
        }
    }
}
