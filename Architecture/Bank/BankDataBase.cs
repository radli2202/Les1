using TrainingArchitecture;
using UnityEngine;


namespace TrainingArchitecture
{public class BankDataBase : DataBase
    {
        private const string Key = "Key_coin";
        public int coins { get; set; }
        
        

        public override void Initialize()
        {
            this.coins = PlayerPrefs.GetInt(Key, 0);

        }

        public override void Save()
        {
            PlayerPrefs.SetInt(Key,this.coins);
            
        }
    }
    
}

