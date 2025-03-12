namespace RSGymPT.Models
{
    //<summary>
    //This enum represents the status of a request.
    //</summary>
    public enum RequestStatus
    {
        Agendado,
        Terminado,
        Cancelado
    }

    //<summary>
    //This class represents a request for a personal trainer.
    //</summary>
    public class Request
    {
        public int RequestId { get; set; }
        public string UserCode { get; set; }
        public string PTCode { get; set; }
        public DateTime ScheduleDate { get; set; }
        public RequestStatus Status { get; set; }
        public string? CancelReason { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
