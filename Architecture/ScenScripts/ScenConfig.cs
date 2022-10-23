using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrainingArchitecture;

namespace TrainingArchitecture
{
    public abstract class ScenConfig
    {
        
        public abstract string scenName { get; }  
        
        public abstract Dictionary<Type, DataBase> CreatAllDataBase(); // Списки базы данных
        public abstract Dictionary<Type,Interaktor> CreateAllInteractor(); // Списки Интеракторов


public void CreateInteractor<T>(Dictionary<Type,Interaktor> interactorsMap) where T: Interaktor, new ()
{
    var interactor = new T();
    var type = typeof(T);

    interactorsMap[type] = interactor;
}


public void CreateDataBase<T>(Dictionary<Type,DataBase> DataBaseMap) where T: DataBase, new ()
{
    var data = new T();
    var type = typeof(T);

    DataBaseMap[type] = data;
}





    }
    
}

