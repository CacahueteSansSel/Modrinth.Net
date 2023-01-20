﻿using Modrinth.RestClient.Models;
using Index = Modrinth.RestClient.Models.Enums.Index;

namespace Modrinth.RestClient.Endpoints.Project;

public interface IProjectApi
{
    /// <summary>
    /// Gets project by slug or ID
    /// </summary>
    /// <param name="slugOrId">The ID or slug of the project</param>
    /// <returns></returns>
    Task<Models.Project> GetProjectAsync(string slugOrId);
    
    /// <summary>
    /// Gets multiple projects by their IDs
    /// </summary>
    /// <param name="ids">IEnumerable of string ids</param>
    /// <returns></returns>
    Task<Models.Project[]> GetMultipleProjectsAsync(IEnumerable<string> ids);

    /// <summary>
    /// Check project slug/ID validity
    /// </summary>
    /// <returns></returns>
    Task<string> CheckProjectIdSlugValidityAsync(string slugOrId);
    
    /// <summary>
    /// Search Modrinth for project by it's name
    /// </summary>
    /// <param name="query">The query to search for</param>
    /// <param name="index">The sorting method used for sorting search results</param>
    /// <param name="offset">The offset into the search. Skips this number of results</param>
    /// <param name="limit">The number of results returned by the search</param>
    /// <returns></returns>
    Task<SearchResponse> SearchProjectsAsync(
        string query,
        Index index = Index.Downloads,
        ulong offset = 0,
        ulong limit = 10);
}