using GitLabApiClient.Models.Repositories.Requests;

namespace GitLabApiClient.Internal.Queries
{
    internal class ProjectBranchesQueryBuilder : QueryBuilder<ProjectBranchesQueryOptions>
    {
        #region Overrides of QueryBuilder<ProjectBranchesQueryOptions>

        protected override void BuildCore(ProjectBranchesQueryOptions options)
        {
            Add("id", options.ProjectId);
        }

        #endregion
    }
}
