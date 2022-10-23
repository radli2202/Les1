using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace TrainingArchitecture
{
    public class ScenConfigExample: ScenConfig
    {
        
        public static string ScenNameConst=> SceneManager.GetActiveScene().name;  // Имя текущей сцены, публичное что бы можно было использовать в ScenManagerExample в качестве ключа

        public override string scenName => SceneManager.GetActiveScene().name;

        public override Dictionary<Type, DataBase> CreatAllDataBase()  //создаем список базы данных
        {
            var dataBaseDic = new Dictionary<Type, DataBase>();
            
            this.CreateDataBase<BankDataBase>(dataBaseDic); //метод из наследуемого класса

            return dataBaseDic;
        }

        public override Dictionary<Type, Interaktor> CreateAllInteractor() //создаем список интеракторов
        {
            var interactorDic = new Dictionary<Type, Interaktor>();
            
            this.CreateInteractor<BankInteraktor>(interactorDic);//создаем интерактор BankInteraktor в списке интеракторов
            this.CreateInteractor<PlayerInteractor>(interactorDic); //создаем интерактор PlayerInteractor в списке интеракторов

            return interactorDic;
        }
    }
}