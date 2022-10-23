namespace TrainingArchitecture
{
    public sealed class ScenManagerExample:ScenManagerBase
    {
        protected internal override void InitScenDic()
        {
            this._scenConfigsDic[ScenConfigExample.ScenNameConst] = new ScenConfigExample(); //Инициализируем список сцен по ключу (ScenNameConst)
        }
    }
}