using System;
using System.Collections;

namespace TrainingArchitecture
{
    public static class Game  //статичный класс оператор через который мы обращаемся к менеджеру сцены
    {
        public static event Action OnGameInitializeEvent;
        public static ScenManagerBase scenManagerBase { get; private set; } //статичная переменная абстрактного класса
        public static void Run() // метод для запуска игры (при запуске игры)
        {
            scenManagerBase = new ScenManagerExample();  // назначаем наследуемый класс
            Coroutines.StartCoroutineMain(InitializeGameCoroutine()); // выполняем корутину инициализации через оброботчик корутин
        }

        private static IEnumerator InitializeGameCoroutine()
        {
            scenManagerBase.InitScenDic();  //достаем список сцен
            yield return scenManagerBase.LoadCurrentScenAsync();
            OnGameInitializeEvent?.Invoke();
        }
        
        public static T GetDataBase<T>() where T : DataBase   // добавляем базы данных нужной нам сцены
        {
            return   Game.scenManagerBase.GetDataBase<T>();
        }
        public static T GetInteractor<T>() where T : Interaktor // добавляем интеракторы нужной нам сцены
        {
            return   Game.scenManagerBase.GetInteractor<T>();
        }
    }
}