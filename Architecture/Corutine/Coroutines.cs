using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    
    //Оброботчик корутин которые можно выполнить из класса без MonoBehaviour
 
    public static Coroutines instanse
    { get
        {
            if (m_instanse == null)
            {
                var go = new GameObject("[Coroytine_Manadger]");
                m_instanse = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return m_instanse;
        }
    }
    private static Coroutines m_instanse;

    public static Coroutine StartCoroutineMain(IEnumerator enumerator)
    {
       // return Coroutines.StartCoroutineM(enumerator);
        return instanse.StartCoroutine(enumerator);
    }

    public static void StopCoroutineMain(Coroutine routine)
    {
       // Coroutines.StopCoroutine(routine);
        instanse.StopCoroutine(routine);
        
    }

  
}
