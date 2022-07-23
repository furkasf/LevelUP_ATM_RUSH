using System;
using Extentions;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
    

        public event Action<int> onChangeAtmScore;
        public event Action<int> onChangePlayerScore;

        protected override void Awake()
        {
            base.Awake();
        }
        
    }
}
