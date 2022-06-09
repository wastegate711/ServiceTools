namespace ServiceTools.Services.ControlBlock.Interfaces;

public interface IAnswerSorting
{
    /// <summary>
    /// Сортирует ответы пришедшие от блока управления
    /// </summary>
    /// <param name="data">Данные для сортировки.</param>
    void IncomingResponses(byte[] data);
}