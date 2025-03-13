
namespace JobTracker.Models
{
    public enum InterviewProgress
    {   Pending, // interview has not been scheduled
        Scheduled, // interview has been scheduled
        Completed, // interview has been completed
        Cancelled, // interview was cancelled
    }

    public enum InterviewStatus
    {
        Pending, // interview has not been completed
        Passed, // interview was successful
        Failed, // interview was unsuccessful
    }

}
