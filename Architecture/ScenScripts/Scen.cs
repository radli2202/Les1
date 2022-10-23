using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingArchitecture
{
    public class Scen
    {
        private InteractorBase interactorBase;
        private DataBaseBase dataBaseBase;
        private ScenConfig _scenConfig;

        public Scen(ScenConfig scenConfig)
        {
            this._scenConfig = scenConfig; //ссылка на ScenConfig
            this.interactorBase = new InteractorBase(scenConfig); 
            this.dataBaseBase = new DataBaseBase(scenConfig);
        }


        public T GetDataBase<T>() where T : DataBase //добавляем базы данных
        {
          return   this.dataBaseBase.GetDataBase<T>();
        }
        public T GetInteractor<T>() where T : Interaktor//добавляем интеракторы
        {
            return   this.interactorBase.GetInteractor<T>();
        }


        public Coroutine InitializeAsync() 
        {
           return Coroutines.StartCoroutineMain(this.StartInitializeQorutine());// запускаем корутину через обработчик корутин

        }
        private IEnumerator StartInitializeQorutine()  // корутина создает все интеракторы и Бд
        {
           
            
            interactorBase.CreatAllInteractors();
            dataBaseBase.CreatAlldate();
            
            yield return null;
            
            interactorBase.Send_OnCreat_AllInteractor();
            dataBaseBase.Send_OnCreat_AlldataBase();

            yield return null;
            
            interactorBase.Send_Initialize_AllInteractor();
            dataBaseBase.Send_Initialize_AlldataBase();

            yield return null;
            
            interactorBase.Send_OnStart_AllInteractor();
            dataBaseBase.Send_OnStart_AlldataBase();
        }

    }
}