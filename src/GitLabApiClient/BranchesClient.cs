using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GitLabApiClient.Internal.Http;
using GitLabApiClient.Internal.Queries;
using GitLabApiClient.Models.Branches.Requests;
using GitLabApiClient.Models.Repositories.Requests;
using GitLabApiClient.Models.Repositories.Responses;

namespace GitLabApiClient
{
    /// <summary>
    /// Used to query GitLab API to retrieve, modify, create projects.
    /// <exception cref="GitLabException">Thrown if request to GitLab API fails</exception>
    /// <exception cref="HttpRequestException">Thrown if request to GitLab API fails</exception>
    /// </summary>
    public sealed class BranchesClient
    {
        private readonly GitLabHttpFacade _httpFacade;
        private readonly ProjectBranchesQueryBuilder _projectBranchesQueryBuilder;

        internal BranchesClient(GitLabHttpFacade httpFacade, ProjectBranchesQueryBuilder projectBranchesQueryBuilder)
        {
            _httpFacade = httpFacade;
            _projectBranchesQueryBuilder = projectBranchesQueryBuilder;
        }

        /// <summary>
        /// Retrieves project branch.
        /// </summary>
        public async Task<Branch> GetAsync(int projectId, string branch) =>
            await _httpFacade.Get<Branch>($"projects/{projectId}/repository/branches/{branch}");

        /// <summary>
        /// Retrieves branches from a project.
        /// </summary>
        /// <param name="projectId">Id of the project.</param>
        /// <param name="options">Branches retrieval options.</param>
        /// <returns>Branches satisfying options.</returns>
        public async Task<IList<Branch>> GetAsync(string projectId, Action<ProjectBranchesQueryOptions> options = null)
        {
            var queryOptions = new ProjectBranchesQueryOptions(projectId);
            options?.Invoke(queryOptions);

            string url = _projectBranchesQueryBuilder.Build($"projects/{projectId}/repository/branches", queryOptions);
            return await _httpFacade.GetPagedList<Branch>(url);
        }

        /// <summary>
        /// Creates new branch.
        /// </summary>
        /// <returns>The newly created branch.</returns>
        public async Task<Branch> CreateAsync(CreateBranchRequest request) =>
            await _httpFacade.Post<Branch>($"projects/{request.ProjectId}/repository/branches", request);

        /// <summary>
        /// Deletes an existing branch.
        /// </summary>
        public async Task DeleteAsync(int projectId, string branch) =>
            await _httpFacade.Delete($"projects/{projectId}/repository/branches/branch/{branch}");

        /// <summary>
        /// Deletes all branches that are merged into the project’s default branch.
        /// </summary>
        public async Task DeleteMergedAsync(int projectId) =>
            await _httpFacade.Delete($"projects/{projectId}/repository/merged_branches");
    }
}
