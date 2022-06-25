namespace ServiceTools.Services.ControlBlock.Interfaces;

public interface IResponseSortingControlBlock
{
    /// <summary>
    /// Сортирует ответы пришедшие от блока управления
    /// </summary>
    /// <param name="data">Данные для сортировки.</param>
    void IncomingResponses(byte[] data);
}