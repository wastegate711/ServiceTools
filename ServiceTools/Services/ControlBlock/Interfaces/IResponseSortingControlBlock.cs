namespace ServiceTools.Services.ControlBlock.Interfaces;

public interface IResponseSortingControlBlock
{
    /// <summary>
    /// Сортирует входящие запросы от Блока управления.
    /// </summary>
    /// <param name="aData">Массив входящих данных.</param>
    void IncomingSorting(byte[] aData);
}