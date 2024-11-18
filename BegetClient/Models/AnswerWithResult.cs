namespace TDV.BegetClient.Models
{
    public class AnswerWithResult<T> where T : class
    {
        public T Result { get; set; }
    }
}
