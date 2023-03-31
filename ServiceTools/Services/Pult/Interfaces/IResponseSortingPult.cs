namespace ServiceTools.Services.Pult.Interfaces;

public interface IResponseSortingPult
{
    /// <summary>
    /// Сортирует ответы от блока Pult
    /// </summary>
    /// <param name="aData">Массив с данными.</param>
    void IncomingSorting(byte[] aData);
}