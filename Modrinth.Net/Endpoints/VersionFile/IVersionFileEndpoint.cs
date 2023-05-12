﻿using Modrinth.Exceptions;
using Modrinth.Models.Enums;

namespace Modrinth.Endpoints.VersionFile;

/// <summary>
///    Version file endpoints
/// </summary>
public interface IVersionFileEndpoint
{
    /// <summary>
    ///     Get specific version by file hash
    /// </summary>
    /// <param name="hash">The hash of the file, considering its byte content, and encoded in hexadecimal</param>
    /// <param name="hashAlgorithm"></param>
    /// <returns></returns>
    /// <exception cref="ModrinthApiException"> Thrown when the API returns an error or the request fails </exception>
    Task<System.Version> GetVersionByHashAsync(string hash,
        HashAlgorithm hashAlgorithm = HashAlgorithm.Sha1);

    /// <summary>
    ///    Deletes specific version by file hash
    /// </summary>
    /// <param name="hash"> The hash of the file, considering its byte content, and encoded in hexadecimal </param>
    /// <param name="hashAlgorithm"> The hash algorithm used to hash the file </param>
    /// <returns></returns>
    /// <exception cref="ModrinthApiException"> Thrown when the API returns an error or the request fails </exception>
    Task DeleteVersionByHashAsync(string hash,
        HashAlgorithm hashAlgorithm = HashAlgorithm.Sha1);
}