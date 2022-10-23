using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainingArchitecture
{
    public static class Bank
    {

        public static event Action OnBankInitializeEvent;

       // public static int coins => bankInteraktor.coins;
       public static int coins { get 
                                    {   CheckNotInitialize();
                                        return bankInteraktor.coins;
                                    }
                                }
        public static bool IsInitialize { get; private set; }

        private static BankInteraktor bankInteraktor;

        public static void Initialize(BankInteraktor interactor)
        {
            bankInteraktor = interactor;
            IsInitialize = true;
            OnBankInitializeEvent?.Invoke();
            Debug.Log("Bank Initialize");
        }

        
        public static bool IsCointAll(int value)
        {
            CheckNotInitialize();
            return bankInteraktor.IsCointAll(value);
        }

        public  static void AddCoins(object sender, int value)
        {
            CheckNotInitialize();
            bankInteraktor.AddCoins(sender,value);
        }
            
        public static void Spend (object sender, int value)
        {
            CheckNotInitialize();
            bankInteraktor.Spend(sender,value);
        }

        public static void CheckNotInitialize()
        {
            if (!IsInitialize) throw new Exception("Bank is not initialize");
        }
    }
}

