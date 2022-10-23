using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingArchitecture
{
    public abstract class DataBase
    {

     
      
        
        public  virtual void OnCreat(){}
      
        public abstract void Initialize();
        public  virtual  void OnStart(){}
        public abstract void Save();
    }
    
}


