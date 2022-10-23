using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrainingArchitecture
{
    public abstract class ScenManagerBase
    {

        public event Action<Scen> OnScenLoadEvent;
        public Scen scen { get; private set; }
        
        public bool IsLoadedScen { get; private set; }  // булевая для проверки загрузилась ли сцена

        protected Dictionary<string, ScenConfig> _scenConfigsDic; // список ScenConfig


        public ScenManagerBase()
        {
            this._scenConfigsDic = new Dictionary<string, ScenConfig>();
            this.InitScenDic();
        }

        protected internal abstract void InitScenDic();// в дочерних классах будет инициализироваться список сцен

        public Coroutine LoadCurrentScenAsync()
        {
            if (IsLoadedScen) throw new Exception("Scen is load now");

            var scenName = SceneManager.GetActiveScene().name;
            var config = _scenConfigsDic[scenName];
            return Coroutines.StartCoroutineMain(LoadCurrentScenCoroutine(config));

        }

        public Coroutine LoadNewScenAsync(string scenName)
        {
            if (IsLoadedScen) throw new Exception("Scen is load now");
            var config = _scenConfigsDic[scenName];
            return Coroutines.StartCoroutineMain(LoadNewScenCoroutine(config));

        }
        
        
        private IEnumerator LoadCurrentScenCoroutine(ScenConfig scenConfig)
        {
            this.IsLoadedScen = true;
            
            yield return Coroutines.StartCoroutineMain(InitialazeScenCorutin(scenConfig));

            this.IsLoadedScen = false;
            this.OnScenLoadEvent?.Invoke(scen);
        }

        private IEnumerator LoadNewScenCoroutine(ScenConfig scenConfig)  //вызов корутин и инвок события
        {
            this.IsLoadedScen = true;

            yield return Coroutines.StartCoroutineMain(LoadScenAsyncCorutin(scenConfig));
            yield return Coroutines.StartCoroutineMain(InitialazeScenCorutin(scenConfig));

            this.IsLoadedScen = false;
            this.OnScenLoadEvent?.Invoke(scen);
        }
        
        
        private IEnumerator LoadScenAsyncCorutin(ScenConfig scenConfig)  //Загрузка сцены
        {
            var async = SceneManager.LoadSceneAsync(scenConfig.scenName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f) // когда сцена прогрузится на 90 %
                yield return null;

            async.allowSceneActivation = true;

        }
        
        private IEnumerator InitialazeScenCorutin(ScenConfig scenConfig) //Инициализирует базы данных и интеракторы
        {
            this.scen = new Scen(scenConfig);
            yield return  this.scen.InitializeAsync();
        }
        
        
        public T GetDataBase<T>() where T:DataBase  //добавляем базы данных и интеракторы
        {
            return this.scen.GetDataBase<T>();
        }
        public T GetInteractor<T>() where T:Interaktor
        {
            return this.scen.GetInteractor<T>();
        }
        
    }
}