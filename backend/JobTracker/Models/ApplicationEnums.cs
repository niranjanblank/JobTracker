public enum ApplicationStatus
{
    Draft, // application is being prepared, not yet submitted
    Applied, // application has been submitted
    Interviewing, // in the interviewing process
    Negotiating, // duscussing salary, benefits, etc.
    Accepted, // offer has been accepted
    Rejected, // offer was rejected or application was not successful
    NoResponse, // no resopnse from employer
    Withdrawn // application was withdrawn by applicant
}