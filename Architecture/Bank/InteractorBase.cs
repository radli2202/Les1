using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace TrainingArchitecture
{
    public class InteractorBase
    {
        private Dictionary<Type, Interaktor> interactorMap;
        private ScenConfig _scenConfig;

        public InteractorBase(ScenConfig scenConfig)
        {
            this._scenConfig = scenConfig;
        }

        public void CreatAllInteractors()
        {
            this.interactorMap = _scenConfig.CreateAllInteractor();
        }

        public void Send_OnCreat_AllInteractor()
        {
            var allInteractor = interactorMap.Values;
            foreach (var  interactor in allInteractor) interactor.OnCreat();
        }
        public void Send_Initialize_AllInteractor()
        {
            var allInteractor = interactorMap.Values;
            foreach (var  interactor in allInteractor) interactor.Initialize();
        }
        public void Send_OnStart_AllInteractor()
        {
            var allInteractor = interactorMap.Values;
            foreach (var  interactor in allInteractor) interactor.OnStart();
        }
        
        
        
        public  T GetInteractor <T> () where T: Interaktor
        {
            var type = typeof(T);
            return (T) this.interactorMap[type];
        }
        
        
    }
}

