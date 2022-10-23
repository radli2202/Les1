using System.Collections;
using UnityEngine;

namespace TrainingArchitecture.Corutine
{
    public class TestCorutine
    {
        private Coroutine _coroutine;

        public void StartCoroutineTest()
        {
            if(this._coroutine!=null) return;
            _coroutine = Coroutines.StartCoroutineMain(this.testCoroutine());
        }


        public void StopCoroutineTest()
        {
            Coroutines.StopCoroutineMain(_coroutine);
            this._coroutine = null;
        }

        private IEnumerator testCoroutine()
        {
            Debug.Log("+1");
            yield break;
            
        }
        
        
        
    }
}