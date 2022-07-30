using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class MiniGameSignals : MonoSingleton<MiniGameSignals>
    {
    
        
        public UnityAction<GameObject> onCollisionWithBlock = delegate(GameObject arg0) {  };
    }
}
