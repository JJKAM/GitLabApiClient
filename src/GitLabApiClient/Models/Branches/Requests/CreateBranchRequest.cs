using GitLabApiClient.Internal.Utilities;
using Newtonsoft.Json;

namespace GitLabApiClient.Models.Branches.Requests
{
    /// <summary>
    /// Used to create branches in a project.
    /// </summary>
    public sealed class CreateBranchRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBranchRequest"/> class.
        /// </summary>
        /// <param name="projectId">The ID or URL-encoded path of the project owned by the authenticated user.</param>
        /// <param name="branch">name of the branch.</param>
        /// <param name="refBranch">branch name or commit SHA to create branch from</param>
        public CreateBranchRequest(string projectId, string branch, string refBranch)
        {
            Guard.NotNull(projectId, nameof(projectId));
            Guard.NotEmpty(branch, nameof(branch));
            Guard.NotEmpty(refBranch, nameof(refBranch));
            ProjectId = projectId;
            Branch = branch;
            RefBranch = refBranch;
        }

        /// <summary>
        /// The ID or URL-encoded path of the project owned by the authenticated user.
        /// </summary>
        [JsonProperty("id")]
        public string ProjectId { get; }

        /// <summary>
        /// Name of the branch.
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; }

        /// <summary>
        /// Branch name or commit SHA to create branch from.
        /// </summary>
        [JsonProperty("ref")]
        public string RefBranch { get; }
    }
}
