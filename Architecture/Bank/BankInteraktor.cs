
using System.Security.Cryptography.X509Certificates;
using TrainingArchitecture;
using Unity.VisualScripting;

namespace  TrainingArchitecture
{
    public class BankInteraktor : Interaktor
    {
        private BankDataBase bankDataBase;

        public int coins => this.bankDataBase.coins;
            
            public BankInteraktor()
            {
            this.bankDataBase = bankDataBase;
            }

            public override void OnCreat()
            {
               base.OnCreat();
               this.bankDataBase = Game.GetDataBase<BankDataBase>();
            }

            // ReSharper disable Unity.PerformanceAnalysis
            public override void Initialize()
            {
              Bank.Initialize(this);
            }

            public bool IsCointAll(int value)
            {
                return coins >= value;
            }

            public void AddCoins(object sender, int value)
            {

                this.bankDataBase.coins += value;
                this.bankDataBase.Save();
            }
            
            public  void Spend (object sender, int value)
            {
                this.bankDataBase.coins -= value;
                this.bankDataBase.Save();
            }

    }
}


