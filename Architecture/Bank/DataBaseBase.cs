using System;
using System.Collections.Generic;

namespace TrainingArchitecture
{
    public class DataBaseBase
    {
        private Dictionary<Type, DataBase> dateBaseMap;
        private ScenConfig _scenConfig;

        public DataBaseBase(ScenConfig scenConfig)
        {
            this._scenConfig = scenConfig;
          
        }

        public void CreatAlldate()
        {
            this.dateBaseMap = _scenConfig.CreatAllDataBase();
           
        }

        public void Send_OnCreat_AlldataBase()
        {
            var alldataBase = dateBaseMap.Values;
            foreach (var  dataBase in alldataBase) dataBase.OnCreat();
        }
        public void Send_Initialize_AlldataBase()
        {
            var alldataBase = dateBaseMap.Values;
            foreach (var  dataBase in alldataBase) dataBase.Initialize();
        }
        public void Send_OnStart_AlldataBase()
        {
            var alldataBase = dateBaseMap.Values;
            foreach (var  dataBase in alldataBase) dataBase.OnStart();
        }
        
        
        
        public  T GetDataBase <T> () where T: DataBase
        {
            var type = typeof(T);
            return (T) this.dateBaseMap[type];
        }


    }
}