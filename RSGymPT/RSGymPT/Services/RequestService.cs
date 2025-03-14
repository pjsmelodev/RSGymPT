using System.Text.Json;
using RSGymPT.Models;

namespace RSGymPT.Services
{
    //<summary>
    //This service manages all operations related to requests.
    //</summary>
    public static class RequestService
    {
        //private static readonly string RequestsPath = "Data/JsonFiles/requests.json";
        private static readonly string RequestsPath = @"C:\Users\pjsml\OneDrive\Documents\RSGymPT\RSGymPT\RSGymPT\Data\JsonFiles\requests.json";

        private static int _nextRequestId = 1; 
        public static List<Request> Requests { get; private set; } = new List<Request>();

        //<summary>
        //Initializes the requests by loading data from a JSON file.
        //</summary>
        public static void Initialize()
        {
            if (File.Exists(RequestsPath))
            {
                var jsonData = File.ReadAllText(RequestsPath);
                Requests = JsonSerializer.Deserialize<List<Request>>(jsonData) ?? new List<Request>();
                if (Requests.Any())
                {
                    _nextRequestId = Requests.Max(r => r.RequestId) + 1;
                }
            }
        }

        //<summary>
        //Saves the current requests to the JSON file.
        //</summary>
        public static void SaveRequests()
        {
            var jsonData = JsonSerializer.Serialize(Requests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(RequestsPath, jsonData);
        }

        //<summary>
        //Registers a new request for a personal trainer session.
        //</summary>
        public static Request RegisterRequest(string userCode, string ptCode, DateTime scheduleDate)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                throw new ArgumentException("User code cannot be null or empty.", nameof(userCode));

            if (string.IsNullOrWhiteSpace(ptCode))
                throw new ArgumentException("PT code cannot be null or empty.", nameof(ptCode));

            if (scheduleDate <= DateTime.Now)
                throw new ArgumentException("The scheduled date must be in the future.", nameof(scheduleDate));

            var newRequest = new Request
            {
                RequestId = _nextRequestId++,
                UserCode = userCode,
                PTCode = ptCode,
                ScheduleDate = scheduleDate,
                Status = RequestStatus.Agendado
            };

            Requests.Add(newRequest);
            SaveRequests();
            return newRequest;
        }

        //<summary>
        //Gets all requests for a specific user by their user code.
        //</summary>
        public static List<Request> GetUserRequests(string userCode)
        {
            EnsureRequestsExist(); // Verifica se há requests
            return Requests
                .Where(r => r.UserCode == userCode)
                .ToList();
        }

        //<summary>
        //Modifies the schedule date of an existing request if it is "Agendado".
        //</summary>
        public static bool ModifyRequest(int requestId, DateTime newScheduleDate)
        {
            EnsureRequestsExist();

            var request = Requests.FirstOrDefault(r => r.RequestId == requestId);
            if (request == null)
                throw new InvalidOperationException($"Request with ID {requestId} not found.");

            if (request.Status != RequestStatus.Agendado)
                throw new InvalidOperationException("Only requests in the 'Agendado' status can be modified.");

            if (newScheduleDate <= DateTime.Now)
                throw new ArgumentException("The new scheduled date must be in the future.", nameof(newScheduleDate));

            request.ScheduleDate = newScheduleDate;
            SaveRequests();
            return true;
        }

        //<summary>
        //Deletes an existing request if it is "Agendado".
        //</summary>
        public static bool DeleteRequest(int requestId)
        {
            EnsureRequestsExist();

            var request = Requests.FirstOrDefault(r => r.RequestId == requestId);
            if (request == null)
                throw new InvalidOperationException($"Request with ID {requestId} not found.");

            if (request.Status != RequestStatus.Agendado)
                throw new InvalidOperationException("Only requests in the 'Agendado' status can be deleted.");

            Requests.Remove(request);
            SaveRequests();
            return true;
        }

        //<summary>
        //Marks a request as completed.
        //</summary>
        public static bool CompleteRequest(int requestId)
        {
            EnsureRequestsExist();

            var request = Requests.FirstOrDefault(r => r.RequestId == requestId);
            if (request == null)
                throw new InvalidOperationException($"Request with ID {requestId} not found.");

            if (request.Status != RequestStatus.Agendado)
                throw new InvalidOperationException("Only requests in the 'Agendado' status can be completed.");

            request.Status = RequestStatus.Terminado;
            request.CompletionDate = DateTime.Now;
            SaveRequests();
            return true;
        }

        //<summary>
        //Cancels an existing request and provides a cancellation reason.
        //</summary>
        public static bool CancelRequest(int requestId, string reason)
        {
            EnsureRequestsExist();

            var request = Requests.FirstOrDefault(r => r.RequestId == requestId);
            if (request == null)
                throw new InvalidOperationException($"Request with ID {requestId} not found.");

            if (request.Status != RequestStatus.Agendado)
                throw new InvalidOperationException("Only requests in the 'Agendado' status can be cancelled.");

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Cancellation reason cannot be null or empty.", nameof(reason));

            request.Status = RequestStatus.Cancelado;
            request.CancelReason = reason;
            request.CompletionDate = DateTime.Now;
            SaveRequests();
            return true;
        }

        //<summary>
        //Ensures there are requests available; throws an exception if none exist.
        //</summary>
        private static void EnsureRequestsExist()
        {
            if (Requests == null || !Requests.Any())
            {
                throw new InvalidOperationException("No requests found. Please create a new request first.");
            }
        }
    }
}
