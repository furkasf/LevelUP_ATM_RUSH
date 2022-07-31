using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class MiniGameSignals : MonoSingleton<MiniGameSignals>
    {
        public UnityAction<GameObject> onCollisionWithBlock = delegate(GameObject arg0) {  };
        public UnityAction onCollisionWithStack = delegate {  }; // banddan invokela // player dinlesin,
        // - Player dursun,idle a geçsin,
        public UnityAction<int,Transform> onStartMiniGame = delegate {};
        
        
    }
}
