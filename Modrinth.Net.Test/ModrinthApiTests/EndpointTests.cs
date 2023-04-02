﻿using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Modrinth.Net.Test.ModrinthApiTests;

[SetUpFixture]
public class EndpointTests
{
    protected const string ModrinthNetTestProjectId = "jKePI2WR";
    protected const string ModrinthNetTestUploadedVersionId = "dJIVHDfy";
    
    /// <summary>
    /// Must be users that have at least one project
    /// </summary>
    protected readonly string[] TestUserIds = {"MaovZxtD", "5XoMa0C4"};

    protected string TestUserId => TestUserIds[0];

    protected const string TestProjectSlug = "gravestones";

    private static readonly IConfigurationRoot Configuration =
        new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    protected readonly FileInfo Icon = new("../../../../Modrinth.Net.Test/Assets/Icons/ModrinthNet.png");

    protected IModrinthClient Client = null!;
    protected IModrinthClient NoAuthClient = null!;

    private static string GetToken()
    {
        var token = Environment.GetEnvironmentVariable("MODRINTH_TOKEN");
        if (string.IsNullOrEmpty(token)) token = Configuration["ModrinthApiKey"];

        if (string.IsNullOrEmpty(token)) throw new Exception("MODRINTH_TOKEN environment variable is not set.");

        return token;
    }

    [OneTimeSetUp]
    public void SetUp()
    {
        var token = GetToken();
        var userAgent = new UserAgent
        {
            GitHubUsername = "Zechiax",
            ProjectName = "Modrinth.Net.Test",
            ProjectVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString()
        };

        var configAuth = new ModrinthClientConfig
        {
            ModrinthToken = token,
            BaseUrl = ModrinthClient.StagingBaseUrl,
            UserAgent = userAgent.ToString()
        };

        var configNoAuth = new ModrinthClientConfig
        {
            BaseUrl = ModrinthClient.StagingBaseUrl,
            UserAgent = userAgent.ToString()
        };

        Client = new ModrinthClient(configAuth);
        NoAuthClient = new ModrinthClient(configNoAuth);
    }
}