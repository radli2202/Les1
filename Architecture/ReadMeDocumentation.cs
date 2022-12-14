namespace TrainingArchitecture
{
    public class ReadMeDocumentation
    {
        
        // Архитектура построена следующим образом:
        //  Есть Базы данных которые хранят данные
        // Есть Интеракторы которые обробатывают данные
        // Проинициализировав интеракторы и Базы данных мы можем обратится к интерактору что бы получить данные из Базы данных из любого скрипта в любой момент времени
        // -- К примеру у нас есть банк который хранит валюту, обработка данных происходит через интерактор, данные хранятся в Базе данных, и если нам где то нужно
        // количество валюты (в магазине для покупки, сколько на счетчике, прибавить или отнять количество валюты и т.д. ) мы обращаемся к интерактору
        // котрый следовательно обращается к Базе данных и дает нам эти данные, если мы их изменяем, интерактор изменяет данные и возращает их.
        
        
        
        //Каждая сцена имеет собственную базу интеракторов и Базы данных (к примеру в сцене главного меню нам не нужны данные игрока, но нам нужны данные прогресса)
        // Список необходимых интеракторов и Базы данных хранится в ScenConfig
        
        // ---схема работы Архитектуры---
        
        // Game --(скрипт который знает о менеджерах сцены и конфигах, через него достаем необходимые интеракторы и базы данных)
        // GameTestArchitect -- тестовый скрипт, обращается к нужным интеракторам и методам через Game
        
        // Scen -- создает базу интеракторов и базданных для необходимой сцены
        // ScenConfig генерирует список интеракторов и базданных необходимых в сцене
        // ScenManager -- менеджер сцен который генерирует необходимые ScenConfig
        
        //  InteractorBase-- создает (список) текущих интеракторов инициализирует и запускает их
        //  DataBaseBase -- создает (список) текущую базу данных инициализирует и запускает их
        //
        //  Interactor --абстрактный класс с описанием методов по списку выполнения
        //  DataBase--абстрактный класс с описанием методов по списку выполнения
        
        
        // Bankinteractor -- интерактор Bank// BankDatabase -- база данных Bank// Bank -- фасад
        // PlayerInteractor//  Player -- аналогично выше перечисленному
        
        
        // для демонстрации поместите GameTestArchitect на сцену
        
    }
}