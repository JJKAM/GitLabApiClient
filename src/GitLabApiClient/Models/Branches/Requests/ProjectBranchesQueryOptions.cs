
namespace GitLabApiClient.Models.Repositories.Requests
{
    public sealed class ProjectBranchesQueryOptions
    {
        /// <summary>
        /// Initializes a new instance of ProjectBranchesQueryOptions
        /// </summary>
        /// <param name="projectId">The ID or URL-encoded path of the project owned by the authenticated user</param>
        internal ProjectBranchesQueryOptions(string projectId)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// The ID or URL-encoded path of the project owned by the authenticated user
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// Return list of branches containing the search string. You can use ^term and term$ to find branches that begin and end with term respectively.
        /// </summary>
        public string Search { get; set; }
    }
}
